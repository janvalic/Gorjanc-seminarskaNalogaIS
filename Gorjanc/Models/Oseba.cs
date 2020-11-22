
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Gorjanc.Models
{
    public class Oseba : IdentityUser
    {
        public override string Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public ICollection<Obisk> Obiskani { get; set; }
    }
}