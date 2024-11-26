using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkController : Controller
{
    private readonly AppDbContext _appDbContext;
    public WorkController(AppDbContext dbContext)
    {
        _appDbContext = dbContext;
    }
    public async Task<IActionResult> IndexAsync()
    {
        IEnumerable<Work> works = await _appDbContext.Works.ToListAsync();
        return View(works); 
    }

    public IActionResult Delete(int Id)
    {
        Work? deleted = _appDbContext.Works.Find(Id);
        if (deleted == null) { return NotFound(); }
        else
        {
            _appDbContext.Works.Remove(deleted);
            _appDbContext.SaveChanges();
        }
        return RedirectToAction(nameof(Index));

    }
    public IActionResult CreateWork()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateWork(Work work)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest("Something went wrong");
        //}

        work.CreateAt = DateTime.Now;
        _appDbContext.Works.Add(work);
        _appDbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Update(int? id)
    {
        Work? work = _appDbContext.Works.Find(id);

        if (work is null)
        {
            return NotFound("No such service");
        }

        return View(work);
    }
    [HttpPost]
    public IActionResult Update(Work work)
    {
        Work? updatedWork = _appDbContext.Works.Find(work.Id);

        if (updatedWork is null)
        {
            return NotFound("No such service");
        }
        _appDbContext.Works.Update(updatedWork);
        return RedirectToAction(nameof(Index));
    }
}
