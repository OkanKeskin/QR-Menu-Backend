namespace QRMenuBackendProject.WebApi.Models
{
    public class EmployeeRegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
