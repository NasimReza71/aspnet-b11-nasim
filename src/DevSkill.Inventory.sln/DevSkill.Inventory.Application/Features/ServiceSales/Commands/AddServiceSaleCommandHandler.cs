using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.ServiceSales.Commands
{
    public class AddServiceSaleCommandHandler : IRequestHandler<AddServiceSaleCommand, Guid>

    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public AddServiceSaleCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddServiceSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = new ServiceSale
            {
                InvoiceNo = request.InvoiceNo,
                Date = request.Date,
                CustomerId = request.CustomerId,
                ServiceName = request.ServiceName,
                Total = request.Total,
                Paid = request.Paid,
                Due = request.Due
            };

            await _unitOfWork.ServiceSaleRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity.Id;
        }

    }

}
