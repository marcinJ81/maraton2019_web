
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace LibDatabase.DbContext
{

using System;
    using System.Collections.Generic;
    
public partial class Plec
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Plec()
    {

        this.kartoteka2 = new HashSet<kartoteka2>();

    }


    public int plec_id { get; set; }

    public string plec_opis { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<kartoteka2> kartoteka2 { get; set; }

}

}