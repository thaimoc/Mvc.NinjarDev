using System;
using System.Collections.Generic;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    public class CustomerArea : IEntity, IModificationHistory
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

        public CustomerArea()
        {
            Customers = new List<Customer>();
        }
    }
}