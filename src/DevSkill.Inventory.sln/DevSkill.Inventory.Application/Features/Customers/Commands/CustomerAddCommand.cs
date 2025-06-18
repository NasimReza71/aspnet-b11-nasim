using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Customers.Commands
{
    public class CustomerAddCommand : IRequest
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Status { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
