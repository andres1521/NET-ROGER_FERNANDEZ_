using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_Fanalca.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica_Fanalca.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        // GET: TipoDocumentoController
        public ActionResult Index()
        {

            return View(_context.TblTipoDocumentos);
        }

        // GET: TipoDocumentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDocumentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TblTipoDocumento tipoID = new TblTipoDocumento();

                    tipoID.TipoIdentificacion = collection["TipoIdentificacion"];
                    tipoID.Descripcion = collection["Descripcion"];

                    _context.TblTipoDocumentos.Add(tipoID);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDocumentoController/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoID = _context.TblTipoDocumentos.Find(id);
            return View(tipoID);
        }

        // POST: TipoDocumentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tipoID = _context.TblTipoDocumentos.Find(id);

                    tipoID.TipoIdentificacion = collection["TipoIdentificacion"];
                    tipoID.Descripcion = collection["Descripcion"];
                    _context.TblTipoDocumentos.Update(tipoID);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDocumentoController/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoID = _context.TblTipoDocumentos.Find(id);

            return View(tipoID);
        }

        // POST: TipoDocumentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tipoID = _context.TblTipoDocumentos.Find(id);
                    _context.TblTipoDocumentos.Remove(tipoID);
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
