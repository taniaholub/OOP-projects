using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Repositories;
using Lecture_23_10_2023_Alt.DB.Repositories.Base;
using Lecture_23_10_2023_Alt.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository groupRepository;
        private IStudentService studentService;

        public GroupService(DbContext context)
        {
            groupRepository = new GroupRepository(context);
            studentService = new StudentService(context);
        }

        public List<Group> GetGroups()
        {
            //List<Group> groups = new List<Group>();
            //List<GroupEntity> entities = groupRepository.Read();
            //foreach (GroupEntity entity in entities)
            //{
            //    Group group = new Group
            //    {
            //        ID = entity.ID,
            //        Speciality = entity.Speciality,
            //        Students = studentService.GetGroupStudents(entity.ID)
            //    };
            //    groups.Add(group);
            //}       
            //return groups;

            return groupRepository.Read().Select(entity => new Group
            {
                ID = entity.ID,
                Speciality = entity.Speciality,
                Students = studentService.GetGroupStudents(entity.ID)
            }).ToList();
        }

        public List<int> GetGroupsIds()
        {
            return groupRepository.Read().Select(group => group.ID).ToList();
        }
    }
}
