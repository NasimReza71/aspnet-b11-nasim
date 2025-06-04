using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Products.Commands
{
    public class ProductAddCommand : IRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public DateTime ManufactureDate { get; set; }

    }
}
