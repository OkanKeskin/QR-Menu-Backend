using QRMenuBackendProject.Domain.Entities.Base;
using QRMenuBackendProject.Domain.Enums;

namespace QRMenuBackendProject.Domain.Entities
{
	public class Orders : AuditableEntity
	{
		public RestaurantTable RestaurantTable { get; set; }
		public Guid RestaurantTableId { get; set; }		
		public PaymentType PaymentType { get; set; }
		public bool Paid { get; set; } = false;
        public List<OrderItems> OrderItems { get; set; }
    }
}
