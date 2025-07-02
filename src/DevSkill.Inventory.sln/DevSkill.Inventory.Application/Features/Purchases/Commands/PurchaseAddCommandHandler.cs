using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Purchases.Commands
{
    public class PurchaseAddCommandHandler : IRequestHandler<PurchaseAddCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public PurchaseAddCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PurchaseAddCommand request, CancellationToken cancellationToken)
        {
            var entity = new Purchase
            {
                Id = Guid.NewGuid(),
                PurchaseInvoice = request.PurchaseInvoice,
                Date = request.Date,
                Name = request.Name,
                Products = request.Products,
                Quantity = request.Quantity,
                TotalAmount = request.TotalAmount,
                Paid = request.Paid,
                Due = request.Due
            };
            await _unitOfWork.PurchaseRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }

}
