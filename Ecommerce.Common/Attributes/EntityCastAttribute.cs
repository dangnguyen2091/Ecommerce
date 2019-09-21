using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EntityCastAttribute : Attribute
    {
        public string EntityType { get; private set; }

        public EntityCastAttribute(string entityType)
        {
            EntityType = entityType;
        }
    }
}
