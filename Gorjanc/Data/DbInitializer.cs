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
            new Vrh{Ime="Kucelj",Visina=1237,KoordinateS=45.92874,KoordinateD=13.8247},
            new Vrh{Ime="Sinji Vrh",Visina=1002,KoordinateS=45.90830,KoordinateD=13.93732},
            new Vrh{Ime="Kovk",Visina=961,KoordinateS=45.88795,KoordinateD=13.96906},
            new Vrh{Ime="Gradiška Tura",Visina=793,KoordinateS=45.83091,KoordinateD=13.98315},
            new Vrh{Ime="Kucelj",Visina=1237,KoordinateS=45.92874,KoordinateD=13.8247},
            new Vrh{Ime="Otliško okno",Visina=847,KoordinateS=45.9162,KoordinateD=13.9157},
            new Vrh{Ime="Mangart",Visina=2677,KoordinateS=46.43946,KoordinateD=13.65465},
            new Vrh{Ime="Tošč",Visina=1021,KoordinateS=46.09741,KoordinateD=14.32127},
            new Vrh{Ime="Blegoš",Visina=646,KoordinateS=46.22394,KoordinateD=14.23852},
            new Vrh{Ime="Porezen",Visina=1632,KoordinateS=46.17716,KoordinateD=13.97430},
            new Vrh{Ime="Rodica",Visina=1963,KoordinateS=46.22770,KoordinateD=13.86523},
            new Vrh{Ime="Vogel",Visina=1922,KoordinateS=46.23832,KoordinateD=13.8125},
            new Vrh{Ime="Vrh nad Škrbino",Visina=2054,KoordinateS=46.25446,KoordinateD=13.78006},
            new Vrh{Ime="Krasji vrh",Visina=1768,KoordinateS=46.28932,KoordinateD=13.59232},
            new Vrh{Ime="Veliki vrh",Visina=1446,KoordinateS=46.21496,KoordinateD=13.53934},
            new Vrh{Ime="Rombon",Visina=2208,KoordinateS=46.36730,KoordinateD=13.55440},
            new Vrh{Ime="Svinjak",Visina=1653,KoordinateS=46.35042,KoordinateD=13.61079},
            new Vrh{Ime="Nizki vrh",Visina=2162,KoordinateS=46.39317,KoordinateD=13.67001},
            new Vrh{Ime="Travnik",Visina=2378,KoordinateS=46.42903,KoordinateD=13.71282},
            new Vrh{Ime="Bavški Grintavec",Visina=2347,KoordinateS=46.36900,KoordinateD=13.67026},
            new Vrh{Ime="Goličica",Visina=2395,KoordinateS=46.42037,KoordinateD=13.68424},
            new Vrh{Ime="Zadnjiški Ozebnik",Visina=2083,KoordinateS=46.36909,KoordinateD=13.78233},
            new Vrh{Ime="Lopič",Visina=1858,KoordinateS=46.38491,KoordinateD=13.49948},
            new Vrh{Ime="Velika Baba",Visina=2013,KoordinateS=46.29462,KoordinateD=13.70827},
            new Vrh{Ime="Strma Peč",Visina=2165,KoordinateS=44.19367,KoordinateD=10.70028},
            new Vrh{Ime="Montaž",Visina=2754,KoordinateS=46.43576,KoordinateD=13.43392},
            new Vrh{Ime="Kopa",Visina=1360,KoordinateS=46.16326,KoordinateD=13.00439},
            new Vrh{Ime="Jalovec",Visina=2645,KoordinateS=46.42156,KoordinateD=13.68003},
            new Vrh{Ime="Prisank",Visina=2547,KoordinateS=46.42470,KoordinateD=13.76971},
            new Vrh{Ime="Razor",Visina=1702,KoordinateS=46.43114,KoordinateD=13.58239},
            new Vrh{Ime="Špik",Visina=2005,KoordinateS=46.35302,KoordinateD=13.88384},
            new Vrh{Ime="Kurji vrh",Visina=1762,KoordinateS=46.46637,KoordinateD=13.80529},
            new Vrh{Ime="Vršič",Visina=1897,KoordinateS=46.29686,KoordinateD=13.63342},
            new Vrh{Ime="Vrtaško Sleme",Visina=2077,KoordinateS=46.45181,KoordinateD=13.87178},
            new Vrh{Ime="Kukova špica",Visina=2427,KoordinateS=46.44753,KoordinateD=13.85481},
            new Vrh{Ime="Škrlatica",Visina=2740,KoordinateS=46.43281,KoordinateD=13.82096},
            new Vrh{Ime="Rjavina",Visina=2532,KoordinateS=46.39190,KoordinateD=13.88084},
            new Vrh{Ime="Črna Prst",Visina=1959,KoordinateS=46.29972,KoordinateD=13.70487},
            new Vrh{Ime="Mišelj vrh",Visina=2349,KoordinateS=46.35628,KoordinateD=13.83806},
            new Vrh{Ime="Škednjovec",Visina=2158,KoordinateS=46.34945,KoordinateD=13.82604},
            new Vrh{Ime="Debeli vrh",Visina=1255,KoordinateS=46.47550,KoordinateD=13.65592},
            new Vrh{Ime="Viševnik",Visina=2050,KoordinateS=46.35898,KoordinateD=13.89824},
            new Vrh{Ime="Mali Draški vrh",Visina=2132,KoordinateS=46.36297,KoordinateD=13.89157},
            new Vrh{Ime="Veliki Draški vrh",Visina=2240,KoordinateS=46.36020,KoordinateD=13.87578},
            new Vrh{Ime="Tosc",Visina=2273,KoordinateS=46.35672,KoordinateD=13.86827},
            new Vrh{Ime="Maloško Poldne",Visina=1823,KoordinateS=46.52283,KoordinateD=13.88204},
            new Vrh{Ime="Trupejevo Poldne",Visina=1931,KoordinateS=46.51534,KoordinateD=13.86064},
            new Vrh{Ime="Kepa",Visina=2145,KoordinateS=46.50736,KoordinateD=13.95252},
            new Vrh{Ime="Struška",Visina=1944,KoordinateS=46.47274,KoordinateD=13.12287},
            new Vrh{Ime="Vajnež",Visina=2104,KoordinateS=46.44307,KoordinateD=13.15121},
            new Vrh{Ime="Vrtača",Visina=2180,KoordinateS=46.43995,KoordinateD=13.21258},
            new Vrh{Ime="Palec",Visina=2026,KoordinateS=46.44324,KoordinateD=13.21896},
            new Vrh{Ime="Košutica",Visina=1968,KoordinateS=46.43882,KoordinateD=13.29890},
            new Vrh{Ime="Storžič",Visina=2132,KoordinateS=46.35021,KoordinateD=13.40482},
            new Vrh{Ime="Križna gora",Visina=1162,KoordinateS=45.87240,KoordinateD=14.05377},
            new Vrh{Ime="Stegovnik",Visina=1692,KoordinateS=46.39544,KoordinateD=14.41996},
            new Vrh{Ime="Javorov vrh",Visina=1427,KoordinateS=46.32455,KoordinateD=14.46386},
            new Vrh{Ime="Kozji vrh",Visina=1628,KoordinateS=46.36462,KoordinateD=14.44613},
            new Vrh{Ime="Virnikov Grintovec",Visina=1649,KoordinateS=46.41340,KoordinateD=14.47928},
            new Vrh{Ime="Kočna",Visina=2520,KoordinateS=46.35715,KoordinateD=14.51987},
            new Vrh{Ime="Kamniški vrh",Visina=1259,KoordinateS=46.28793,KoordinateD=14.57981},
            new Vrh{Ime="Kalški greben",Visina=2224,KoordinateS=46.33148,KoordinateD=14.53767},
            new Vrh{Ime="Grintovec",Visina=2558,KoordinateS=46.35771,KoordinateD=14.53522},
            new Vrh{Ime="Skuta",Visina=2532,KoordinateS=46.36326,KoordinateD=14.55774},
            new Vrh{Ime="Turska gora",Visina=2251,KoordinateS=46.36030,KoordinateD=14.57721},
            new Vrh{Ime="Ojstrica",Visina=2350,KoordinateS=46.36392,KoordinateD=14.63724},
            new Vrh{Ime="Konj",Visina=1818,KoordinateS=46.33094,KoordinateD=14.63756},
            new Vrh{Ime="Mrzla gora",Visina=2203,KoordinateS=46.37719,KoordinateD=14.57835},
            new Vrh{Ime="Strelovec",Visina=1763,KoordinateS=46.39450,KoordinateD=14.65818},
            new Vrh{Ime="Govca",Visina=1929,KoordinateS=46.44958,KoordinateD=14.68557},
            new Vrh{Ime="Raduha",Visina=2062,KoordinateS=46.40986,KoordinateD=14.73768},
            new Vrh{Ime="Mali Rogatec",Visina=892,KoordinateS=45.84849,KoordinateD=14.12339},
            new Vrh{Ime="Veliki Rogatec",Visina=1557,KoordinateS=46.31971,KoordinateD=14.74077},
            new Vrh{Ime="Lepenatka",Visina=1425,KoordinateS=46.30990,KoordinateD=14.74044},
            new Vrh{Ime="Dleskovec",Visina=1967,KoordinateS=46.35391,KoordinateD=14.68224},
            new Vrh{Ime="Deska",Visina=1978,KoordinateS=46.34531,KoordinateD=14.66000},
            new Vrh{Ime="Lastovec",Visina=1840,KoordinateS=46.33692,KoordinateD=14.66034},
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