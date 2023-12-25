using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Entities
{
    public class SubjectEntity
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; }
        public int LectureCount { get; }
        public int FinishedLectures { get; set; }
        public int PracticeCount { get; }
        public int FinishedPracteces { get; set; }
        public string Teacher { get; set; }

    }
}
