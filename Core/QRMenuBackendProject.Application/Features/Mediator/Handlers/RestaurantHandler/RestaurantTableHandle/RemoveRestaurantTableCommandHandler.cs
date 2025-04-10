using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantTableHandle
{
    public class RemoveRestaurantTableCommandHandler : IRequestHandler<RemoveRestaurantTableCommand, Guid>
    {
        private readonly IRepository<RestaurantTable> _repository;

        public RemoveRestaurantTableCommandHandler(IRepository<RestaurantTable> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(RemoveRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);

            return value.Id;
        }
    }
}
