using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PropertyCastAttribute : Attribute
    {
        public string Property { get; private set; }

        public PropertyCastAttribute(string property)
        {
            Property = property;
        }
    }
}
