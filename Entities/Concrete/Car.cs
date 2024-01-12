using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; } //Marka Id
        public int ColorId { get; set; } //Renk Id
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }

    public class CarDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; } //Marka Adı
        public string ColorName { get; set; } //Renk Adı
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
