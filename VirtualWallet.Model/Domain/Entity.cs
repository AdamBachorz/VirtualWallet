using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace VirtualWallet.Model.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }
}
