using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Exceptions
{
    public class DuplicateCustomerEmailException : Exception
    {
        public DuplicateCustomerEmailException()
            : base("Duplicate email found for customer.")
        {
        }
    }
}
