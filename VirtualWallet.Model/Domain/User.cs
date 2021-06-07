using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using VirtualWallet.Model.Classes;

namespace VirtualWallet.Model.Domain
{
    [Serializable]
    public class User : Entity
    {
        [DisplayName("Nazwa użytkownika")]
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string Email { get; set; }
        public virtual UserRole UserRole { get; set; }

        public virtual string Greeting => $"Witaj, {UserName}!";
    }
}
