using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.Students
{
    public interface IStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public int GroupId { get; set; }
        public void Study();
        public string SubjectsInfo();
        public string GetInfo();

    }
}
