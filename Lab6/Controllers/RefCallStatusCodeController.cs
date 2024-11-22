using Lab6.Data;
using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RefCallStatusCodeController : Controller
    {
        private readonly CallCenterDbContext _context;

        public RefCallStatusCodeController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefCallStatusCode>>> GetRefCallStatusCodes()
        {
            return await _context.RefCallStatusCodes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RefCallStatusCode>> GetRefCallStatusCode(int id)
        {
            var refCallStatusCode = await _context.RefCallStatusCodes.FindAsync(id);

            if (refCallStatusCode == null)
            {
                return NotFound();
            }

            return refCallStatusCode;
        }
    }
}
