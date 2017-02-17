using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Medlem
    {
        public int MedlemsId { get; set; }
        public string FörNamn { get; set; }
        public string EfterNamn { get; set; }

        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }
    }
}