using Microsoft.EntityFrameworkCore;
using Permissions.DAL.Entities;

namespace Permissions.DAL.Context
{
    public class PermissionsContext : DbContext
    {
        public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options)
        {

        }
        public DbSet<PermitType> PermitsTypes { get; set; }
        public DbSet<Permit> Permits { get; set; }
    }
}
