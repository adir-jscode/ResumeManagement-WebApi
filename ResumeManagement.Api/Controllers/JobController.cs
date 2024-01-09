using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeManagement.Api.Core.Context;
using ResumeManagement.Api.Core.Dtos.Job;
using ResumeManagement.Api.Core.Entities;

namespace ResumeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public JobController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create
        [HttpPost]
        public IActionResult CreateJob(CreateJobDto dto)
        {
            var job = _mapper.Map<Job>(dto);
             _context.Jobs.Add(job);
            _context.SaveChanges();
            
            return Ok("New Job Posted");
        }

        //Read
        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            var job = _context.Jobs.Include(j=>j.Company).ToList();
            var allJobs = _mapper.Map< IEnumerable<JobGetDto>>(job);
            return Ok(allJobs);
        }

        //Update

        //Delete
    }
}
