namespace PurpleBuzzPr.Models.Base;

public class BaseAuditableEntity:BaseEntity
{
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }

}
