using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        //Relations
        public long CompanyId { get; set; }
        public string CompanyName { get; set;}
    }
}
