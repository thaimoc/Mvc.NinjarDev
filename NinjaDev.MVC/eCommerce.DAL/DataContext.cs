using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eCommerce.Classes;
using eCommerce.Classes.Intefaces;
using eCommerce.ModelConventions;
using EntityFramework.Filters;

namespace eCommerce.DAL
{
    //[DbConfigurationType(typeof(DbConfigurations.CustomDbConfiguration))]
    public class DataContext : DbContext
    {
        //private readonly Stream _fileStream;
        //private readonly StreamWriter _writer;

        public DataContext()
        {
            this.EnableFilter("IsNotDeletedCustomers");

            //_fileStream = File.Open(@"D:\LogDb.txt", FileMode.OpenOrCreate);
            //_writer = new StreamWriter(_fileStream);
            //Database.Log = s =>
            //{
            //    Task.Run(() =>  
            //    {
            //        _writer.WriteAsync(s);
            //    });
            //};
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _writer?.Close();
        //    _writer?.Dispose();
        //    _fileStream?.Close();
        //    _fileStream?.Dispose();
        //    base.Dispose(disposing);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Configurations.AddFromAssembly(typeof(DataContext).Assembly);

            DbInterception.Add(new FilterInterceptor());

            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(4000);

            modelBuilder.Properties<Guid>().Where(p=>p.Name=="Key").Configure(c=>c.IsKey());


            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Idx_History.Customers.Customer_Name", 2)));
            modelBuilder.Conventions.AddFromAssembly(typeof(ModelConventionsContext).Assembly);

            modelBuilder.HasDefaultSchema("AnythingsBut_dbo");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {

            Func<int> callback = base.SaveChanges;

            return SaveChangeCustom(callback);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            Func<Task<int>> callbackAsync = () => base.SaveChangesAsync(cancellationToken);

            return SaveChangeCustom(callbackAsync);
        }

        private TOut SaveChangeCustom<TOut>(Func<TOut> callback)
        {
            foreach (var history in ChangeTracker.Entries()
                .Where(
                    e => e.Entity is IModificationHistory && (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateModified = DateTime.UtcNow;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.UtcNow;
                }
            }

            var result = Task.Run(callback).Result;
            //var result = callback();

            foreach (
                var history in
                    ChangeTracker.Entries()
                        .Where(e => e.Entity is IModificationHistory)
                        .Select(e => e.Entity as IModificationHistory))
            {
                history.IsDirty = false;
            }

            return result;
        }
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerArea> CustomerAreas { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }


    static class ConventionRules
    {
        public static void Apply(DbModelBuilder builder)
        {
            builder.Conventions.AddAfter<StringPropertiesMaxLength>(new NamePropertiesMaxLength());
        }
    }
}
