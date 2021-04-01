using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.DAL.Config
{
    public class CustomConfig : ICustomConfig
    {
        public bool IsProduction { get; set; }
        public string ConnectionString { get; set; }

        public CustomConfig()
        {

        }

        public CustomConfig(bool isProduction, string connectionString)
        {
            IsProduction = isProduction;
            ConnectionString = connectionString;
        }

        //
    }
}
