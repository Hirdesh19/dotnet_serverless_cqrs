using AWSServerless.Domain.DTOs;
using MediatR;

namespace AWSServerless.Domain.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<TeacherDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}