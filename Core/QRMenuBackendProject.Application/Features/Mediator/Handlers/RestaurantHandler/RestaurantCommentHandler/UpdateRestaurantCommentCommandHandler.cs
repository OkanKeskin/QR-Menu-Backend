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
    public class UpdateRestaurantCommentCommandHandler : IRequestHandler<UpdateRestaurantCommentCommands>
    {
        private readonly IRepository<RestaurantComment> _repository;

        public UpdateRestaurantCommentCommandHandler(IRepository<RestaurantComment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateRestaurantCommentCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Comment = request.Comment;
            await _repository.UpdateAsync(values);
        }
    }
}
