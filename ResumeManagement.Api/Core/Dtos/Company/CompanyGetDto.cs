using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Dtos.Company
{
    public class CompanyGetDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        public CompanySize Size { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
