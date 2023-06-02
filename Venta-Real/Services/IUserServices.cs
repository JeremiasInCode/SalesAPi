using Venta_Real.Models.Response;
using Venta_Real.Models.Request;
namespace Venta_Real.Services
{
    public interface IUserServices
    {
        UserResponse Auth(AuthRequest client_info);
    }
}
