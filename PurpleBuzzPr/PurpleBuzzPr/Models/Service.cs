using PurpleBuzzPr.Models.Base;

namespace PurpleBuzzPr.Models
{
    public class Service : BaseAuditableEntity
    {   public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public ICollection<Work>? Works { get; set; }
    }
}
