namespace MiWebAPI.Models
{
    public class Proveedor
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido_Paterno { get; set; }
        public string? Apellido_Materno { get; set; }
        public string? Rfc { get; set; }
        public string? Correo { get; set; }
        public decimal Credito { get; set; }
        public string? Nombre_Banco { get; set; }
    }
}
