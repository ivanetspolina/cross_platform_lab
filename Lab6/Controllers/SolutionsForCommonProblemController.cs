using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SolutionsForCommonProblemController : Controller
    {
        private readonly CallCenterDbContext _context;

        public SolutionsForCommonProblemController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolutionsForCommonProblem>>> GetSolutionsForCommonProblems()
        {
            return await _context.SolutionsForCommonProblems
                .Include(s => s.CommonProblem)
                .Include(s => s.CommonSolution)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionsForCommonProblem>> GetSolutionsForCommonProblem(int id)
        {
            var solutionsForCommonProblem = await _context.SolutionsForCommonProblems
                .Include(s => s.CommonProblem)
                .Include(s => s.CommonSolution)
                .FirstOrDefaultAsync(s => s.Problem_Id == id);

            if (solutionsForCommonProblem == null)
            {
                return NotFound();
            }

            return solutionsForCommonProblem;
        }
    }
}
