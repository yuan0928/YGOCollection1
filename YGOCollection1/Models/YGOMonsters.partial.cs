using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YGOCollection1.Models
{
    [MetadataType(typeof(YGOMonstersMD))]
    public partial class YGOMonsters
    {
        public class YGOMonstersMD
        {
            public short CardID { get; set; }
            [DisplayName("卡片名稱")]
            public string CardName { get; set; }
            public Nullable<short> CardAttributeID { get; set; }
            [DisplayName("星等")]
            public Nullable<short> CardLevel { get; set; }
            public Nullable<short> MonsterTypeID { get; set; }
            public Nullable<short> CardTypeID { get; set; }
            [DisplayName("攻擊力")]
            public string ATK { get; set; }
            [DisplayName("守備力")]
            public string DEF { get; set; }
            public Nullable<short> CardNumberID { get; set; }
            [DisplayName("卡片密碼")]
            public string CardPassword { get; set; }
            public Nullable<bool> CardExtra { get; set; }
            public Nullable<System.DateTime> create_at { get; set; }
            public Nullable<System.DateTime> update_at { get; set; }
            [DisplayName("卡片編號")]
            public string CardNumber { get; set; }
            public Nullable<bool> cardenable { get; set; }

            [Display(Name = "屬性")]
            public virtual refAttribute refAttribute { get; set; }
            [Display(Name = "卡片所屬")]
            public virtual refCardList refCardList { get; set; }
            [Display(Name = "種族")]
            public virtual refMonsterType refMonsterType { get; set; }
            [Display(Name ="類型")]
            public virtual TypeMonsterCard TypeMonsterCard { get; set; }
        }
    }
}