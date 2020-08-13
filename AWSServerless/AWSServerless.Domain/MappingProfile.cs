using AutoMapper;
using AWSServerless.Domain.DTOs;
using AWSServerless.Domain.Entities;

namespace AWSServerless.Domain
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;

            #region DTO to DBO

            CreateMap<ClassroomDto, Classroom>();
            CreateMap<StudentDto, Student>();
            CreateMap<TeacherDto, Teacher>();

            #endregion DTO to DBO

            #region DBO to DTO

            CreateMap<Classroom, ClassroomDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Teacher, TeacherDto>();

            #endregion DBO to DTO
        }
    }
}
