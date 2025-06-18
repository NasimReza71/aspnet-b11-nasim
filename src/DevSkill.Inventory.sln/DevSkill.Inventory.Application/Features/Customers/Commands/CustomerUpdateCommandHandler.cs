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
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new Exception("Customer not found");

            customer.CustomerCode = request.CustomerCode;
            customer.Name = request.Name;
            customer.Mobile = request.Mobile;
            customer.Address = request.Address;
            customer.Email = request.Email;
            customer.CurrentBalance = request.CurrentBalance;
            customer.Status = request.Status;
            

            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.SaveAsync();

            
        }
    }
}
