﻿using GameStorePr.MVC.DAL;
using GameStorePr.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStorePr.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController : Controller
{
    private readonly AppDbContext _context;

    public GameController(AppDbContext context)
    {
        _context = context;
    }
   

    public async Task< IActionResult> Index()
    {
        IEnumerable<Game>games = await _context.Games.ToListAsync();
        return View(games);
    }
    public IActionResult Delete(int id)
    {
        Game? deletedGame = _context.Games.Find(id);
        if (deletedGame == null)
        {
            return NotFound();
        }
        else
        {
            _context.Games.Remove(deletedGame);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }



    public async Task<IActionResult> Create()
    {
     
        return View();
    }

    [HttpPost]
    public IActionResult Create(Game game)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Something went wrong");
        }

        _context.Games.Add(game);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }



    public async Task<IActionResult> Update(int? id)
    {
   
        Game? game = _context.Games.Find(id);
        if (game is null)
        {
            return NotFound("No such game");
        }
        return View(game);
    }

    [HttpPost]
    public IActionResult Update(Game game)
    {
        Game? updatedGame = _context.Games.AsNoTracking().FirstOrDefault(g => g.Id == game.Id);
        if (updatedGame is null)
        {
            return NotFound("No such game");
        }
        _context.Games.Update(game);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
