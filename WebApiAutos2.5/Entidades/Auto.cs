
using System.ComponentModel.DataAnnotations;

namespace WebApiAutos2._5.Entidades
{
    public class Auto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el campo nombre")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo del nombre tiene un limite de caracteres de 20")]
        public string Nombre { get; set; }
        [Range(1940, 2022, ErrorMessage = "El año de fabricacion del auto no esta en el intervalo")]
        public int anio_fabricacion { get; set; }

        public List<Marca> marcas { get; set; }
       
    }
}
