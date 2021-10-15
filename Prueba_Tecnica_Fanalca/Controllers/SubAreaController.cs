using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Fanalca.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica_Fanalca.Controllers
{
    public class SubAreaController : Controller
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        // GET: SubAreaController
        public ActionResult Index()
        {
            var listSubAreas = _context.TblSubareas.Include(x => x.NumArea);
            return View(listSubAreas);
        }

        // GET: SubAreaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubAreaController/Create
        public ActionResult Create()
        {
            ViewBag.NumAreaId = new SelectList(_context.TblAreas, "NumAreaId","Nombre");
            return View();
        }

        // POST: SubAreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TblSubarea subArea = new TblSubarea();

                    subArea.Nombre = collection["Nombre"];
                    subArea.NumAreaId = int.Parse(collection["NumAreaId"]);

                    _context.TblSubareas.Add(subArea);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubAreaController/Edit/5
        public ActionResult Edit(int id)
        {

            var subArea = _context.TblSubareas.Include(x => x.NumArea).Single(x=>x.NumSubareaId==id);
            ViewBag.NumAreaId = new SelectList(_context.TblAreas, "NumAreaId", "Nombre");
            return View(subArea);
        }

        // POST: SubAreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var subArea = _context.TblSubareas.Find(id);

                    subArea.Nombre = collection["Nombre"];
                    subArea.NumAreaId = int.Parse(collection["NumAreaId"]);
                    _context.TblSubareas.Update(subArea);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubAreaController/Delete/5
        public ActionResult Delete(int id)
        {
            var subArea = _context.TblSubareas.Include(x => x.NumArea).Single(x => x.NumSubareaId == id);
            return View(subArea);
        }

        // POST: SubAreaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TblSubareas.Remove(_context.TblSubareas.Find(id));
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
