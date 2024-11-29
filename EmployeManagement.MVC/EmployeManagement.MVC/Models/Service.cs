namespace EmployeManagement.MVC.Models;

public class Service:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Master { get; set; }
    public DateTime CreateUp { get; set; }
    public DateTime UpdateUp { get; set; }
    public ICollection<Master> Masters { get; set; }

    public ICollection<Order> Orders { get; set; }


}
