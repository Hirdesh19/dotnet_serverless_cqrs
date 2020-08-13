using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
