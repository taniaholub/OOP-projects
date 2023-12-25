using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.Subjects
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; }
        public int LectureCount { get; }
        public int FinishedLectures { get; set; }
        public int PracticeCount { get; }
        public int FinishedPracteces { get; set; }
        public string Teacher { get; set; }
        public Subject(int id, string name, int lectureCount, int practiceCount)
        {
            ID = id;
            Name = name;
            LectureCount = lectureCount;
            PracticeCount = practiceCount;
        }
    }
}
