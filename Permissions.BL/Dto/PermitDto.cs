using System;

namespace Permissions.BL.Dto
{
    public class PermitDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermitTypeId { get; set; }
        public virtual PermitTypeDto PermitType { get; set; }
        public DateTime PermitDate { get; set; }

    }
}
