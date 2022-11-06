namespace WebApiAutos2._5.DTO_S
{
    public class MarcaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grupo {get; set; }
        public List<MarcaDto> Marcas { get; set; }
    }
}
