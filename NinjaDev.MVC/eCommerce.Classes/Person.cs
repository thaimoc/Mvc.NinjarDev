using System;
using eCommerce.Classes.Intefaces;

namespace eCommerce.Classes
{
    public class Person : IEntity, IModificationHistory
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}