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
    public class UpdateRestaurantTableCommandHandler : IRequestHandler<UpdateRestaurantTableCommand, Guid>
    {
        private readonly IRepository<RestaurantTable> _repository;

        public UpdateRestaurantTableCommandHandler(IRepository<RestaurantTable> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(UpdateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.TableCapacity = request.TableCapacity;
            values.TableNo = request.TableNo;

            await _repository.UpdateAsync(values);
            return values.Id;
        }
    }
}
