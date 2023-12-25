using Lecture_23_10_2023_Alt.DB;
using Lecture_23_10_2023_Alt.DB.Services;
using Lecture_23_10_2023_Alt.DB.Services.Base;
using Lecture_23_10_2023_Alt.Students;
using Lecture_23_10_2023_Alt.UserInterfaces;
using Lecture_23_10_2023_Alt.UserInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture_23_10_2023_Alt
{
    class Main
    {
        public List<IUserInterface> Setup()
        {
            DbContext context = new DbContext() ;
            return new List<IUserInterface> {
                new ShowAllStudentsUI(context),
                new GroupInfoUI(context)
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uis = new Main().Setup();
            while (true)
            {
                for (int i = 0; i < uis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {uis[i].Show()}");
                }
                int actionIndex;
                var key = Console.ReadLine();
                if (key=="q")
                {
                    return;
                }
                var isInt = int.TryParse(key, out actionIndex);
                if (isInt == true && actionIndex > 0 && actionIndex <= uis.Count)
                {
                    Console.WriteLine(uis[actionIndex - 1].Action());
                }
                else
                    Console.WriteLine($"Invalid value {key}.");

            }
        }

        static void Showcase()
        {
            List<IStudent> students = new List<IStudent>()
            {
                new Student(){ID=1 },
                new Student(){ID=2 }
            };
            List<Subject> subjects = new List<Subject>
            {
                new Subject(){ID=1},
                new Subject(){ID=2},
                new Subject(){ID=3},
            };
            foreach (var student in students)
            {
                //student.Subjects = subjects;
                student.Subjects = subjects.ToList();
            }
            foreach (var student in students)
            {
                Console.WriteLine(student.SubjectsInfo());
            }
            students[0].Subjects.Add(new Subject() { ID = 734 });
            students[0].Subjects[1].ID = 123;

            students[1].Subjects[0].ID = 993;
            foreach (var student in students)
            {
                Console.WriteLine(student.SubjectsInfo());
            }
            Console.WriteLine("Hello World!");
        }
    }
}
