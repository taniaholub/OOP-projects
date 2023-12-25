using Lecture_23_10_2023.DB;
using Lecture_23_10_2023.DB.Services;
using Lecture_23_10_2023.DB.Services.Base;
using Lecture_23_10_2023.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.UI
{
    public class ShowAllStudentsUI : IUserInterface
    {
        IStudentService studentService;
        public ShowAllStudentsUI(DbContext context)
        {
            studentService = new StudentService(context);
        }
        public string Action()
        {
            string result = "";
            foreach (var student in studentService.GetAllStudents())
            {
                result += student.GetInfo() + "\n";
            }
            return result;
        }

        public string Show()
        {
            return "Show info for all students.";
        }
    }
}
