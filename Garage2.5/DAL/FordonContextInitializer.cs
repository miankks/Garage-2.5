using Garage2._5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2._5.DAL
{

    internal class FordonContextInitializer : DropCreateDatabaseAlways<FordonContext>
    {
       
        protected override void Seed(FordonContext context)
        {
            var medlemmar = new[]
            {
                new Medlem { Id=1, FörNamn="Joackim", EfterNamn="Ericsson" },
                new Medlem { Id=2, FörNamn="Bilal", EfterNamn="Jan" },
                new Medlem { Id=3, FörNamn="Eric", EfterNamn="Björn" },
                new Medlem { Id=4, FörNamn="Mikael", EfterNamn="Gonzales" }
            };

            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();
            var fordontyper = new[]
            {
                 new Fordonstyp{  FordontypId=1, Typ="Bil"  },
                 new Fordonstyp{  FordontypId=1, Typ="Lastbil"  },
                 new Fordonstyp{  FordontypId=2, Typ="Lastbil"  },
                 new Fordonstyp{  FordontypId=3, Typ="Motorcykel"  },
                 new Fordonstyp{  FordontypId=4, Typ="Kombi"  },

             };
            context.Fordonstyp.AddRange(fordon);
            context.SaveChanges();

            var fordonstyper = new[]
           {
                 new Fordon{ FordonsId=1, FordonstypId= fordon[1].FordontypId, Märke="Volvo", Parkeringtid=DateTime.Now, Regnr="wer123", MedlemId=medlemmar[1].Id },
                 new Fordon{ FordonsId=2, FordonstypId= fordon[2].FordontypId, Märke="Audi", Parkeringtid=DateTime.Now, Regnr="dfg123", MedlemId=medlemmar[2].Id   },
                 new Fordon{ FordonsId=3, FordonstypId= fordon[3].FordontypId, Märke="Saab", Parkeringtid=DateTime.Now, Regnr="nbv123", MedlemId=medlemmar[3].Id  },
                 new Fordon{  FordonsId=4, FordonstypId= fordon[4].FordontypId, Märke="BMW", Parkeringtid=DateTime.Now, Regnr="qaz123", MedlemId=medlemmar[4].Id },

             };
            context.Fordon.AddRange(fordonstyper);
            context.SaveChanges();

        }
    }
}