using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommonSolutionController : Controller
    {
        private readonly CallCenterDbContext _context;

        public CommonSolutionController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonSolution>>> GetCommonSolutions()
        {
            return await _context.CommonSolutions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonSolution>> GetCommonSolution(int id)
        {
            var commonSolution = await _context.CommonSolutions.FindAsync(id);

            if (commonSolution == null)
            {
                return NotFound();
            }

            return commonSolution;
        }
    }
}
