using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookService.Models
{
    public class PhoneBookEntryViewModel
    {
        public int phonebookentryid { get; set; }
        public int? phonebookid { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public DateTime? datecreated { get; set; }
        public DateTime? datemodified { get; set; }
        public int? active { get; set; }

    }
}