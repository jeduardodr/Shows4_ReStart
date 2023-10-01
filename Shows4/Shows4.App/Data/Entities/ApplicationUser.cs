using Microsoft.AspNetCore.Identity;

namespace Shows4.App.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public bool Administrator { get; set; }
    }
}
