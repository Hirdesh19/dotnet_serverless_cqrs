using AutoMapper;
using AWSServerless.Domain.Contexts;
using AWSServerless.Domain.DTOs;
using AWSServerless.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.CreateTeacher
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, TeacherDto>
    {

        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public CreateTeacherHandler(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            // do some kind of checks that make sense...

            Teacher teacher = _mapper.Map<CreateTeacherCommand, Teacher>(request);

            await _context.Teachers.AddAsync(teacher);

            int success = await _context.Commit();

            if (success <= 0)
            {
                throw new Exception("Cannot save database changes.");
            }

            return _mapper.Map<Teacher, TeacherDto>(teacher);

        }
    }
}
