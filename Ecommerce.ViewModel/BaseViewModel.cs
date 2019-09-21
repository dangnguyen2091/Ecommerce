using Ecommerce.Common.Attributes;
using Ecommerce.Common.Extension;
using System;
using System.Reflection;

namespace Ecommerce.ViewModel
{
    public class BaseViewModel
    {
        public virtual object ToEntity()
        {
            if (GetType().GetCustomAttribute(typeof(EntityCastAttribute)) is EntityCastAttribute attribute)
            {
                Type type = Type.GetType($"Ecommerce.DataLayer.Context.{attribute.EntityType}, Ecommerce.DataLayer");
                object entity = (object)Activator.CreateInstance(type);
                PropertyInfo[] properties = GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetCustomAttribute(typeof(PropertyCastAttribute)) is PropertyCastAttribute att)
                    {
                        entity.SetNestedValue(att.Property, property.GetValue(this));    
                    }
                }
                return entity;
            }
            return null;
        }

        public virtual void BindEntity(object model)
        {
            if (GetType().GetCustomAttribute(typeof(EntityCastAttribute)) is EntityCastAttribute attribute)
            {
                PropertyInfo[] properties = GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetCustomAttribute(typeof(PropertyCastAttribute)) is PropertyCastAttribute att)
                    {
                        object value = model.GetNestedValue(att.Property);
                        property.SetValue(this, value);
                    }
                }
            }
        }
    }
}
