using AutoMapper;
using ResumeManagement.Api.Core.Dtos.Candidate;
using ResumeManagement.Api.Core.Dtos.Company;
using ResumeManagement.Api.Core.Dtos.Job;
using ResumeManagement.Api.Core.Entities;

namespace ResumeManagement.Api.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() 
        {
            //Company
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<Company, CompanyGetDto>();
           

            //Job
            CreateMap<CreateJobDto,Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest=>dest.CompanyName, options=>options.MapFrom(src=>src.Company.Name));

            //Candidate
            CreateMap<CreateCandidateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest=>dest.JobTitle,options=>options.MapFrom(src=>src.Job.Title));
        }
    }
}
