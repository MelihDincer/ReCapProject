using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
