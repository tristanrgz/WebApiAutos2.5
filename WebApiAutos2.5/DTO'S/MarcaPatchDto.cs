using System.ComponentModel.DataAnnotations;
namespace WebApiAutos2._5.DTO_S
{
    public class MarcaPatchDto
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo del nombre tiene un limite de caracteres de 20")]
        public string Nombre { get; set; }
        
    }
}
