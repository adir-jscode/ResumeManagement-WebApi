using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
