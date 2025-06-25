using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class AccessSetupDto
    {
        public Guid Id { get; set; }
        public string CompID { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
