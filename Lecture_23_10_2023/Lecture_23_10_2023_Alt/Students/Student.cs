using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.Students
{
    public class Student : IStudent
    {
        public int ID { get; set; }
        public string Name { get ; set ; }
        public List<Subject> Subjects { get ; set ; }
        public int GroupId { get; set; }

        public string GetInfo()
        {
            return $"ID: {ID}. Group: {GroupId}";

        }

        public void Study()
        {
            throw new NotImplementedException();
        }

        public string SubjectsInfo()
        {
            string result = $"Student id:{ID}. Subjects:";
            foreach (var subject in Subjects)
            {
                result += subject.ID + ", ";
            }
            return result;
        }
    }
}
