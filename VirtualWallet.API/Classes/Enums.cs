using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWallet.API.Classes
{
    public enum DbOperationType
    {
        [Description("Pobieranie listy elementów typu {0}")]
        GetAll,
        [Description("Pobieranie elementu typu {0} o ID = {1}")]
        GetById,
        [Description("Wstawianie elementu typu {0}")]
        Insert,
        [Description("Update elementu typu {0}")]
        Update,
        [Description("Usuwanie elementu typu {0} o ID = {1}")]
        Delete
    }
}
