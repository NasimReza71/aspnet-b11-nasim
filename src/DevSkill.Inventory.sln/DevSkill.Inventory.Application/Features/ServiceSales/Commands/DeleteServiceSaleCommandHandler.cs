using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceSales.Commands
{
    public class DeleteServiceSaleCommandHandler : IRequestHandler<DeleteServiceSaleCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public DeleteServiceSaleCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteServiceSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ServiceSaleRepository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new Exception("Service Sale not found");

            _unitOfWork.ServiceSaleRepository.Remove(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
