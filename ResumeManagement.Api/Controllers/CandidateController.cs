using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeManagement.Api.Core.Context;
using ResumeManagement.Api.Core.Dtos.Candidate;
using ResumeManagement.Api.Core.Entities;

namespace ResumeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CandidateController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddCandidate([FromForm]CreateCandidateDto dto,IFormFile pdfFile)
        {

            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfFileType = "application/pdf";

            if(pdfFile.Length > fiveMegaByte || pdfFile.ContentType !=pdfFileType)
            {
                return BadRequest("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"documents","pdfs",resumeUrl);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            var candidate = _mapper.Map<Candidate>(dto);
            candidate.ResumeUrl = resumeUrl;
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return Ok("Candidate Added Successfully");
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var candidate = _context.Candidates.Include(u=>u.Job).ToList();
            var allCandidate = _mapper.Map< IEnumerable<CandidateGetDto>>(candidate);

            return Ok(allCandidate);
        }

        //Read (Download pdf)
        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

            if(!System.IO.File.Exists(filePath)) 
            {
                return BadRequest();
            }

            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);
            return file;
        }
    }
}
