using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.DAL.Entities
{
    public class Permit : IEntityBase
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermitTypeId { get; set; }
        public virtual PermitType PermitType { get; set; }
        public DateTime PermitDate { get; set; }

    }
}
