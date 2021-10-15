using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Fanalca.Models;
using Prueba_Tecnica_Fanalca.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Prueba_Tecnica_Fanalca.Controllers
{
    public class EmpleadoController : Controller
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        private IConfiguration _Configuration { get; }
        public EmpleadoController(IConfiguration configuration)
        {
            _Configuration = configuration;
            
        }
        // GET: EmpleadoController
        public ActionResult Index(string strbusquedaEmpNombre=null, int? numbusquedaDoc = null, int pg=1)
        {

            var listEmpleados = _context.TblEmpleados.Include(x => x.NumTipoDoc)
                                          .Include(x => x.NumArea)
                                          .Include(x => x.NumSubarea).ToList();

            
            if (!string.IsNullOrWhiteSpace(strbusquedaEmpNombre)|| numbusquedaDoc!=null) 
            {
                if (strbusquedaEmpNombre == null)
                    strbusquedaEmpNombre = "-";
                if (numbusquedaDoc == null)
                    numbusquedaDoc = -1;

                listEmpleados = listEmpleados.Where(x => x.Nombre.Contains(strbusquedaEmpNombre) || x.NumDocumento== numbusquedaDoc).ToList();
                
            }

            int maxRows  =int.Parse(_Configuration["KeyConfig:PageSize"]);
            //var paginaEmpleados = _context.TblEmpleados.FromSqlRaw("exec SP_PaginarEmpleados @NroPagina=" + pg + ",@TamanioPagina=" + maxRows).ToList();

           

            if (pg < 1)
                pg = 1;

            int totalEmp = listEmpleados.Count();


            var pager = new Pager(totalEmp,pg,maxRows);

            int recSkip = (pg - 1) * maxRows;

            var paginaEmpleados = listEmpleados.Skip(recSkip).Take(maxRows).ToList();

            ViewBag.Pager = pager;

            return View(paginaEmpleados);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()

        {
            /*
            var subAreas = db.TblSubareas.FromSqlRaw("exec ConsultarEmpleadosxArea @NOMBREAREA='Tecnologia'").SingleOrDefault();
             */

            ViewBag.NumTipoDocId = new SelectList(_context.TblTipoDocumentos, "NumTipoDocId", "TipoIdentificacion");
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TblEmpleado empleado = new TblEmpleado();

                    empleado.Nombre = collection["Nombre"];
                    empleado.Apellido = collection["Apellido"];
                    empleado.NumTipoDocId = int.Parse(collection["NumTipoDocId"]);
                    empleado.NumDocumento = int.Parse(collection["NumDocumento"]);
                    empleado.NumAreaId = int.Parse(collection["NumAreaId"]);
                    empleado.NumSubareaId = int.Parse(collection["NumSubareaId"]);

                    _context.TblEmpleados.Add(empleado);
                    _context.SaveChanges();
                }
                    return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {

            var empleado = _context.TblEmpleados.Include(x => x.NumTipoDoc)
                                          .Include(x => x.NumArea)
                                          .Include(x => x.NumSubarea)
                                          .SingleOrDefault(x => x.NumEmpleadoId == id);

            ViewBag.NumTipoDocId = new SelectList ( _context.TblTipoDocumentos, "NumTipoDocId", "TipoIdentificacion");

            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empleado = _context.TblEmpleados.Find(id);

                    empleado.Nombre = collection["Nombre"];
                    empleado.Apellido = collection["Apellido"];
                    empleado.NumTipoDocId = int.Parse(collection["NumTipoDocId"]);
                    empleado.NumDocumento = int.Parse(collection["NumDocumento"]);
                    empleado.NumAreaId = int.Parse(collection["NumAreaId"]);
                    empleado.NumSubareaId = int.Parse(collection["NumSubareaId"]);

                    _context.TblEmpleados.Update(empleado);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {

            var empleado = _context.TblEmpleados.Include(x => x.NumTipoDoc)
                                           .Include(x => x.NumArea)
                                           .Include(x => x.NumSubarea)
                                           .SingleOrDefault(x => x.NumEmpleadoId == id);

            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empleado = _context.TblEmpleados.Find(id);
                    _context.TblEmpleados.Remove(empleado);
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
