using Permissions.BL.IRepositories;
using Permissions.DAL.Context;
using Permissions.DAL.Entities;

namespace Permissions.BL.Repositories
{
    public class PermitTypeRepository : BaseRepository<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(PermissionsContext context)
        : base(context)
        {

        }
    }
}
