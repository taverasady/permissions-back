using Permissions.DAL.Context;
using Permissions.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permissions.DAL.DataSeeder
{
    public class DataSeeder
    {
        public static void Initialize(PermissionsContext context)
        {
            if (!context.PermitsTypes.Any())
            {
                var permitTypes = new List<PermitType>()
                {
                    new PermitType { Description = "Enfermedad"},
                    new PermitType { Description = "Diligencia"},
                    new PermitType { Description = "Etc"}
                };
                context.PermitsTypes.AddRange(permitTypes);
                context.SaveChanges();
            }
        }
    }
}
