using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser { 
        public List<PortFolio> PortFolios { get; set; } = [];
    }
}
