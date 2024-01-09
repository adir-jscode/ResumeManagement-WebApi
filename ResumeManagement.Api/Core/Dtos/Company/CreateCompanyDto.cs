using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Dtos.Company
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
