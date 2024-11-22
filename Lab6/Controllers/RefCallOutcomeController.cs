using Lab6.Data;
using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RefCallOutcomeController : Controller
    {
        private readonly CallCenterDbContext _context;

        public RefCallOutcomeController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefCallOutcome>>> GetRefCallOutcomes()
        {
            return await _context.RefCallOutcomes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RefCallOutcome>> GetRefCallOutcome(int id)
        {
            var refCallOutcome = await _context.RefCallOutcomes.FindAsync(id);

            if (refCallOutcome == null)
            {
                return NotFound();
            }

            return refCallOutcome;
        }
    }
}
