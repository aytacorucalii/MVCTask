﻿namespace GameStorePr.MVC.Models.Base;

public abstract class AuditableEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
