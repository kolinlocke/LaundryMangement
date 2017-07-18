using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _EntityBase;

namespace Interface_DataMethods
{
    interface Interface_EntityMethods<T_Entity>
        where T_Entity : EntityBase, new()
    {

    }
}
