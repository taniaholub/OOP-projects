using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB
{
    public class DbContext
    {
        public List<StudentEntity> Students { get; set; }
        public List<GroupEntity> Groups { get; set; }
        public List<SubjectEntity> Subjects { get; set; }

        public DbContext()
        {
            Subjects = new List<SubjectEntity>();
            Students = new List<StudentEntity>
            {
                new StudentEntity{ID = 1, GroupId=0, Type=StudentType.STUDENT},
                new StudentEntity{ID = 2, GroupId=0, Type=StudentType.STUDENT},
                new StudentEntity{ID = 3, GroupId=0, Type=StudentType.STUDENT},
                new StudentEntity{ID = 4, GroupId=0, Type=StudentType.ONLINE_STUDENT},
                new StudentEntity{ID = 5, GroupId=0, Type=StudentType.STUDENT},
                new StudentEntity{ID = 6, GroupId=1, Type=StudentType.STUDENT},
                new StudentEntity{ID = 7, GroupId=1, Type=StudentType.ONLINE_STUDENT},
                new StudentEntity{ID = 8, GroupId=1, Type=StudentType.STUDENT},
                new StudentEntity{ID = 9, GroupId=1, Type=StudentType.ONLINE_STUDENT},
                new StudentEntity{ID = 10, GroupId=2, Type=StudentType.STUDENT},
                new StudentEntity{ID = 11, GroupId=2, Type=StudentType.ONLINE_STUDENT},
                new StudentEntity{ID = 12, GroupId=2, Type=StudentType.STUDENT},
            };
            Groups = new List<GroupEntity>
            {
                new GroupEntity{ID=0},
                new GroupEntity{ID=1},
                new GroupEntity{ID=2},
            };
        }
    }
}
