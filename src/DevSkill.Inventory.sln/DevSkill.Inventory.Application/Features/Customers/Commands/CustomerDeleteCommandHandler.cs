using DevSkill.Inventory.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Application.Features.Customers.Commands
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CustomerDeleteCommandHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                throw new Exception("Customer not found");

            _unitOfWork.CustomerRepository.Remove(customer);
            await _unitOfWork.SaveAsync();
        }
    }
}
