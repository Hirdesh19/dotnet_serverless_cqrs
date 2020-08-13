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
using System.Threading.Tasks;

namespace AWSServerless.Domain.Queries.Classroom
{
    public class ClassroomQueries : IClassroomQueries
    {
        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public ClassroomQueries(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClassroomDto> GetByIdAsync(int id)
        {
            Entities.Classroom brand = await _context.Classrooms.FindAsync(id);

            return _mapper.Map<Entities.Classroom, ClassroomDto>(brand);
        }

        public async Task<ClassroomDto> GetByIdAsync(int id, params Expression<Func<Entities.Classroom, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<TableResult<ClassroomDto>> GetManyAsync(
            Expression<Func<Entities.Classroom, bool>> where,
            int skip = 0,
            int limit = 1000,
            string propName = "-",
            string sortDir = "-",
            params Expression<Func<Entities.Classroom, object>>[] includes
        )
        {
            IQueryable<Entities.Classroom> query = _context.Classrooms.Where(where);

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

            TableResult<ClassroomDto> result = new TableResult<ClassroomDto>()
            {
                Values = _mapper.Map<IList<Entities.Classroom>, IList<ClassroomDto>>(queryResults),
                Count = count
            };

            return result;
        }
    }
}