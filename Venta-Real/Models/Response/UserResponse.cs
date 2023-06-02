using System.ComponentModel.DataAnnotations;

namespace Venta_Real.Models.Response
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
