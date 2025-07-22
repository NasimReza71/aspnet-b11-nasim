using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ProductPlus.Commands
{
    public class ProductPlusAddCommandHandler : IRequestHandler<ProductPlusAddCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductPlusAddCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProductPlusAddCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductPlusEntity
            {
                Id = Guid.NewGuid(),
                ProductCode = request.ProductCode,
                ProductName = request.ProductName,
                Category = request.Category,
                PurchasePrice = request.PurchasePrice,
                MRP = request.MRP,
                WholesalePrice = request.WholesalePrice,
                StockQuantity = request.StockQuantity,
                LowStockThreshold = request.LowStockThreshold,
                DamageStock = request.DamageStock,
                ImagePath = request.ProductImage != null ? await SaveProductImageAsync(request.ProductImage) : null
            };

            await _unitOfWork.ProductPlusRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        private async Task<string> SaveProductImageAsync(IFormFile imageFile)
        {
            // Implement image saving logic
            var imagePath = "/images/" + Guid.NewGuid().ToString() + ".jpg"; // Sample image path
            return imagePath;
        }
    }
}
