//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wypozyczenia_Filmu
    {
        public int ID { get; set; }
        public Nullable<int> ID_Czytelnika { get; set; }
        public Nullable<int> ID_Filmu { get; set; }
        public System.DateTime Data_Wypozyczenia { get; set; }
        public System.DateTime Data_Zwrotu { get; set; }
        public int Stan { get; set; }
    
        public virtual Czytelnik Czytelnik { get; set; }
        public virtual Film Film { get; set; }
        public virtual Stan Stan1 { get; set; }
    }
}
