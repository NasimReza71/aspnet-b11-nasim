using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class StaffPaymentDto
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal Salary { get; set; }
        public int Attendance { get; set; }
        public decimal Advance { get; set; }
        public decimal Payment { get; set; }
        public string Note { get; set; }
    }
}
