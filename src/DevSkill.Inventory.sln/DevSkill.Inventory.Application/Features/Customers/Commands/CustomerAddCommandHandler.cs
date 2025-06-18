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
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerCode = request.CustomerCode,
                Name = request.Name,
                Mobile = request.Mobile,
                Address = request.Address,
                Email = request.Email,
                CurrentBalance = request.CurrentBalance,
                Status = request.Status
            };

            await _unitOfWork.CustomerRepository.AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }
    }
}
