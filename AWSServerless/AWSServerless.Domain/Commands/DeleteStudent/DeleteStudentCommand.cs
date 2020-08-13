using MediatR;

namespace AWSServerless.Domain.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}