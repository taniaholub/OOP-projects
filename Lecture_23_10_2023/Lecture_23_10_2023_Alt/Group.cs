using Lecture_23_10_2023_Alt.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt
{
    public class Group
    {
        public List<IStudent> Students { get; set; }
        public int ID { get; set; }
        public string Speciality { get; set; }

        public string GetInfo()
        {
            string info = $" Group id: {ID}. Students:\n";
            foreach (var student in Students)
            {
                info += student.GetInfo() + "\n";
            }
            return info + "\n";
        }


    }
}
