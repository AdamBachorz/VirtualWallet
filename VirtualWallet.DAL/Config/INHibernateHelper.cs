using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualWallet.DAL.Config
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
        ICustomConfig CustomConfig { get; }
    }
}
