using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioApiEmpleados.Models;
using ServicioApiEmpleados.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioApiEmpleados.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
            public string Get()
            {
                return "Bienvenido a la api";
            }

        

        [HttpPost]
        public ActionResult Token(UserLogin credenciales)
        {
            if (authService.ValidateLogin(credenciales.Username, credenciales.Password))
            {
                var fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromHours(5);
                var fechaExpiracion = fechaActual.Add(validez);

                var token = authService.GenerateToken(fechaActual, credenciales.Username, validez);
                return Ok(new
                {
                    Token = token,
                    ExpireAt = fechaExpiracion
                });
            }
            return StatusCode(401);
        }
    }
}
