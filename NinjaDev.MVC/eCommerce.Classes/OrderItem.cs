using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Classes.CustomAttributes;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    [Schema("History")]
    public class OrderItem : IEntity, IModificationHistory//, IHistory
    {
        public Guid Key { get; set; } 
        
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        [Required]
        public Order Order { get; set; }
        public Guid OrderKey { get; set; }
        [Required]
        public Product Product { get; set; }
        public Guid ProductKey { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}