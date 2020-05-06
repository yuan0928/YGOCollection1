using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YGOCollection1.Models
{   [MetadataType(typeof(YGOSpellsMD))]
    public partial class YGOSpells
    {
        public class YGOSpellsMD
        {
            public short CardID { get; set; }
            [Display(Name ="卡片名稱")]
            public string CardName { get; set; }
            public Nullable<short> CardTypeID { get; set; }
            public Nullable<short> CardNumberID { get; set; }
            [Display(Name = "卡片密碼")]
            public string CardPassword { get; set; }
            public Nullable<System.DateTime> create_at { get; set; }
            public Nullable<System.DateTime> update_at { get; set; }
            public string CardNumber { get; set; }

            public virtual refCardList refCardList { get; set; }
            public virtual TypeSpellCard TypeSpellCard { get; set; }
        }
    }
}