namespace Venta_Real.Models.Response
{
    public class Respuesta
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Respuesta() { 
            this.Success = 0;
        }
    }
}
