using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Products.Commands
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public ProductAddCommandHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public async Task Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
           await  _applicationUnitOfWork.ProductRepository.AddAsync(new Product 
           { 
               Name = request.Name,
               Price = request.Price,
               Description = request.Description,
               ManufactureDate = request.ManufactureDate

           });
            await _applicationUnitOfWork.SaveAsync();
        }
              
    }
}
