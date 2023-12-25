using Lecture_23_10_2023.DB;
using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Services;
using Lecture_23_10_2023.DB.Services.Base;
using Lecture_23_10_2023.Students;
using Lecture_23_10_2023.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.UI
{
    public class AddStudentUI: IUserInterface
    {
        IStudentService studentService;
        public AddStudentUI(DbContext context)
        {
            studentService = new StudentService(context);
        }
      

        public string Action()
        {
            Console.WriteLine("Enter student type: [Standart, Online]");
            string studentType = Console.ReadLine();
            IStudent student;
            StudentType studentTypeEnum;
            if (studentType[0] != 'S' && studentType[0] != 'O')
                return "Can`t create user. Unknown student type.";
            if (studentType[0] == 'S')
            {
                student = new Student();
                studentTypeEnum = StudentType.STUDENT;
            }
            else
            {
                student = new OnlineStudent();
                studentTypeEnum = StudentType.ONLINE_STUDENT;
            }

            Console.WriteLine("Enter student id");
            int id;
            var validId = int.TryParse(Console.ReadLine(), out id);
            if (!validId)
                return "Can`t create user. Invalid ID.";
            Console.WriteLine("Enter student group id");
            int groupId;
            validId = int.TryParse(Console.ReadLine(), out groupId);
            if (!validId)
                return "Can`t create user. Invalid group ID.";
            student.ID = id;
            student.GroupId = groupId;
            try
            {
                var result = studentService.AddStudent(student, studentTypeEnum);
                return "Student added";
            }
            catch (Exception e)
            {
                return $"Can`t add user. {e.Message}";
            }
    }

        public string Show()
        {
            return "Add student.";
        }
    }
}
