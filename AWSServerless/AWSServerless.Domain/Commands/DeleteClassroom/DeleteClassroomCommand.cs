using MediatR;

namespace AWSServerless.Domain.Commands.DeleteClassroom
{
    public class DeleteClassroomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}