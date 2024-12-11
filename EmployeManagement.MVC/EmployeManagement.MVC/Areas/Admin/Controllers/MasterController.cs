using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.MVC.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        // GET: MasterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MasterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
