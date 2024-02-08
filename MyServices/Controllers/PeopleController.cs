using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyServices.Entities;
using MyServices.Models.People;
using MyServices.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyServices.Controllers
{
    [ApiController]
    [Route("api/v0.1/[controller]")]
    public class PeopleController : ControllerBase
    {

        private IPeopleService _peopleService;
        private IMapper _mapper;


        private readonly ILogger<PeopleController> _logger;

        public PeopleController(IPeopleService peopleService,IMapper mapper)
        {
            _peopleService = peopleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ShowAllPeople")]

        public IActionResult GetAll()
        {
            try
            {
                var users = _peopleService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RegisterPerson")]
        public IActionResult Create(CreateRequest model)
        {
            try
            {
              _peopleService.Create(model);
              return Ok(new { message = "Usuario registrado." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchPerson")]
        public IActionResult Search(int TipoDocumento,string NumeroDocumento)
        {
            try
            {
                string authHeader = Request.Headers["Authorization"];
                
                if (string.IsNullOrEmpty(authHeader))
                {
                    return Unauthorized("No se detectó las credenciales");
                }

                // Verificar que el encabezado tiene el prefijo "Basic"
                if (!authHeader.StartsWith("Basic "))
                {
                    return Unauthorized("Autorización debe ser básica.");
                }

                // Obtener el token de autenticación básica y decodificarlo
                string encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
                string decodedCredentials = System.Text.Encoding.UTF8.GetString(decodedBytes);

                // Dividir las credenciales en nombre de usuario y contraseña
                string[] credentials = decodedCredentials.Split(':');
                string username = credentials[0];
                string password = credentials[1];

                //Se procede a enviar a validar con las credenciales que pueden estar en base o desde el appsettings.
                //ValidarSesion(username,password)
                var users = _peopleService.GetByDOI(TipoDocumento,NumeroDocumento);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdatePerson")]
        public IActionResult Update(int TipoDocumento, string NumeroDocumento,UpdateRequest model)
        {
            try
            {
               _peopleService.Update(TipoDocumento, NumeroDocumento,model);

                return Ok(new { message = "Usuario actualizado." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DeletePerson")]
        public IActionResult Update(DeleteRequest model)
        {
            try
            {
                if (model.cNumeroDOI == null)
                {
                    return BadRequest("No ha ingresado el número de su documento.");
                }
                _peopleService.Delete(model.nTipoDOI, model.cNumeroDOI);

                return Ok(new { message = "Usuario eliminado." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
