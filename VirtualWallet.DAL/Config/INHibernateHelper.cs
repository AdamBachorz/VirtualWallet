using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiInmoto.DAL.Config
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
        ICustomConfig CustomConfig { get; }
    }
}
