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
    public class CreateRestaurantTableCommandHandler : IRequestHandler<CreateRestaurantTableCommand, Guid>
    {
        private readonly IRepository<RestaurantTable> _repository;

        public CreateRestaurantTableCommandHandler(IRepository<RestaurantTable> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateRestaurantTableCommand request, CancellationToken cancellationToken)
        {
            //var rt = _repository.GetByFilterAsync(rt => rt.TableNo == request.TableNo);

            //if (rt != null)
            //{
            //    throw new Exception("Aynı Masa Numarası Mevcut");
            //}

            var restaurantTable = new RestaurantTable
            {
                QrUrl = request.QrUrl,
                TableCapacity = request.TableCapacity,
                TableNo = request.TableNo,
                RestaurantId = request.RestaurantId,
            };

            await _repository.CreateAsync(restaurantTable);

            return restaurantTable.Id;
        }
    }
}
