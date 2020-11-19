using System;

namespace Gorjanc.Models
{
    public class Obiskani
    {
        public int Id { get; set; }
        public int OsebaId { get; set; }
        public int VrhId { get; set; }
        public DateTime Datum { get; set; }

    }
}