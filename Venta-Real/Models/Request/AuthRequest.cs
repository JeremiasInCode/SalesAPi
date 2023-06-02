using System.ComponentModel.DataAnnotations;

namespace Venta_Real.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string email {  get; set; }
        [Required]
        public string password { get; set; }
    }
}
