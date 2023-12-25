using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Services.Base
{
    public interface IStudentService
    {
        public List<IStudent> GetStudents();
        public List<IStudent> GetGroupStudents(int groupId);
        public bool AddStudent(IStudent student, StudentType studentType);
    }
}
