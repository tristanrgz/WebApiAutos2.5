using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using WebApiAutos2._5.DTO_S;
using WebApiAutos2._5.Entidades;

namespace WebApiAutos2._5.Controllers
{
    [ApiController]
    [Route("grupos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GruposController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public GruposController(ApplicationDbContext dbContext, IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet("{id:int}", Name = "obtener Grupo")]
        public async Task<ActionResult<GrupoDto>> GetById(int id)
        {
            var grupo = await dbContext.Grupos.FirstOrDefaultAsync(grupoDB => grupoDB.Id == id);

            if (grupo == null)
            {
                return NotFound();
            }

            return mapper.Map<GrupoDto>(grupo);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post (int marcaId, CreacionGrupoDto creacionGrupoDto)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();

            var email = emailClaim.Value;

            var usuario  = await userManager.FindByEmailAsync(email);

            var usuarioId = usuario.Id;

            var existeMarca = await dbContext.Marcas.AnyAsync(marcaDB => marcaDB.Id == marcaId);

            if (!existeMarca)
            {
                return NotFound();
            }

            var grupo = mapper.Map<Grupo>(creacionGrupoDto);
            grupo.MarcaId = marcaId;
            grupo.UsuarioId = usuarioId;
            dbContext.Add(grupo);
            await dbContext.SaveChangesAsync();

            var grupoDTO = mapper.Map<GrupoDto>(grupo);

            return Ok();

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put (int marcaId, int id, CreacionGrupoDto creacionGrupoDto)
        {
            var existeMarca = await dbContext.Marcas.AnyAsync(marcaDB => marcaDB.Id == marcaId);
            if(existeMarca)
            {
                return NotFound();
            }

            var existeGrupo = await dbContext.Marcas.AnyAsync(grupoDB => grupoDB.Id == id);
            if (existeMarca)
            {
                return NotFound();
            }

            var grupo = mapper.Map<Grupo>(creacionGrupoDto);
            grupo.Id = id;
            grupo.MarcaId = marcaId;

            dbContext.Update(grupo);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
        

    }
}
