using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eCommerce.ModelConventions
{
    public class NamePropertiesMaxLength : Convention
    {
        public NamePropertiesMaxLength()
        {
            Properties<String>().Where(x => x.Name == "Name").Configure(x => x.HasMaxLength(128));
        }
    }
}