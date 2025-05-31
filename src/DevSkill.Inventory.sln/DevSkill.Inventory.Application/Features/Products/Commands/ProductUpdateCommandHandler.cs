using DevSkill.Inventory.Application.Exceptions;
using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Products.Commands
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductUpdateCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.ProductRepository.IsNameDuplicate(request.Name, request.Id))
                throw new DuplicateProductNameException();

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Product not found");

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.ManufactureDate = request.ManufactureDate;

            await _unitOfWork.SaveAsync();
        }
    }
}
