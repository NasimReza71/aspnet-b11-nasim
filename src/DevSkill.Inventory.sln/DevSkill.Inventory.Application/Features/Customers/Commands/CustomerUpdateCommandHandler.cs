using DevSkill.Inventory.Application.Exceptions;
using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Customers.Commands
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CustomerUpdateCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork.CustomerRepository.IsEmailDuplicate(request.Email, request.Id))
                throw new DuplicateCustomerEmailException();

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new Exception("Customer not found");

            customer.Name = request.Name;
            customer.Mobile = request.Mobile;
            customer.Address = request.Address;
            customer.Email = request.Email;

            await _unitOfWork.SaveAsync();
        }
    }
}
