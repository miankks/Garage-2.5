namespace Garage2._5.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._5.DAL.FordonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Garage2._5.DAL.FordonContext";
        }

        protected override void Seed(Garage2._5.DAL.FordonContext context)
        {
            var medlemmar = new[]
           {
                new Medlem { Id=1, F�rNamn="Joackim", EfterNamn="Ericsson" },
                new Medlem { Id=2, F�rNamn="Bilal", EfterNamn="Jan" },
                new Medlem { Id=3, F�rNamn="Eric", EfterNamn="Bj�rn" },
                new Medlem { Id=4, F�rNamn="Mikael", EfterNamn="Gonzales" }
            };

            context.Medlemmar.AddRange(medlemmar);
            context.SaveChanges();
            var fordontyper = new[]
            {
                 new Fordonstyp{  FordontypId=1, Typ="Bil"  },
                 new Fordonstyp{  FordontypId=2, Typ="Lastbil"  },
                 new Fordonstyp{  FordontypId=3, Typ="Motorcykel"  },
                 new Fordonstyp{  FordontypId=4, Typ="Kombi"  },

             };
            context.Fordonstyp.AddRange(fordontyper);
            context.SaveChanges();

            var fordon = new[]
           {
                 new Fordon{ FordonsId=1, FordonstypId= fordontyper[1].FordontypId, M�rke="Volvo", Parkeringtid=DateTime.Now, Regnr="ABC123", MedlemId=medlemmar[1].Id },
                 new Fordon{ FordonsId=2, FordonstypId= fordontyper[2].FordontypId, M�rke="BMW", Parkeringtid=DateTime.Now, Regnr="DEF123", MedlemId=medlemmar[2].Id   },
                 new Fordon{ FordonsId=3, FordonstypId= fordontyper[3].FordontypId, M�rke="Audi", Parkeringtid=DateTime.Now, Regnr="GHQ123", MedlemId=medlemmar[3].Id  },
                 new Fordon{  FordonsId=4, FordonstypId= fordontyper[4].FordontypId, M�rke="Saab", Parkeringtid=DateTime.Now, Regnr="PSD123", MedlemId=medlemmar[4].Id },

             };
            context.Fordon.AddRange(fordon);
            context.SaveChanges();

        }
    }
}
