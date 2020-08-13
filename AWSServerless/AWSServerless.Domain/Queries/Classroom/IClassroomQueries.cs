using AWSServerless.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Queries.Classroom
{
    public interface IClassroomQueries: IQueries<ClassroomDto, Entities.Classroom>
    {
    }
}
