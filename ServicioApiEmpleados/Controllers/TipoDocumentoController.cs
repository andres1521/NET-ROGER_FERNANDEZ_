using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class TipoDocumentoController : ControllerBase
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TblTipoDocumento> Get()
        {
            return _context.TblTipoDocumentos;
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        public IEnumerable<TblTipoDocumento> Get(string tipo)
        {
            return _context.TblTipoDocumentos.Where(x=>x.TipoIdentificacion==tipo).ToList();
        }

    }
}
