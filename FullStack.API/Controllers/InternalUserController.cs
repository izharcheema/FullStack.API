using FullStack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalUserController : ControllerBase
    {
        private readonly FullStackDBContext _context;

        public InternalUserController(FullStackDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInternalUsers()
        {
            var internalUsers = await _context.internalUsers.ToListAsync();
            return Ok(internalUsers);
        }
        [HttpPost]
        public async Task<IActionResult> AddInternalUser([FromBody] InternalUser internalUserRequest)
        {
            internalUserRequest.Id = 0;
            await _context.internalUsers.AddAsync(internalUserRequest);
            await _context.SaveChangesAsync();
            return Ok(internalUserRequest);
        }
    }
}
