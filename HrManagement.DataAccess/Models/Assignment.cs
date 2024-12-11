using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrManagement.DataAccess.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Role { get; set; } = "";

        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}