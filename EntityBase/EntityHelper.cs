using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using _EntityBase.EntityAttributes;

namespace _EntityBase
{
    public static class EntityHelper
    {
        public class EntityFields : List<EntityField> { }

        public class EntityField
        {
            public String FieldName { get; set; }
            public Boolean IsKey { get; set; }
        }

        public static String Get_EntityName<T>() where T : EntityBase
        {
            String EntityName = "";
            Type EntityType = typeof(T);

            var EntityAtts = EntityType.GetCustomAttributes(typeof(EntityAttribute), true);
            if (EntityAtts.Any())
            { EntityName = (EntityAtts.FirstOrDefault() as EntityAttribute).EntityName; }
            else
            {
                String ExceptionMsg = String.Format("EntityName not set in {0}", EntityType.Name);
                throw new EntityException(ExceptionMsg);
            }

            return EntityName;
        }

        public static EntityFields Get_EntityFields<T>() where T : EntityBase
        {
            EntityFields EntityFields = new EntityFields();
            Type EntityType = typeof(T);

            var EntityProps = EntityType.GetProperties(System.Reflection.BindingFlags.Public);

            var EntityAtts = EntityType.GetCustomAttributes(typeof(EntityFieldAttribute), true);
            foreach (Attribute Item_Att in EntityAtts)
            {
                if (Item_Att is EntityFieldAttribute)
                {
                    EntityFieldAttribute EntityFieldAtt = (Item_Att as EntityFieldAttribute);
                    EntityFields.Add(
                        new EntityField()
                        {
                            FieldName = EntityFieldAtt.FieldName,
                            IsKey = EntityFieldAtt.IsKey
                        });
                }
            }

            return EntityFields;
        }
    }

    public class EntityException : Exception 
    {
        public EntityException(String Message) : base(Message) { }
    }
}
