using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Entities
{
    public enum StudentType
    {
        STUDENT = 0,
        ONLINE_STUDENT = 1
    }
    public class StudentEntity
    {
        public int ID { get; set; }
        public int GroupId { get; set; }
        public StudentType Type { get; set; }


    }
}
