using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.Students
{
    public class OnlineStudent : IStudent
    {
        public int ID { get ; set ; }
        public string Name { get ; set ; }
        public List<Subject> Subjects { get ; set; }
        public int GroupId { get ; set ; }

        public string GetInfo()
        {
            return $"This is Online student with ID {ID}";
        }

        public void Study()
        {
            throw new NotImplementedException();
        }

        public string SubjectsInfo()
        {
            return "No info";
        }
    }
}
