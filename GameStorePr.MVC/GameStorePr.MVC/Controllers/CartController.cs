using GameStorePr.MVC.DAL;
using GameStorePr.MVC.DTOs.BasketDTOs;
using GameStorePr.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameStorePr.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket(int gameId)
        {
            if (gameId <= 0) return BadRequest();

            Game? game = _context.Games.Find(gameId);
            if (game == null) return NotFound();

            var cookieopt = new CookieOptions { Expires = DateTime.Now.AddDays(7) };

            CartDTO basket = GetBasket();
            if (basket == null)
            {
                basket = new CartDTO();
            }

            BasketDTO existingItem = basket.BasketItems.FirstOrDefault(p => p.GameId == game.Id);

            if (existingItem == null)
            {
                BasketDTO newItem = new BasketDTO()
                {
                 
                    Title = game.GameName,
                    Price = game.Price,
                    Quantity = 1
                };
                basket.BasketItems.Add(newItem);
            }
            else
            {
                existingItem.Quantity++;
            }

            var basketJson = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append("Basket", basketJson, cookieopt);
            return Ok();
        }

        private CartDTO GetBasket()
        {
            var basketJson = Request.Cookies["Basket"];
            if (basketJson != null)
            {
                return JsonConvert.DeserializeObject<CartDTO>(basketJson);
            }
            return new CartDTO();
        }

        [HttpPost]
        public IActionResult RemoveItem(int GameId)
        {
            CartDTO basket = GetBasket();

            BasketDTO itemToRemove = basket.BasketItems.FirstOrDefault(p => p.GameId == GameId);
            if (itemToRemove != null)
            {
                basket.BasketItems.Remove(itemToRemove);
            }

            var cookieopt = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
            var basketJson = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", basketJson, cookieopt);

            return Ok();
        }
    }
}
