using System.ComponentModel.DataAnnotations;

namespace WebApiAutos2._5.DTO_S
{
    public class GetAutoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int anio_fabricacion { get; set; }
    }
}
