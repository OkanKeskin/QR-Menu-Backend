using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantEmployeeCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantEmployeeHandler
{
    public class CreateRestaurantEmployeeCommandHandler : IRequestHandler<CreateRestaurantEmployeeCommands>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public CreateRestaurantEmployeeCommandHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRestaurantEmployeeCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new RestaurantEmployee
            {
                DateOfStart = DateTime.Now,
                //NameSurname = request.NameSurname,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                RestaurantId = request.RestaurantId
            });
        }
    }
}
