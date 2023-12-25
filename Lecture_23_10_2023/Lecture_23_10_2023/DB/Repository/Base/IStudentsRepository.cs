using Lecture_23_10_2023.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository.Base
{
    public interface IStudentsRepository
    {
        public void Create(StudentEntity student);
        public IEnumerable<StudentEntity> Read();
        public void Update(StudentEntity student);
        public void Delete(int ID);
    }
}
