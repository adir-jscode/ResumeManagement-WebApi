using ResumeManagement.Api.Core.Enums;

namespace ResumeManagement.Api.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }

        //Relations
        //public long JobId { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
