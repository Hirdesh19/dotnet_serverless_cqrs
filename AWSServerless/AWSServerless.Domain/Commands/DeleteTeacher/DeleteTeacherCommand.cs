using MediatR;

namespace AWSServerless.Domain.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}