using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eCommerce.ModelConventions
{
    public class ForgenKeyNameWithKfConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (association.IsForeignKey && association.Constraint.FromRole.RelationshipMultiplicity != RelationshipMultiplicity.One)
            {
                var assnProperty = association.Constraint.ToProperties;
                if (assnProperty[0].Name.EndsWith("Key"))
                {
                    assnProperty[0].Name = assnProperty[0].Name.Substring(0, assnProperty[0].Name.Length - 3) + "FKKey";
                }

            }
        }
    }
}