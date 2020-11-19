
using System.Collections.Generic;

namespace Gorjanc.Models
{
    public class Oseba
    {
        public int OsebaId { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public ICollection<Obisk> Obiskani { get; set; }
    }
}