using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.DAL.Entities
{
    public class PermitType : IEntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
