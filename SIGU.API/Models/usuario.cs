namespace SIGU.API.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
         public string cedula { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
       
        public string passwordHash { get; set; } = string.Empty;
        public string rol { get; set; } = string.Empty; // admin, docente, estudiante

        // Relación con Programa (muchos usuarios pertenecen a un programa)
        public int? programaid { get; set; }
       public programa? programa { get; set; }

    
    }
}
