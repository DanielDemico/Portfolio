namespace backend.Controllers
{
    using backend.Data;
    using backend.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projetos>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Projetos>> CreateProjeto(Projetos projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return Ok(projeto);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projetos>> GetProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return projeto;
        }
    }
}