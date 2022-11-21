using System.ComponentModel.DataAnnotations;

namespace WebApiAutos2._5.DTO_S
{
    public class EdicionAdministradorDTO
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
    }
}
