using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Entity
{
    public enum StudentType
    {
        STUDENT = 1,
        ONLINE_STUDENT = 2
    }
    public class StudentEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public StudentType Type { get; set; }
    }
}
