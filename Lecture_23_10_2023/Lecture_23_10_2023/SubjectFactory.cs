using Lecture_23_10_2023.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023
{
    public class SubjectFactory
    {
        public void CreateSubjectsForGroup1(Group group)
        {
            foreach (var student in group.Students)
            {
                student.Subjects = new List<Subject>
                {
                    new Subject(0, "Math", 15, 5),
                    new Subject(1, "Prog", 20, 10),
                    new Subject(2, "Engl", 10, 10)
                };
            }
        }
   

        public List<Subject> CreateSubjectsForGroup1(string pathToFile)
        {
            //parse file
            return new List<Subject>
            {
              
            };
        }
    }
}
