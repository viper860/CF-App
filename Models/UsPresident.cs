using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Models
{
    public class UsPresident
    {
        [Key]
        public int PresidencyId { get; set; }
        public string President { get; set; }
        public string WikipediaEntry { get; set; }
        public DateTime TookOffice { get; set; }
        public DateTime LeftOffice { get; set; }
        public string Party { get; set; }
        public string Portrait { get; set; }
        public string Thumbnail { get; set; }
        public string HomesState { get; set; }
    }
}
