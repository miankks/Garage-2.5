using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Fordon
    {
        public int FordonId { get; set; }
        public string Regnr { get; set; }
        public string Märke { get; set; }
        public int AntalHjul { get; set; }
        public DateTime Parkeringtid { get; set; }

        //Navigation property
        public virtual ICollection<Fordonstyp> Fordontyps { get; set; }
        public virtual ICollection<Medlem> Medlemar { get; set; }

    }
}