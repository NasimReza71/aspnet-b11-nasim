using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceSales.Commands
{
    public class UpdateServiceSaleCommandHandler : IRequestHandler<UpdateServiceSaleCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public UpdateServiceSaleCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateServiceSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ServiceSaleRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Service Sale not found");

            entity.InvoiceNo = request.InvoiceNo;
            entity.Date = request.Date;
            entity.CustomerId = request.CustomerId;
            entity.ServiceName = request.ServiceName;
            entity.Total = request.Total;
            entity.Paid = request.Paid;
            entity.Due = request.Due;

            _unitOfWork.ServiceSaleRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
