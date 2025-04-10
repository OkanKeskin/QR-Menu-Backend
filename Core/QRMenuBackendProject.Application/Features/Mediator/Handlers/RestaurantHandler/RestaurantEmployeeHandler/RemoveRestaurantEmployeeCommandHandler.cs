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
    public class RemoveRestaurantEmployeeCommandHandler : IRequestHandler<RemoveRestaurantEmployeeCommands>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public RemoveRestaurantEmployeeCommandHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRestaurantEmployeeCommands request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
