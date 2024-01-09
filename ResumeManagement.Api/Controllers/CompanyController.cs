using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeManagement.Api.Core.Context;
using ResumeManagement.Api.Core.Dtos.Company;
using ResumeManagement.Api.Core.Entities;

namespace ResumeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Create
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
        {
            var newCompnay = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(newCompnay);
            await _context.SaveChangesAsync();
            return Ok("Company Created");
        }

        //Read
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var companies = _context.Companies.ToList();
            var companyDto = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(companyDto);
        }

        //Read (Get by Id)

        [HttpGet]
        [Route("id")]

        public IActionResult GetById(int id) 
        {
            var company = _context.Companies.Where(u=>u.Id  == id).FirstOrDefault();
            var companyDto = _mapper.Map<CompanyGetDto>(company);
            return Ok(companyDto);
        }

        //Update

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateCompany(UpdateCompanyDto dto)
        {
            var exists = _context.Companies.Where(u=>u.Id ==dto.Id).FirstOrDefault();
            if(exists !=null)
            {
                exists.Size = dto.Size;
                exists.Name = dto.Name;
                var update = _context.Companies.Update(exists);
                _context.SaveChanges();
              
                return Ok("Updated");
            }
            else
            {
                return NotFound();
            }
            
        }


        //Delete

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var company = _context.Companies.Where(u=>u.Id ==id).FirstOrDefault();
            if(company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
                return Ok("Deleted");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
