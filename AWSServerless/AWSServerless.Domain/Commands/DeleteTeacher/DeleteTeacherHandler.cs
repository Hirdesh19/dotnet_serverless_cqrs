using AWSServerless.Domain.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.DeleteTeacher
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {

        private readonly ISchoolContext _context;

        public DeleteTeacherHandler(ISchoolContext context)
        {
            this._context = context;
        }



        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new Exception("Invalid Id.");
            }
            var entity = await _context.Teachers.FindAsync(request.Id);

            if (entity == null)
            {
                return false;
            }
            _context.Teachers.Remove(entity);
            int success = await _context.Commit();

            return success > 0;
        }
    }
}
