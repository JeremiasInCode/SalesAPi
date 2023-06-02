using Venta_Real.Models.Request;
using Venta_Real.Services;
using Venta_Real.Models;
using Venta_Real.Tools; // encrypt
using Venta_Real.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Venta_Real.Models.Response;

public class UserService : IUserServices
{
    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public UserResponse Auth(AuthRequest client_info)
    {
        UserResponse user_response = new UserResponse();
        using (VentaRealContext db = new VentaRealContext())
        {
            string encrypt_password = Encrypt.GetSHA256(client_info.password);
            var usuario = db.Usuarios.Where
                (element => element.Email == client_info.email
                && element.Password == encrypt_password).FirstOrDefault(); // return element or null

            if (usuario == null) return null;
            user_response.Email = usuario.Email;
            user_response.Token = GetToken(usuario);
        }
        return user_response;
    }

    private string GetToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                }
                ),
            Expires = DateTime.UtcNow.AddDays(60),
            SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token); // return string.
    }
}

