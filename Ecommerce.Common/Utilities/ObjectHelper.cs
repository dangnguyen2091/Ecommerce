using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Extension
{
    public static class ObjectHelper
    {
        public static void SetNestedValue(this object obj, string propName, object value)
        {
            string[] nameParts = propName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            object nestedObj = obj;
            for (int i = 0; i < nameParts.Length; i++)
            {
                PropertyInfo property = nestedObj.GetType().GetProperty(nameParts[i]);
                if (property.SetMethod.IsVirtual)
                {
                    break;
                }
                if (i < nameParts.Length - 1)
                {
                    object nestedValue = property.GetValue(nestedObj, null);
                    if (nestedValue == null)
                    {
                        nestedValue = Activator.CreateInstance(property.PropertyType);
                        property.SetValue(nestedObj, nestedValue);
                    }
                    nestedObj = nestedValue;
                }
                else
                {
                    property.SetValue(nestedObj, value);
                }
            }
        }

        public static object GetNestedValue(this object obj, string propName)
        {
            string[] nameParts = propName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            object nestedObj = obj;
            for (int i = 0; i < nameParts.Length; i++)
            {
                PropertyInfo property = nestedObj.GetType().GetProperty(nameParts[i]);
                nestedObj = property.GetValue(nestedObj, null);
                if (nestedObj == null)
                {
                    break;
                }
            }
            return nestedObj;
        }
    }
}
