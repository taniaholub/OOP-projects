using Lecture_23_10_2023.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Services.Base
{
    public interface IStudentService
    {
        public List<IStudent> GetAllStudents();
        public List<IStudent> GetGroupStudents(int groupID);
        public bool AddStudent(IStudent student, StudentType studentType);
    }
}
