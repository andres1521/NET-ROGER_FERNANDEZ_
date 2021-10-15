using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioApiEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicioApiEmpleados.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        // GET: api/<EmpleadoController>
        [HttpGet]
        public IEnumerable<TblEmpleado> Get()
        {
            var listEmpleados = _context.TblEmpleados.Include(x => x.NumTipoDoc)
                                          .Include(x => x.NumArea)
                                          .Include(x => x.NumSubarea).ToList();
            return listEmpleados;
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("GetEmpleados")]
        public IEnumerable<TblEmpleado> Get(string strbusquedaEmpNombre = null, int? numbusquedaDoc = null)
        {
            var listEmpleados = _context.TblEmpleados.Include(x => x.NumTipoDoc)
                                          .Include(x => x.NumArea)
                                          .Include(x => x.NumSubarea).ToList();


            if (!string.IsNullOrWhiteSpace(strbusquedaEmpNombre) || numbusquedaDoc != null)
            {
                if (strbusquedaEmpNombre == null)
                    strbusquedaEmpNombre = "-";
                if (numbusquedaDoc == null)
                    numbusquedaDoc = -1;

                listEmpleados = listEmpleados.Where(x => x.Nombre.Contains(strbusquedaEmpNombre) || x.NumDocumento == numbusquedaDoc).ToList();

            }
            //var paginaEmpleados = _context.TblEmpleados.FromSqlRaw("exec SP_PaginarEmpleados @NroPagina=" + pg + ",@TamanioPagina=" + maxRows).ToList();
            return listEmpleados;

        }


        // DELETE api/<EmpleadoController>/5
        [HttpDelete("BorrarEmpleado")]
        public void Delete(int id)
        {
            var Empleado = _context.TblEmpleados.Find(id);

            _context.TblEmpleados.Remove(Empleado);
            _context.SaveChanges();

        }
    }
}
