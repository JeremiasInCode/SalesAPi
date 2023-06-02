using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venta_Real.Models;
using Venta_Real.Controllers;
using Venta_Real.Models.Response;
using Venta_Real.Models.Request;

namespace Venta_Real.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Cliente.OrderByDescending(element => element.Id).ToList();
                    respuesta.Success = 1;
                    respuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using(VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = oModel.Nombre;
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    respuesta.Success = 1;
                }
            }
            catch(Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var cliente = db.Cliente.Find(oModel.Id);
                    cliente.Nombre = oModel.Nombre;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var cliente = db.Cliente.Find(Id);
                    db.Remove(cliente);
                    db.SaveChanges();
                    respuesta.Success = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
