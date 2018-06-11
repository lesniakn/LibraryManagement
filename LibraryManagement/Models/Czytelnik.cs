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
    using System.ComponentModel.DataAnnotations;


    public partial class Czytelnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Czytelnik()
        {
            this.Rola = 0;
            this.Wiadomosci = new HashSet<Wiadomosci>();
            this.Wypozyczenia_Czasopisma = new HashSet<Wypozyczenia_Czasopisma>();
            this.Wypozyczenia_Filmu = new HashSet<Wypozyczenia_Filmu>();
            this.Wypozyczenia_Ksiazki = new HashSet<Wypozyczenia_Ksiazki>();
            this.Wypozyczenia_Praca_Naukowa = new HashSet<Wypozyczenia_Praca_Naukowa>();
        }
    
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Uzytkownik { get; set; }
        public string Haslo { get; set; }
        public string Email { get; set; }
        public int Rola { get; set; }
        public bool Wazne { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wiadomosci> Wiadomosci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia_Czasopisma> Wypozyczenia_Czasopisma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia_Filmu> Wypozyczenia_Filmu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia_Ksiazki> Wypozyczenia_Ksiazki { get; set; }
        public virtual Rola Rola1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia_Praca_Naukowa> Wypozyczenia_Praca_Naukowa { get; set; }
    }
}
