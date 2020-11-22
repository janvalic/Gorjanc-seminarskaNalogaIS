using System;
using System.Collections.Generic;

namespace Gorjanc.Models
{
    public class Slika
    {
        public int SlikaId { get; set; }
        public string Ime { get; set; }
        public int VrhId { get; set; }
        public byte[] Img { get; set; }
        public DateTime DatumSlike { get; set; }
        
    }
}