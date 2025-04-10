using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler
{
	public class RemoveOrdersHandler : IRequestHandler<RemoveOrdersCommand>
	{
		private readonly IRepository<Orders> _repository;

		public RemoveOrdersHandler(IRepository<Orders> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrdersCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
