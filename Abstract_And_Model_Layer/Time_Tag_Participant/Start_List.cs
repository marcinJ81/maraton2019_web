//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Abstract_And_Model_Layer.Time_Tag_Participant
{
    using System;
    using System.Collections.Generic;
    
    public partial class Start_List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Start_List()
        {
            this.Zawodnik = new HashSet<Zawodnik>();
        }
    
        public int list_id { get; set; }
        public string list_nazwa { get; set; }
        public Nullable<int> list_iloscMaks { get; set; }
        public Nullable<int> list_ilosc { get; set; }
        public Nullable<System.DateTime> list_data { get; set; }
        public Nullable<System.TimeSpan> list_czas { get; set; }
        public Nullable<bool> list_zamknieta { get; set; }
        public Nullable<int> dys_id { get; set; }
        public Nullable<bool> list_start { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zawodnik> Zawodnik { get; set; }
    }
}