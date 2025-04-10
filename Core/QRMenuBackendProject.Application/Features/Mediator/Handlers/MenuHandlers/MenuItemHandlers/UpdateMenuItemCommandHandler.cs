using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers
{
	public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand>
	{
		private readonly IRepository<MenuItem> _repository;

		public UpdateMenuItemCommandHandler(IRepository<MenuItem> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			values.Name = request.Name;
			values.Description = request.Description;
			values.Price = request.Price;
			values.MenuId = request.MenuId;
			values.CategoriesId = request.CategoriesId;
			values.ContentType = request.ContentType;
			await _repository.UpdateAsync(values);
		}
	}
}
