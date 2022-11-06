using System.ComponentModel.DataAnnotations;

namespace WebApiAutos2._5.DTO_S
{
    public class MarcaCreacionConDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "El campo {0} solo puede tener hasta 250 caracteres")]
        public string Nombre { get; set; }
        public string Grupo { get; set; }
    }
}
