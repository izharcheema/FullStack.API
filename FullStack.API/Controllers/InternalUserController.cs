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
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateInternalUser([FromRoute]int id, InternalUser updateInternalUser)
        {
            var internalUser = await _context.internalUsers.FindAsync(id);
            if (internalUser == null)
            {
                return NotFound();
            }
            internalUser.Id = id;
            internalUser.FirstName = updateInternalUser.FirstName;
            internalUser.LastName = updateInternalUser.LastName;
            internalUser.UserName = updateInternalUser.UserName;
            internalUser.Email = updateInternalUser.Email;
            internalUser.Designation = updateInternalUser.Designation;
            internalUser.Grade = updateInternalUser.Grade;
            internalUser.EmployeeId = updateInternalUser.EmployeeId;
            internalUser.Gender = updateInternalUser.Gender;
            internalUser.UserRole_GroupRole = updateInternalUser.UserRole_GroupRole;
            internalUser.UserGroup = updateInternalUser.UserGroup;
            internalUser.DateOFBirth = updateInternalUser.DateOFBirth;
            internalUser.CNIC = updateInternalUser.CNIC;
            internalUser.Mobile = updateInternalUser.Mobile;
            await _context.SaveChangesAsync();
            return Ok(internalUser);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteInternalUser([FromRoute]int id)
        {
            var internalUser = await _context.internalUsers.FindAsync(id);
            if (internalUser == null)
            {
                return NotFound();
            }
            _context.internalUsers.Remove(internalUser);
            await _context.SaveChangesAsync();
            return Ok(internalUser);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInternalUser([FromRoute] int id)
        {
            var internaluser= await _context.internalUsers.FirstOrDefaultAsync(x=>x.Id==id);
            if (internaluser == null)
            {
                NotFound();
            }
            return Ok(internaluser);
        }
    }
}
