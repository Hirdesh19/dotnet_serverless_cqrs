using AutoMapper;
using AWSServerless.Domain.Contexts;
using AWSServerless.Domain.DTOs;
using AWSServerless.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public CreateStudentHandler(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // do some kind of checks that make sense...

            Student student = _mapper.Map<CreateStudentCommand, Student>(request);

            if (request.ClassroomIds.Any())
            {
                student.StudentClassrooms = new List<StudentClassroom>();

                foreach (int classroomId in request.ClassroomIds)
                {
                    student.StudentClassrooms.Add(new StudentClassroom
                    {
                        ClassRoomId = classroomId
                    });
                }
            }

            await _context.Students.AddAsync(student);

            int success = await _context.Commit();

            if (success <= 0)
            {
                throw new Exception("Cannot save database changes.");
            }

            return _mapper.Map<Student, StudentDto>(student);
        }
    }
}