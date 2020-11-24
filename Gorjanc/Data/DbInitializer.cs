using Gorjanc.Models;
using Gorjanc.Data;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GorjancContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Osebe.Any())
            {
                return;   // DB has been seeded
            }

            var osebe = new Oseba[]
            {
            new Oseba{Ime="Jan",Priimek="Valič"},
            new Oseba{Ime="ŽanLuka",Priimek="Nusdorfer"},
            new Oseba{Ime="Tomi",Priimek="Rupnik"},
            new Oseba{Ime="Tine",Priimek="Premrn"},
            new Oseba{Ime="Patrik",Priimek="Faganel"},
            };
            foreach (Oseba o in osebe)
            {
                context.Osebe.Add(o);
            }
            context.SaveChanges();

            var vrhovi = new Vrh[]
            {
            new Vrh{Ime="Triglav",Visina=2864,KoordinateS=46.37830, KoordinateD=13.83658},
            new Vrh{Ime="Matajur",Visina=1641,KoordinateS=46.21217, KoordinateD=13.5294},
            new Vrh{Ime="Krn",Visina=2244,KoordinateS=46.26622, KoordinateD=13.65888},
            new Vrh{Ime="Grintovec",Visina=2558,KoordinateS=46.35771, KoordinateD=14.53522},
            new Vrh{Ime="Snežnik",Visina=1796,KoordinateS=45.5971013, KoordinateD=14.4482676},
            new Vrh{Ime="Nanos",Visina=1262,KoordinateS=45.77260,KoordinateD=14.05465},
            new Vrh{Ime="Stol",Visina=2236,KoordinateS=46.43400,KoordinateD=14.17364},
            new Vrh{Ime="Rožnik",Visina=393,KoordinateS=46.05527,KoordinateD=14.47718},
            new Vrh{Ime="Cerje",Visina=343,KoordinateS=45.87247,KoordinateD=13.61598},
            new Vrh{Ime="Rogla",Visina=1517,KoordinateS=46.45649,KoordinateD=15.34561},
            new Vrh{Ime="Čaven",Visina=1249,KoordinateS=45.92899,KoordinateD=13.85324},
            new Vrh{Ime="Golica",Visina=1834,KoordinateS=46.49145,KoordinateD=14.05462},
            new Vrh{Ime="Velika Ponca",Visina=2602,KoordinateS=46.44175,KoordinateD=13.82417},
            };
            foreach (Vrh v in vrhovi)
            {
                context.Vrhovi.Add(v);
            }
            context.SaveChanges();

            var obiskani = new Obisk[]
            {
            new Obisk{OsebaId="1",VrhId=1,Datum=DateTime.Parse("28-07-2020")},
            new Obisk{OsebaId="1",VrhId=5,Datum=DateTime.Parse("15-08-2020")},
            new Obisk{OsebaId="1",VrhId=3,Datum=DateTime.Parse("30-08-2020")},
            new Obisk{OsebaId="1",VrhId=2,Datum=DateTime.Parse("30-06-2020")},

            };
            foreach (Obisk ob in obiskani)
            {
                context.Obiskani.Add(ob);
            }
            context.SaveChanges();

            var slike = new Slika[]
            {
            //new Slika{VrhId=5,Img=,DatumSlike=DateTime.Parse("23-05-2020")},
            };
            foreach (Slika s in slike)
            {
                context.Slike.Add(s);
            }
            context.SaveChanges();
        }
    }
}