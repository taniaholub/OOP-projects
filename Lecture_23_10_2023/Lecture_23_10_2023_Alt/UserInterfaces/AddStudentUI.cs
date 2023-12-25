using Lecture_23_10_2023_Alt.DB;
using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Services;
using Lecture_23_10_2023_Alt.DB.Services.Base;
using Lecture_23_10_2023_Alt.Students;
using Lecture_23_10_2023_Alt.UserInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.UserInterfaces
{
    public class AddStudentUI : IUserInterface
    {
        IStudentService studentService;
        public AddStudentUI(DbContext dbContext)
        {
            studentService = new StudentService(dbContext);
        }
        public string Action()
        {
            Console.WriteLine("Select student type: [Standart, Online].");
            var key = Console.ReadLine();
            if (key[0]!='S' && key[0]!='O')
            {
                return $"Invalid student type: {key}";
            }
            IStudent student;
            StudentType studentType;
            if (key[0]=='S')
            {
                student = new Student();
                studentType = StudentType.STUDENT;
            }
            else
            {
                student = new OnlineStudent();
                studentType = StudentType.ONLINE_STUDENT;
            }
            Console.WriteLine("Enter student ID:");
            int id;
            string stringId = Console.ReadLine();
            var isId = int.TryParse(stringId, out id);
            if (isId)
                student.ID = id;
            else
                return $"Invalid ID: {stringId}";

            Console.WriteLine("Enter student group ID:");
            
            stringId = Console.ReadLine();
            isId = int.TryParse(stringId, out id);
            if (isId)
                student.GroupId = id;
            else
                return $"Invalid group ID: {stringId}";
            var isAdded = studentService.AddStudent(student, studentType);
            if (isAdded)
            {
                return "Student added.";
            }
            else
            {
                return "Can`t add student";
            }
        }

        public string Show()
        {
            return "Add student";
        }
    }
}
