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
    
    public partial class refAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public refAttribute()
        {
            this.YGOMonsters = new HashSet<YGOMonsters>();
        }
    
        public short ID { get; set; }
        public string attribute { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public Nullable<System.DateTime> update_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YGOMonsters> YGOMonsters { get; set; }
    }
}
