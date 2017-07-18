using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _EntityBase
{
    [Serializable()]
    public abstract class EntityBase { }

    [Serializable()]
    public abstract class EntityBase<T_EntityKey> : EntityBase
        where T_EntityKey : EntityKey, new()
    { }

    [Serializable()]
    public abstract class EntityKey { }
}