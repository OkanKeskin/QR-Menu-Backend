using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantCommentResult
{
    public class GetRestaurantCommentByRestaurantIdQueryResult
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public int CommentStar { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
