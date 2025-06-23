using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class StaffPaymentSearchDto
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal? Salary { get; set; }
        public int? Attendance { get; set; }

    }

}