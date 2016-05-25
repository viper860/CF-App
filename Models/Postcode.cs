using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models
{
    public class Postcode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostcodeId { get; set; }
        public string Name { get; set; }
        public string Latitute { get; set; }
        public string Longitudine { get; set; }
        public int Easting { get; set; }
        public int Northing { get; set; }
        public string Grid { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
    }
}
