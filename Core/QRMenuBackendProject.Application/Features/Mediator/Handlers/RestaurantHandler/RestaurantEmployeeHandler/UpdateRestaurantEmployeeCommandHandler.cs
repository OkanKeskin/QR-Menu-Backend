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
    public class UpdateRestaurantEmployeeCommandHandler : IRequestHandler<UpdateRestaurantEmployeeCommands>
    {
        private readonly IRepository<RestaurantEmployee> _repository;

        public UpdateRestaurantEmployeeCommandHandler(IRepository<RestaurantEmployee> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRestaurantEmployeeCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.PhoneNumber = request.PhoneNumber;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Position = request.Position;
            await _repository.UpdateAsync(values);
        }
    }
}
