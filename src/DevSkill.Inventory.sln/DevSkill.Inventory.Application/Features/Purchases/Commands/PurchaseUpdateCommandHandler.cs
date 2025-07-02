using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Purchases.Commands
{
    public class PurchaseUpdateCommandHandler : IRequestHandler<PurchaseUpdateCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public PurchaseUpdateCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PurchaseUpdateCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _unitOfWork.PurchaseRepository.GetByIdAsync(request.Id);
            if (purchase == null) throw new Exception("Purchase not found");

            purchase.PurchaseInvoice = request.PurchaseInvoice;
            purchase.Date = request.Date;
            purchase.Name = request.Name;
            purchase.Products = request.Products;
            purchase.Quantity = request.Quantity;
            purchase.TotalAmount = request.TotalAmount;
            purchase.Paid = request.Paid;
            purchase.Due = request.Due;

            await _unitOfWork.SaveAsync();
        }
    }

}
