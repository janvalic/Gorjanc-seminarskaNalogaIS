using System;

namespace Gorjanc.Models
{
    public class Obisk
    {
        public int Id { get; set; }
        public int OsebaId { get; set; }
        public int VrhId { get; set; }
        public DateTime Datum { get; set; }

        public Vrh Vrh { get; set; }
        public Oseba Oseba { get; set; }
    }
}