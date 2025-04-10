using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler
{
    public class RemoveRestaurantCommandHandler : IRequestHandler<RemoveRestaurantCommand>
    {
        private readonly IRepository<Restaurant> _repository;

        public RemoveRestaurantCommandHandler(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRestaurantCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
