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

namespace AWSServerless.Domain.Queries.Teacher
{
    public class TeacherQueries : ITeacherQueries
    {
        private readonly ISchoolContext _context;
        private readonly IMapper _mapper;

        public TeacherQueries(
            ISchoolContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            Entities.Teacher brand = await _context.Teachers.FindAsync(id);

            return _mapper.Map<Entities.Teacher, TeacherDto>(brand);
        }

        public async Task<TeacherDto> GetByIdAsync(int id, params Expression<Func<Entities.Teacher, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<TableResult<TeacherDto>> GetManyAsync(
            Expression<Func<Entities.Teacher, bool>> where,
            int skip = 0,
            int limit = 1000,
            string propName = "-",
            string sortDir = "-",
            params Expression<Func<Entities.Teacher, object>>[] includes
        )
        {
            IQueryable<Entities.Teacher> query = _context.Teachers.Where(where);

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

            TableResult<TeacherDto> result = new TableResult<TeacherDto>()
            {
                Values = _mapper.Map<IList<Entities.Teacher>, IList<TeacherDto>>(queryResults),
                Count = count
            };

            return result;
        }
    }
}