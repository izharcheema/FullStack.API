using FullStack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly FullStackDBContext _context;

        public CompanyController(FullStackDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return Ok(companies);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] Company companyRequest)
        {
            companyRequest.Id = Guid.NewGuid();
            await _context.Companies.AddAsync(companyRequest);
            await _context.SaveChangesAsync();
            return Ok(companyRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCompany([FromRoute] Guid id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] Guid id, Company updateCompany)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            company.CompanyName = updateCompany.CompanyName;
            company.CompanyEmail = updateCompany.CompanyEmail;
            company.CompanyPhone = updateCompany.CompanyPhone;
            company.NumberOfEmployees = updateCompany.NumberOfEmployees;
            company.CompanyAddress = updateCompany.CompanyAddress;
            await _context.SaveChangesAsync();
            return Ok(company);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return Ok(company);
        }
    }
}
