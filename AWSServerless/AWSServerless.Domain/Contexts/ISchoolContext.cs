using AWSServerless.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Contexts
{
    public interface ISchoolContext
    {

        #region DbSets

        DbSet<Classroom> Classrooms { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentClassroom> StudentClassrooms { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        #endregion DbSets

        #region Public Properties

        /// <summary>
        /// Not sure how to expose ability to do SPs without exposing this.
        /// </summary>
        DbContext Context { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Commits tracked entities to the database.
        /// </summary>
        /// <returns>number of records changed/edited</returns>
        Task<int> Commit();

        #endregion Public Methods


    }
}
