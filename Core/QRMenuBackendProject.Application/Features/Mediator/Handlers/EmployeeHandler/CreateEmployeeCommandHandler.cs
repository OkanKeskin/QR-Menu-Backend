using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.AccountCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.EmployeeCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.EmployeeHandler
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public CreateEmployeeCommandHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new RestaurantEmployee
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Surname = request.Surname,
                Email = request.Email,
                RestaurantId = request.RestaurantId,
                Position = request.Position,
                TCKN = request.TCKN,
                DateOfStart = request.DateOfStart,
                AccountsId = request.AccountsId,
                Image = null
            };
            await _repository.CreateAsync(emp);
            return emp.Id;
        }
    }
}
