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
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
    {
        private readonly IRepository<Restaurant> _repository;

        public UpdateRestaurantCommandHandler(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.City = request.City;
            values.Address = request.Address;
            values.Name = request.Name;
            values.District = request.District;
            values.ContentType = request.ContentType;
            await _repository.UpdateAsync(values);
        }
    }
}
