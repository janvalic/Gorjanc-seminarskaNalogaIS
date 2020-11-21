using Microsoft.AspNetCore.Identity;

namespace Gorjanc.Models
{
    public class Uporabnik : IdentityUser
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
    }
}
