using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using eCommerce.Classes.CustomAttributes;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    [Schema("History")]
    public class Customer : IEntity, IModificationHistory, ISoftDeleting //, IHistory
    {
        public Customer()
        {
            Products = new EnumerableQuery<Product>(new List<Product>());
        }
        
        public Guid Key { get; set; }

        [Required, MaxLength(256)]
        public string CustomerName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }

        public bool OrderLevel { get; set; }

        public Person TrueIdentity { get; set; }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

        public IQueryable<Product> Products { get; set; }
        public bool IsDeleted { get; set; }
    }
}