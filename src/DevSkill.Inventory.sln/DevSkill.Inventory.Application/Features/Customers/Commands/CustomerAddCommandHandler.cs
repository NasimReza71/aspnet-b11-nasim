using DevSkill.Inventory.Application.Exceptions;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Customers.Commands
{
    public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CustomerAddCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.CustomerRepository.IsEmailDuplicate(request.Email))
                throw new DuplicateCustomerEmailException();

            await _unitOfWork.CustomerRepository.AddAsync(new Customer
            {
                Name = request.Name,
                Mobile = request.Mobile,
                Address = request.Address,
                Email = request.Email,
                Status = "Active"
            });

            await _unitOfWork.SaveAsync();
        }
    }
}
