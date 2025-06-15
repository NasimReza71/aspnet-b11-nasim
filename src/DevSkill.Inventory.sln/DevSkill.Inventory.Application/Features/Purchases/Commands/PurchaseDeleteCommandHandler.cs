using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Purchases.Commands
{
    public class PurchaseDeleteCommandHandler : IRequestHandler<PurchaseDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public PurchaseDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PurchaseDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PurchaseRepository.GetByIdAsync(request.Id);
            if (entity == null) throw new Exception("Purchase not found");

            _unitOfWork.PurchaseRepository.Remove(entity);
            await _unitOfWork.SaveAsync();
        }
    }

}
