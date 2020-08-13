using AWSServerless.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Queries.Teacher
{
    public interface ITeacherQueries: IQueries<TeacherDto, Entities.Teacher>
    {
    }
}
