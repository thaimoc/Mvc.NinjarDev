using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eCommerce.ModelConventions
{
    public class StringPropertiesMaxLength : Convention
    {
        public StringPropertiesMaxLength()
        {
            Properties<String>().Configure(x => x.HasMaxLength(255));
        }
    }
}