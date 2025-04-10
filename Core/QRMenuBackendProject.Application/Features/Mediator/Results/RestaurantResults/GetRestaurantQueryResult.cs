using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults
{
    public class GetRestaurantQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
	}
}
