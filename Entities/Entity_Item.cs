using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _EntityBase;
using _EntityBase.EntityAttributes;

namespace _Entities
{
    [Entity(EntityName = "Item")]
    public class Entity_Item : EntityBase<EntityKey_Item>
    {
        [EntityField(FieldName = "ItemID", IsKey = true)]
        public Int64 ItemID { get; set; }

        [EntityField(FieldName = "RowPropertyID")]
        public Int64 RowPropertyID { get; set; }

        [EntityField(FieldName = "IsDeleted")]
        public Boolean IsDeleted { get; set; }
    }

    public class EntityKey_Item : EntityKey
    {
        [EntityField(FieldName = "ItemID")]
        public Int64 ItemID { get; set; }
    }
}