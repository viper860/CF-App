using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }
        public int SortOrder { get; set; }
        public string CommonName { get; set; }
        public string FormalName { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Sovereignty { get; set; }
        public string Capital { get; set; }
        public string ISO_4217_Currency_Code { get; set; }
        public string ISO_4217_Currency_Name { get; set; }
        public string ITU_Phone_Code { get; set; }
        public string ISO_3166_2_Letter_Code { get; set; }
        public string ISO_3166_3_Letter_Code { get; set; }
        public string ISO_3166_Number { get; set; }
        public string IANA_Country_Code_TLD { get; set; }
    }
}
