using Lecture_23_10_2023.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.Students
{
    public class OnlineStudent : IStudent
    {
        public int ID { get; set; }

        public List<Subject> Subjects { get ; set ; }
        public int GroupId { get ; set ; }

        public string GetInfo()
        {
            return "No info on OnlineStudent";

        }

        public void Study(int subjectId)
        {
            var subject = Subjects.FirstOrDefault(subject => subject.ID == subjectId);
            if (subject != null)
                subject.FinishedLectures += 1;
        }

    }
}
