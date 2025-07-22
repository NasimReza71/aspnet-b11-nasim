using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ProductPlus.Commands
{
    public class ProductPlusDeleteCommandHandler : IRequestHandler<ProductPlusDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductPlusDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProductPlusDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductPlusRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new Exception("Product not found");

            _unitOfWork.ProductPlusRepository.Remove(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
