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
            new Vrh{Ime="Triglav",Visina=2864,KoordinateS=46.3792009, KoordinateD=13.8341977},
            new Vrh{Ime="Matajur",Visina=1641,KoordinateS=46.2120837, KoordinateD=13.5298624},
            new Vrh{Ime="Krn",Visina=2244,KoordinateS=46.2657651, KoordinateD=13.6592533},
            new Vrh{Ime="Grintovec",Visina=2558,KoordinateS=46.3502114, KoordinateD=14.5260124},
            new Vrh{Ime="Snežnik",Visina=1796,KoordinateS=45.5971013, KoordinateD=14.4482676},
            };
            foreach (Vrh v in vrhovi)
            {
                context.Vrhovi.Add(v);
            }
            context.SaveChanges();

            var obiskani = new Obisk[]
            {
            new Obisk{OsebaId=1,VrhId=1,Datum=DateTime.Parse("28-07-2020")},
            new Obisk{OsebaId=1,VrhId=5,Datum=DateTime.Parse("15-08-2020")},
            new Obisk{OsebaId=1,VrhId=3,Datum=DateTime.Parse("30-08-2020")},
            new Obisk{OsebaId=2,VrhId=2,Datum=DateTime.Parse("30-06-2020")},
            new Obisk{OsebaId=2,VrhId=3,Datum=DateTime.Parse("06-07-2020")},
            new Obisk{OsebaId=2,VrhId=4,Datum=DateTime.Parse("19-07-2020")},
            new Obisk{OsebaId=3,VrhId=5,Datum=DateTime.Parse("16-08-2020")},
            new Obisk{OsebaId=4,VrhId=1,Datum=DateTime.Parse("28-07-2020")},
            new Obisk{OsebaId=4,VrhId=3,Datum=DateTime.Parse("21-08-2020")},
            new Obisk{OsebaId=4,VrhId=3,Datum=DateTime.Parse("05-09-2020")},
            new Obisk{OsebaId=4,VrhId=4,Datum=DateTime.Parse("11-09-2020")},
            new Obisk{OsebaId=4,VrhId=1,Datum=DateTime.Parse("25-09-2020")},
            new Obisk{OsebaId=5,VrhId=2,Datum=DateTime.Parse("14-05-2020")},
            new Obisk{OsebaId=5,VrhId=5,Datum=DateTime.Parse("23-05-2020")},

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