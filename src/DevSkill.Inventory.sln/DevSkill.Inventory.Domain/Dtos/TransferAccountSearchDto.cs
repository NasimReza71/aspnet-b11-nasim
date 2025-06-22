using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Dtos
{
    public class TransferAccountSearchDto
    {
        public string FromAccount {  get; set; }
        public string ToAccount { get; set; }

        public string Note { get; set; }

    }
}
