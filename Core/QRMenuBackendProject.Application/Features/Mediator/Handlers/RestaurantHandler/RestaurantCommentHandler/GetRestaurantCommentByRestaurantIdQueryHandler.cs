using MediatR;
using Microsoft.IdentityModel.Tokens;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantCommentQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantCommentResult;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.RestaurantHandler.RestaurantCommentHandler
{
    public class GetRestaurantCommentByRestaurantIdQueryHandler : IRequestHandler<GetRestaurantCommentByRestaurantIdQuery, List<GetRestaurantCommentByRestaurantIdQueryResult>>
    {
        private readonly IRepository<RestaurantComment> _repositoryComment;
        private readonly IRepository<Customer> _repositoryCustomer;

        public GetRestaurantCommentByRestaurantIdQueryHandler(IRepository<RestaurantComment> repositoryComment, IRepository<Customer> repositoryCustomer)
        {
            _repositoryComment = repositoryComment;
            _repositoryCustomer = repositoryCustomer;
        }

        public async Task<List<GetRestaurantCommentByRestaurantIdQueryResult>> Handle(GetRestaurantCommentByRestaurantIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repositoryComment.GetAllAsync();
            var filteredValues = values.Where(c => c.RestaurantId == request.Id)
                .OrderByDescending(c => c.CreatedAt)
                .ToList(); // ToList() ile filtrelenmiş ve sıralanmış verileri liste olarak alıyoruz

            var result = new List<GetRestaurantCommentByRestaurantIdQueryResult>();

            foreach(var value in filteredValues)
            {
                var user = await _repositoryCustomer.GetByIdAsync(value.CustomerId);
                var item = new GetRestaurantCommentByRestaurantIdQueryResult
                {
                    Comment = value.Comment,
                    CustomerName = user.Name + " " + user.Surname,
                    Id = value.Id,
                    CommentStar = value.CommentStar,
                    CreateDate = value.CreatedAt
                };
                result.Add(item);
            }

            return result;

        }
    }
}
