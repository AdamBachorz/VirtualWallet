using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VirtualWallet.Model.Domain
{
    [Serializable]
    public class Spending : Entity
    {
        [Required(ErrorMessage = "Pole 'Nazwa' nie może być puste", AllowEmptyStrings = false)]
        [DisplayName("Nazwa")]
        public virtual string Name { get; set; }
        [Required(ErrorMessage = "Podana wartość nie jest liczbą", AllowEmptyStrings = false)]
        [DisplayName("Wartość (zł)")]
        [DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public virtual decimal Value { get; set; }
        [DisplayName("Data utworzenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public virtual DateTime? CreationDate { get; set; }
        [DisplayName("Kto dodał")]
        public virtual User User { get; set; }
        public virtual MonthlySpending MonthlySpending { get; set; }
        public virtual ConstantSpending ConstantSpending { get; set; }
    }
}
