using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expediente_RASE.Controllers
{
    public class AntAlerController : Controller
    {
        // GET: AntAlerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AntAlerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AntAlerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AntAlerController/Create
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

        // GET: AntAlerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AntAlerController/Edit/5
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

        // GET: AntAlerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AntAlerController/Delete/5
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
