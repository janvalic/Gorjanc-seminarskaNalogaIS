
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Gorjanc.Models
{
    public class Oseba : IdentityUser
    {
        public int OsebaId { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public ICollection<Obisk> Obiskani { get; set; }
    }
}