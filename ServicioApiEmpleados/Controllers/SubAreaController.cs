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
    public class SubAreaController : ControllerBase
    {
        private SISTEMAEMPLEADOSContext _context = new SISTEMAEMPLEADOSContext();

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TblSubarea> Get()
        {
            return _context.TblSubareas.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{numAreaId}")]
        public TblSubarea Get(int numAreaId)
        {
            var subArea = _context.TblSubareas.Find(numAreaId);

            return subArea;
        }

        [HttpGet("GetSubareasxArea")]
        public IEnumerable<TblSubarea> GetSubareasxArea(int numAreaId)
        {
            var listSubAreas = _context.TblSubareas.FromSqlRaw("exec ConsultaSubAreasxArea @num_area_id=" + numAreaId).ToList();

            return listSubAreas;
        }


        /*
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
