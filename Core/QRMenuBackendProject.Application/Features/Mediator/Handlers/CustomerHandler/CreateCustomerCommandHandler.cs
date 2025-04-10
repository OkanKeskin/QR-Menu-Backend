using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CompanyCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.CoustomerCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.CoustomerHandler
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {

        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var coustomer = new Customer
            {
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Name = request.Name,
                Email = request.Email,
                AccountsId = request.AccountsId,
                Image = null
            };
            await _repository.CreateAsync(coustomer);
            return coustomer.Id;
        }
    }
}
