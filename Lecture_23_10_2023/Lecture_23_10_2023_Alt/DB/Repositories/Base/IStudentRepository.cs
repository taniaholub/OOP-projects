using Lecture_23_10_2023_Alt.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories.Base
{
    public interface IStudentRepository
    {
        public void Create(StudentEntity entity);
        public List<StudentEntity> Read();
        public StudentEntity Update(StudentEntity entity);
        public void Delete(StudentEntity entity);
    }
}
