using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Fordonstyp
    {
        public int FordontypId { get; set; }
        public string Typ { get; set; }




        //Navigation property
        public virtual ICollection<Fordon> 

    }
}