using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_Fanalca.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica_Fanalca.Controllers
{
    public class AreaController : Controller
    {
        // GET: AreaController
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        public ActionResult Index()
        {
            var listAreas = _context.TblAreas;
            return View(listAreas);
        }

        // GET: AreaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AreaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    TblArea area = new TblArea();
                    area.Nombre = collection["Nombre"];
                    _context.TblAreas.Add(area);
                    _context.SaveChanges();
                }

                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.TblAreas.Find(id));
        }

        // POST: AreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newArea = _context.TblAreas.Find(id);

                    newArea.Nombre = collection["Nombre"];

                    _context.TblAreas.Update(newArea);
                    _context.SaveChanges();
                }
                 


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AreaController/Delete/5
        public ActionResult Delete(int id)
        {


            return View(_context.TblAreas.Find(id));
        }

        // POST: AreaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var Area = _context.TblAreas.Find(id);
                    _context.TblAreas.Remove(Area);
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
