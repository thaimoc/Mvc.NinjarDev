using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using eCommerce.Classes.CustomAttributes;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    [Schema("History")]
    public class Product : IEntity, IModificationHistory, ISoftDeleting//, IHistory
    {
        public Product()
        {
            Customers = new EnumerableQuery<Customer>(new List<Customer>());
        }
        public Guid Key { get; set; }

        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

        public IQueryable<Customer> Customers { get; set; } /* Load this value you using .Include()-select subtion or Colection().Load()-union select*/

        /* 
         *  When you use Lazy loading of EF when you call any method likes this.Customers.Count.
         *  But it's not perfect be cause when you have 20 products Db will execute 20 select statement for load every Customer 
         */
        // public virtual IQueryable<Customer> Customers { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
