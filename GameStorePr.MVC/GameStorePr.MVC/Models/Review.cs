using GameStorePr.MVC.Models.Base;

namespace GameStorePr.MVC.Models;

public class Review : BaseEntity
{
    public string Message { get; set; }
    public Game Game { get; set; }
    public int GameId { get; set; }
    public DateTime CreatedAt { get; set; }
   

}
