using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers
{
	public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand>
	{
		private readonly IRepository<MenuItem> _repository;

		public CreateMenuItemCommandHandler(IRepository<MenuItem> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new MenuItem
			{
				Name = request.Name,
				Description=request.Description,
				Price=request.Price,
				MenuId=request.MenuId,
				CategoriesId=request.CategoriesId,
				ContentType=request.ContentType,
			});
		}
	}
}
