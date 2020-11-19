
using System.Collections.Generic;

namespace Gorjanc.Models
{
    public class Vrh
    {
        public int VrhId { get; set; }
        public string Ime { get; set; }
        public int Visina { get; set; }
        public double Koordinate { get; set; }
        public ICollection<Obiskani> Obiskani { get; set; }
        public ICollection<Slika> Slika { get; set; }
    }
}