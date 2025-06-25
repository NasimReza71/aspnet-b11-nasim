using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.AccessSetups
{
    public class GetAccessSetupByIdQueryHandler : IRequestHandler<GetAccessSetupByIdQuery, AccessSetup>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetAccessSetupByIdQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AccessSetup> Handle(GetAccessSetupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AccessSetupRepository.GetByIdAsync(request.Id);
        }
    }
}
