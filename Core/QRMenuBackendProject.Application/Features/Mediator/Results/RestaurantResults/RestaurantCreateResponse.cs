using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults
{
    public class RestaurantCreateResponse
    {
        public Guid RestaurantId { get; set; }
        public Guid MenuId { get; set; }
    }
}
