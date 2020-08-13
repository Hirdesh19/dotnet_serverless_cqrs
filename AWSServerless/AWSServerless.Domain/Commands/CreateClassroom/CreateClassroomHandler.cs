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

namespace AWSServerless.Domain.Commands.CreateClassroom
{
    public class CreateClassroomHandler : IRequestHandler<CreateClassroomCommand, ClassroomDto>
    {

        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public CreateClassroomHandler(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClassroomDto> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            // do some kind of checks that make sense...

            Classroom classroom = _mapper.Map<CreateClassroomCommand, Classroom>(request);

            if (request.StudentIds.Any())
            {
                classroom.StudentClassrooms = new List<StudentClassroom>();

                foreach (int studentId in request.StudentIds) {

                    classroom.StudentClassrooms.Add(new StudentClassroom
                    {
                        StudentId = studentId
                    });
                }
            }

            await _context.Classrooms.AddAsync(classroom);

            int success = await _context.Commit();

            if (success <= 0)
            {
                throw new Exception("Cannot save database changes.");
            }

            return _mapper.Map<Classroom, ClassroomDto>(classroom);

        }
    }
}
