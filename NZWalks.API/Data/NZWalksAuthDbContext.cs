using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "9a9467c7-e557-483b-9a4b-902cc3d9f1aa";
            var writerRoleId = "f7fd4c2e-2e4b-45c2-a66a-a8aa99093fb5";

            var roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id  = readerRoleId,
                        ConcurrencyStamp = readerRoleId,
                        Name = "Reader",
                        NormalizedName = "READER"
                    },
                    new IdentityRole
                    {
                        Id  = writerRoleId,
                        ConcurrencyStamp = writerRoleId,
                        Name = "Writer",
                        NormalizedName = "WRITER"
                    },
                };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
