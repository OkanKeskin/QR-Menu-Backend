using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.FavoriteRestaurantResults
{
	public class GetFavoriteRestaurantResult
	{
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
		public string CustomerName { get; set; }
		public Guid RestaurantId { get; set; }
		public string RestaurantName { get; set; }
	}
}
