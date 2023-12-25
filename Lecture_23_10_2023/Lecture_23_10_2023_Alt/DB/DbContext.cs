using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB
{
    public class DbContext
    {
        public List<StudentEntity> Students { get; set; }
        public List<GroupEntity> Groups { get; set; }
        public List<SubjectEntity> Subjects { get; set; }

        public DbContext()
        {
            Subjects = new List<SubjectEntity>();
            Students = new List<StudentEntity>{
                new StudentEntity { ID = 1, GroupId=1, Type = StudentType.STUDENT },
                new StudentEntity { ID = 2, GroupId=1, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 3, GroupId=1, Type = StudentType.STUDENT },
                new StudentEntity { ID = 4, GroupId=1, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 5, GroupId=2, Type = StudentType.STUDENT },
                new StudentEntity { ID = 6, GroupId=2, Type = StudentType.STUDENT },
                new StudentEntity { ID = 7, GroupId=2, Type = StudentType.STUDENT },
                new StudentEntity { ID = 8, GroupId=2, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 9, GroupId=3, Type = StudentType.STUDENT },
                new StudentEntity { ID = 10, GroupId=3, Type = StudentType.STUDENT },
                new StudentEntity { ID = 11, GroupId=3, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 12, GroupId=3, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 13, GroupId=3, Type = StudentType.STUDENT },
                new StudentEntity { ID = 14, GroupId=3, Type = StudentType.STUDENT },
                new StudentEntity { ID = 15, GroupId=3, Type = StudentType.ONLINE_STUDENT },
                new StudentEntity { ID = 16, GroupId=3, Type = StudentType.STUDENT },
            };
            Groups = new List<GroupEntity>
            {
                new GroupEntity{ID=1},
                new GroupEntity{ID=2},
                new GroupEntity{ID=3},
            };
        }
    }
}
