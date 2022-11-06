using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutos2._5.DTO_S;
using WebApiAutos2._5.Entidades;

namespace WebApiAutos2._5.Controllers
{
    [ApiController]
    [Route("autos")]
    public class AutosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public AutosController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAutoDto>>> Get()
        {
            var autos = await dbContext.Autos.ToListAsync();
            return mapper.Map<List<GetAutoDto>>(autos);
        }

        

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutoDto autoDto)
        {
            var autoNombreIgual = await dbContext.Autos.AnyAsync(x => x.Nombre == autoDto.Nombre);
            if (autoNombreIgual)
            {
                return BadRequest("Ya existe un auto con el mismo Nombre");
            }
            var auto = mapper.Map<Auto>(autoDto);
            dbContext.Add(auto);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(AutoDto autoCreacionDto, int id)
        {
            var existencia = await dbContext.Autos.AnyAsync(x => x.Id == id);
            if(!existencia)
            {
                return NotFound();
            }

            var auto = mapper.Map<Auto>(autoCreacionDto);
            auto.Id = id;
            dbContext.Update(auto);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existencia = await dbContext.Autos.AnyAsync(x => x.Id == id);
            if(!existencia)
            {
                return NotFound("El recurso no fue encontrado");
            }

            dbContext.Remove(new Auto()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
