using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.DeleteStudent
{
    public class DeleteStudentCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
