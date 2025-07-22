using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ProductPlus.Commands
{
    public class ProductPlusUpdateCommandHandler : IRequestHandler<ProductPlusUpdateCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductPlusUpdateCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProductPlusUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductPlusRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Product not found");

            product.ProductCode = request.ProductCode;
            product.ProductName = request.ProductName;
            product.Category = request.Category;
            product.PurchasePrice = request.PurchasePrice;
            product.MRP = request.MRP;
            product.WholesalePrice = request.WholesalePrice;
            product.StockQuantity = request.StockQuantity;
            product.LowStockThreshold = request.LowStockThreshold;
            product.DamageStock = request.DamageStock;

            if (!string.IsNullOrEmpty(request.ProductImagePath))
            {
                product.ImagePath = request.ProductImagePath;
            }

            _unitOfWork.ProductPlusRepository.Update(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
