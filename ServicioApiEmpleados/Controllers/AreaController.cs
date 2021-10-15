using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioApiEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioApiEmpleados.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();

        [HttpGet]
        public IEnumerable<TblArea> Get()
        {
            return _context.TblAreas.ToList();
        }



        /*
        [HttpGet]
        public JsonResult listarSubAreas(int numAreaId)

        {
            var listSubAreas = _context.TblSubareas.FromSqlRaw("exec ConsultaSubAreasxArea @num_area_id=" + numAreaId).ToList();

            return Json(listSubAreas);
        }
        */

    }
}
