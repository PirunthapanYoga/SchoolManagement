using API.DTO;
using API.Entities;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,StudentDetailsDto>();

            CreateMap<Teacher,TeacherDetailsOnlyDto>();

            CreateMap<ClassRoom,ClassRoomBasicDetailsDto>();

            CreateMap<Teacher, TeacherDetailsDto>()
            .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects))
            .ForMember(dest => dest.ClassRooms, opt => opt.MapFrom(src => src.ClassRooms));

            CreateMap<ClassRoom, ClassRoomDetailsDto>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
            .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers));

            CreateMap<ClassRoom, ClassRoomStudentReportDto>()
            .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers));

            CreateMap<Subject, SubjectDetailsDto>();
            CreateMap<Subject, SubjectDetailsWithTeachersDto>()
            .ForMember(dest=>dest.Teachers, opt=>opt.MapFrom(src => src.Teachers));
            
        }
    }
}