using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.RestaurantInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler
{
	public class GetRestaurantByUserIdQueryHandler : IRequestHandler<GetRestaurantByUserIdQuery, List<GetRestaurantByUserIdQueryResult>>
	{
		private readonly IRestaurantRepository _repository;

		public GetRestaurantByUserIdQueryHandler(IRestaurantRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRestaurantByUserIdQueryResult>> Handle(GetRestaurantByUserIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.ListAllRestaurantByUserId(request.UserId);
			return values.Select(x => new GetRestaurantByUserIdQueryResult
			{
				Address = x.Address,
				City = x.City,
				District = x.District,
				Id = x.Id,
				Name = x.Name,
				ContentType = x.ContentType,
			}).ToList();
		}
	}
}
