using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository
{
    public class StudentRepository : IStudentsRepository
    {
        private DbContext context;
        public StudentRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(StudentEntity student)
        {
            context.Students.Add(student);
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEntity> Read()
        {
            return context.Students;
        }

        public void Update(StudentEntity student)
        {
            var origStudent = context.Students.First(s => s.ID == student.ID);
            origStudent.GroupId = student.GroupId;
            origStudent.Type = student.Type;
        }
    }
}
