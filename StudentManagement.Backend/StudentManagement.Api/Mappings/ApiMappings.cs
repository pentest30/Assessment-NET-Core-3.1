using AutoMapper;
using StudentManagement.Api.Models.Settings;
using StudentManagement.Api.Models.Students;
using StudentManagement.Application.Settings.Commands;
using StudentManagement.Application.Students.Commands;

namespace StudentManagement.Api.Mappings
{
    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            CreateMap<CreateSpecialityCommand, SpecialityModel>().ReverseMap();
            CreateMap<UpdateSpecialityCommand, SpecialityModel>().ReverseMap();
            CreateMap<CreateStudentCommand, StudentModel>().ReverseMap();
        }
    }
}