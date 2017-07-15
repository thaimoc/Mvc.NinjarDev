using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using eCommerce.Classes.CustomAttributes;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    [Schema("History")]
    public class Order : IEntity, IModificationHistory, ISoftDeleting//, IHistory
    {
        public Order()
        {
            Items = new EnumerableQuery<OrderItem>(new List<OrderItem>());
        }

        public Guid Key { get; set; }

        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerKey { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

        public IQueryable<OrderItem> Items { get; set; }
        public bool IsDeleted { get; set; }
    }
}