//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YGOCollection1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class YGOSpells
    {
        public short CardID { get; set; }
        public string CardName { get; set; }
        public Nullable<short> CardTypeID { get; set; }
        public Nullable<short> CardNumberID { get; set; }
        public string CardPassword { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
        public string CardNumber { get; set; }
        public Nullable<bool> cardenable { get; set; }
    
        public virtual refCardList refCardList { get; set; }
        public virtual TypeSpellCard TypeSpellCard { get; set; }
    }
}
