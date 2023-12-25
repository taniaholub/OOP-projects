using Lecture_23_10_2023_Alt.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt
{
    public class SubjectFactory
    {
        public void SetSubjects(Group group)
        {
            foreach (IStudent student in group.Students)
            {
                student.Subjects = new List<Subject>
                {
                    new Subject(){ID=1},
                    new Subject(){ID=2},
                    new Subject(){ID=3},
                };
            }
        }
    }
}
