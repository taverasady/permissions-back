using Permissions.BL.IRepositories;
using Permissions.DAL.Context;
using Permissions.DAL.Entities;

namespace Permissions.BL.Repositories
{
    public class PermitRepository : BaseRepository<Permit>, IPermitRepository
    {
        public PermitRepository(PermissionsContext context)
        : base(context)
        {

        }
    }
}
