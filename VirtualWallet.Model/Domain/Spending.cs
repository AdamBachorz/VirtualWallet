using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    [Serializable]
    public class Spending : Entity
    {
        [DisplayName("Nazwa")]
        public virtual string Name { get; set; }
        [DisplayName("Wartość")]
        public virtual decimal Value { get; set; }
        [DisplayName("Data utworzenia")]
        public virtual DateTime? CreationDate { get; set; }
        [DisplayName("Kto dodał")]
        public virtual User User { get; set; }
        public virtual MonthlySpending MonthlySpending { get; set; }
        public virtual ConstantSpending ConstantSpending { get; set; }
    }
}
