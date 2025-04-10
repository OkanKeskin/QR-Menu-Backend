using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantCommentCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantCommentHandler
{
    public class RemoveRestaurantCommentCommandHandler : IRequestHandler<RemoveRestaurantCommentCommands>
    {
        private readonly IRepository<RestaurantComment> _repository;

        public RemoveRestaurantCommentCommandHandler(IRepository<RestaurantComment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveRestaurantCommentCommands request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
