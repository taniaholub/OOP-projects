using Lecture_23_10_2023.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023
{
    public class Group
    {
        public List<IStudent> Students { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

        public Group()
        {
           
        }
    
        public string GetInfo()
        {
            string result = $"Info of group {ID}:\n";
            foreach (var student in Students)
            {
                result += student.GetInfo() +"\n";
            }
            return result;
        }
        

    }
}
