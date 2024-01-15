using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; } //Marka Adı
        public string BrandName { get; set; } //Marka Adı
        public string ColorName { get; set; } //Renk Adı
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
