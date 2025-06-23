using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class StaffDto
    {
        public string StaffNumber { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
    }
}
