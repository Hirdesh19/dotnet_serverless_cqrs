using AutoMapper;
using AWSServerless.Domain.BTOs;
using AWSServerless.Domain.Contexts;
using AWSServerless.Domain.DTOs;
using AWSServerless.Domain.Queries.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Queries.Student
{
    public class StudentQueries : IStudentQueries
    {
        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public StudentQueries(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            Entities.Student brand = await _context.Students.FindAsync(id);

            return _mapper.Map<Entities.Student, StudentDto>(brand);
        }

        public async Task<StudentDto> GetByIdAsync(int id, params Expression<Func<Entities.Student, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<TableResult<StudentDto>> GetManyAsync(
            Expression<Func<Entities.Student, bool>> where,
            int skip = 0,
            int limit = 1000,
            string propName = "-",
            string sortDir = "-",
            params Expression<Func<Entities.Student, object>>[] includes
        )
        {
            IQueryable<Entities.Student> query = _context.Students.Where(where);

            int count = await query.CountAsync();

            query = TableOperations.SetupForTable(query, skip, limit, propName, sortDir);

            if (includes != null && includes.Count() > 0)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }

            var queryResults = await query.ToListAsync();

            TableResult<StudentDto> result = new TableResult<StudentDto>()
            {
                Values = _mapper.Map<IList<Entities.Student>, IList<StudentDto>>(queryResults),
                Count = count
            };

            return result;
        }

    }
}
