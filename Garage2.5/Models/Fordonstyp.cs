using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Fordonstyp
    {
        [Key]
        public int FordontypId { get; set; }
        public string Typ { get; set; }




        //Navigation property
        public virtual ICollection<Fordon> Fordon { get; set; }

    }
}