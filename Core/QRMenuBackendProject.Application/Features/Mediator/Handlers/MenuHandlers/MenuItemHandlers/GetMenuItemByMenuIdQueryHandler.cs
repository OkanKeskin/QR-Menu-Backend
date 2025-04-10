using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers
{
    public class GetMenuItemByMenuIdQueryHandler : IRequestHandler<GetMenuItemByMenuIdQuery, List<GetMenuItemByMenuIdQueryResult>>
    {
        private readonly IRepository<MenuItem> _repository;

        public GetMenuItemByMenuIdQueryHandler(IRepository<MenuItem> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetMenuItemByMenuIdQueryResult>> Handle(GetMenuItemByMenuIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterListAsync(mi=>mi.MenuId == request.MenuId);
            return values.Select(x => new GetMenuItemByMenuIdQueryResult
            {
               CategoriesId = x.CategoriesId,
               Description = x.Description,
               Id = x.Id,
               MenuId = x.MenuId,
               Name = x.Name,
               Price = x.Price
            }).ToList();
        }
    }
}
