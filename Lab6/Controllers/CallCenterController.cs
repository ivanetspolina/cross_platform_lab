using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Models;
using Lab6.Data;

namespace Lab6.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CallCenterController : Controller
    {
        private readonly CallCenterDbContext _context;

        public CallCenterController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallCenter>>> GetCallCenters()
        {
            return await _context.CallCenters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CallCenter>> GetCallCenter(int id)
        {
            var callCenter = await _context.CallCenters.FindAsync(id);

            if (callCenter == null)
            {
                return NotFound();
            }

            return callCenter;
        }
    }
}
