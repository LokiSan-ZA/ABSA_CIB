//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneBookDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhoneBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhoneBook()
        {
            this.PhoneBookEntries = new HashSet<PhoneBookEntry>();
        }
    
        public int phonebookid { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public Nullable<System.DateTime> datemodified { get; set; }
        public Nullable<int> active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}
