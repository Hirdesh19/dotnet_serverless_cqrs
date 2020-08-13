using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.DeleteClassroom
{
    public class DeleteClassroomCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
