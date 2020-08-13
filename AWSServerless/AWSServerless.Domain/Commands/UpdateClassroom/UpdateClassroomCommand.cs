using MediatR;
using System.Collections.Generic;

namespace AWSServerless.Domain.Commands.UpdateClassroom
{
    public class UpdateClassroomCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public IList<int> StudentIds { get; set; } = new List<int>();

        public int TeacherId { get; set; }
    }
}