using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Entity
{
    public class SubjectEntity
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int FinishedLectures { get; set; }
        public int LecturesCount { get; set; }
        public int FinishedPracteces { get; set; }
        public int PracticeCount { get; set; }
    }
}
