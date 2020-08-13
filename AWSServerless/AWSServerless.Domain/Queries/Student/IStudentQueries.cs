using AWSServerless.Domain.DTOs;

namespace AWSServerless.Domain.Queries.Student
{
    public interface IStudentQueries : IQueries<StudentDto, Entities.Student>
    {
    }
}