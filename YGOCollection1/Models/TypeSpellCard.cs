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
    
    public partial class TypeSpellCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeSpellCard()
        {
            this.YGOSpells = new HashSet<YGOSpells>();
        }
    
        public short ID { get; set; }
        public string cardtype { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YGOSpells> YGOSpells { get; set; }
    }
}
