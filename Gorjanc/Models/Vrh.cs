
using System.Collections.Generic;

namespace Gorjanc.Models
{
    public class Vrh
    {
        public int VrhId { get; set; }
        public string Ime { get; set; }
        public int Visina { get; set; }
        public double KoordinateS { get; set; }
        public double KoordinateD { get; set; }
        public ICollection<Obisk> Obiskani { get; set; }
        public ICollection<Slika> Slika { get; set; }
    }
}