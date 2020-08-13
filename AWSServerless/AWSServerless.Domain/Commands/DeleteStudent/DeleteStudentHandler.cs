using AWSServerless.Domain.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {

        private readonly ISchoolContext _context;

        public DeleteStudentHandler(ISchoolContext context)
        {
            this._context = context;
        }



        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new Exception("Invalid Id.");
            }
            var entity = await _context.Students.FindAsync(request.Id);

            if (entity == null)
            {
                return false;
            }
            _context.Students.Remove(entity);
            int success = await _context.Commit();

            return success > 0;
        }
    }
}
