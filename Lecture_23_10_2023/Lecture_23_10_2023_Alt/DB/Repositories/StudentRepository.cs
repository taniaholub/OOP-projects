using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private DbContext context;
        public StudentRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(StudentEntity entity)
        {
            context.Students.Add(entity);
        }

        public void Delete(StudentEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<StudentEntity> Read()
        {
            return context.Students;
        }

        public StudentEntity Update(StudentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
