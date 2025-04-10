using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, RestaurantCreateResponse>
    {
        private readonly IRepository<Restaurant> _repository;
        private readonly IRepository<Menu> _menuRepository;

        public CreateRestaurantCommandHandler(IRepository<Restaurant> repository, IRepository<Menu> menuRepository)
        {
            _repository = repository;
            _menuRepository = menuRepository;
        }

        public async Task<RestaurantCreateResponse> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var newRestaurant = new Restaurant
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                District = request.District,
                ContentType = request.ContentType,
                AccountsId = request.AccountsId,
            };

            await _repository.CreateAsync(newRestaurant);
            
            var restaurantMenu = new Menu
            {
                Name = newRestaurant.Name + " " + "Menu",
                RestaurantId = newRestaurant.Id,
            };

            await _menuRepository.CreateAsync(restaurantMenu);
        
            return new RestaurantCreateResponse
            {
                MenuId = restaurantMenu.Id,
                RestaurantId = newRestaurant.Id
            };
        }
    }
}
