using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiInmoto.DAL.Config
{
    public interface ICustomConfig
    {
        bool IsProduction { get; set; }
        string ConnectionString { get; set; }
    }
}
