using AWSServerless.Domain.Contexts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.DeleteClassroom
{
    public class DeleteClassroomHandler : IRequestHandler<DeleteClassroomCommand, bool>
    {
        private readonly ISchoolContext _context;

        public DeleteClassroomHandler(ISchoolContext context)
        {
            this._context = context;
        }

        public async Task<bool> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new Exception("Invalid Id.");
            }
            var entity = await _context.Classrooms.FindAsync(request.Id);

            if (entity == null)
            {
                return false;
            }
            _context.Classrooms.Remove(entity);
            int success = await _context.Commit();

            return success > 0;
        }
    }
}