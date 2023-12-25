using Lecture_23_10_2023.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.Students
{
    public class Student : IStudent
    {
        public int ID { get; set; }
        public List<Subject> Subjects { get; set; }
        public int GroupId { get; set; }
        public double BusyLevel { get; set; }
        public Student(double busyLevel = 0.2)
        {
            BusyLevel = busyLevel;
        }
        public string GetInfo()
        {
            return $"{ID} from group {GroupId}";
        }

        public void Study(int subjectId)
        {
            if (new Random().NextDouble() > BusyLevel)
            {
                var subject = Subjects.FirstOrDefault(subject => subject.ID == subjectId);
                if (subject != null)
                    subject.FinishedLectures += 1;
            }
        }
    }
}
