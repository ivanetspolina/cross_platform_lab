using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommonProblemController : Controller
    {
        private readonly CallCenterDbContext _context;

        public CommonProblemController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonProblem>>> GetCommonProblems()
        {
            return await _context.CommonProblems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonProblem>> GetCommonProblem(int id)
        {
            var commonProblem = await _context.CommonProblems.FindAsync(id);

            if (commonProblem == null)
            {
                return NotFound();
            }

            return commonProblem;
        }
    }
}
