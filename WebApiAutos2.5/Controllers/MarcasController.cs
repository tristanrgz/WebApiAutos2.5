using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutos2._5.DTO_S;
using WebApiAutos2._5.Entidades;

namespace WebApiAutos2._5.Controllers
{
    [ApiController]
   [Route("marcas")]
    public class MarcasController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public MarcasController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }   

        [HttpGet]
       [HttpGet("/listadoMarca")]
       public async Task<ActionResult<List<Marca>>> GetAll()
        {
            return await dbContext.Marcas.ToListAsync();
        }

    }
}
