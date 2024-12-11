using GameStorePr.MVC.Models.Base;

namespace GameStorePr.MVC.Models;

public class Game: BaseEntity
{
   
    public string GameName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    public int GameId { get; set; }
}
