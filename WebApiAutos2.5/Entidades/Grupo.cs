using Microsoft.AspNetCore.Identity;

namespace WebApiAutos2._5.Entidades
{
    public class Grupo
    {
        public int Id { get; set; }
        
        public int MarcaId { get; set; }

        public string UsuarioId { get; set; }

        public IdentityUser Usuario { get; set; }
    }
}
