using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Dtos.Job
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
    }
}
