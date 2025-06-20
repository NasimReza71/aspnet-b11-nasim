using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.MoneyReceipts.Queries
{
    public class GetMoneyReceiptByIdQueryHandler : IRequestHandler<GetMoneyReceiptByIdQuery, MoneyReceipt>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetMoneyReceiptByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MoneyReceipt> Handle(GetMoneyReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MoneyReceipts.GetByIdAsync(request.Id);
        }
    }

}
