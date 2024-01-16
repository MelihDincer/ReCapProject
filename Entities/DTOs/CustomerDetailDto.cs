using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string CompanyName { get; set; }
    }
}
