using AITech.Entity.Entities.Common;

namespace AITech.Entity.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        // Lazy Loading için virtual olarak tanımlanmıştır
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
