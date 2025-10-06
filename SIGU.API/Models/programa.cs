namespace SIGU.API.Models
{
    public class programa
    {
        public int programaid { get; set; }
        public string nombre { get; set; } = string.Empty;

        // Relación: un programa puede tener muchos usuarios
        public ICollection<Usuario>? usuarios { get; set; }
    }
}