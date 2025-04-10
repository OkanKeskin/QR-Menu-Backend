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
    public class CreateRestaurantCommentCommandHandler : IRequestHandler<CreateRestaurantCommentCommands>
    {

        private readonly IRepository<RestaurantComment> _repository;

        public CreateRestaurantCommentCommandHandler(IRepository<RestaurantComment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateRestaurantCommentCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new RestaurantComment
            {
                Comment = request.Comment,
                CustomerId = request.CustomerId,
                RestaurantId = request.RestaurantId,
                CommentStar = request.CommentStar,
                CreatedAt = DateTime.UtcNow
            });
        }
    }
}
