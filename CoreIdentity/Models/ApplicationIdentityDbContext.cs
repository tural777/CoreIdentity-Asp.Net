using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Models
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options)
        {

        }
    }
}
