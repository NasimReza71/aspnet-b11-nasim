using DevSlkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSlkill.Inventory.Application.Features.Products.Commands
{
    public class ProductAddCommand : IRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
