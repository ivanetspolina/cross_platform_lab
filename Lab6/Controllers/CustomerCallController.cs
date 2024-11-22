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
    public class CustomerCallController : Controller
    {
        private readonly CallCenterDbContext _context;

        public CustomerCallController(CallCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCall>>> GetCustomerCalls()
        {
            return await _context.CustomerCalls
                .Include(cc => cc.Customer)
                .Include(cc => cc.CallCenter)
                .Include(cc => cc.RefCallOutcome)
                .Include(cc => cc.RefCallStatusCode)
                .Include(cc => cc.Staff)
                .Include(cc => cc.CommonSolution)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCall>> GetCustomerCall(int id)
        {
            var customerCall = await _context.CustomerCalls
                .Include(cc => cc.Customer)
                .Include(cc => cc.CallCenter)
                .Include(cc => cc.RefCallOutcome)
                .Include(cc => cc.RefCallStatusCode)
                .Include(cc => cc.Staff)
                .Include(cc => cc.CommonSolution)
                .FirstOrDefaultAsync(cc => cc.Call_Id == id);

            if (customerCall == null)
            {
                return NotFound();
            }

            return customerCall;
        }
    }
}
