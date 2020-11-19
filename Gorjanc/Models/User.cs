using Microsoft.AspNetCore.Identity;
namespace Gorjanc.M
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}