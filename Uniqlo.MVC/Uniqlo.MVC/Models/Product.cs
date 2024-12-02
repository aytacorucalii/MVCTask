namespace Uniqlo.MVC.Models;

public class Product
{ 
    public int Id { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }   
    public int LastPrice { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  
}
