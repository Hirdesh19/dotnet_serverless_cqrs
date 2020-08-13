using AutoMapper;
using AWSServerless.Domain.Contexts;
using AWSServerless.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.UpdateClassroom
{
    public class UpdateClassHandler : IRequestHandler<UpdateClassroomCommand, bool>
    {
        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public UpdateClassHandler(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new Exception("Invalid Id to update.");
            }

            Classroom classroom = await _context.Classrooms.FindAsync(request.Id);

            if (request.StudentIds.Any())
            {
                classroom.StudentClassrooms = new List<StudentClassroom>();

                foreach (int studentId in request.StudentIds)
                {
                    classroom.StudentClassrooms.Add(new StudentClassroom
                    {
                        StudentId = studentId
                    });
                }

                _context.Classrooms.Update(classroom);

                return await _context.Commit() > 0;
            }

            return false;
        }
    }
}