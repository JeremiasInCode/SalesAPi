using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta_Real.Models.Request;
using Venta_Real.Models.Response;
using Venta_Real.Services;

namespace Venta_Real.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest request_user)
        {
            Respuesta respuesta = new Respuesta();
            UserResponse user_response = _userService.Auth(request_user);
            
            if (user_response == null)
            {
                respuesta.Success = 0;
                respuesta.Message = "Usuario o contraseña incorrecto";
                return BadRequest(); // Failed status code
            }
            respuesta.Success = 1;
            respuesta.Message = "Usuario y contraseña correcto";
            respuesta.Data = user_response;
            return Ok(respuesta);
        }
    }
}
