using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Repository;
using Lecture_23_10_2023.DB.Repository.Base;
using Lecture_23_10_2023.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Services
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
        public List<Group> GetAllGroups()
        {
            return groupRepository.Read().Select(group=> Map(group)).ToList();
        }

        private Group Map(GroupEntity group)
        {
            return new Group
            {
                ID = group.ID,
                Name = group.Name,
                Students = studentService.GetGroupStudents(group.ID)
            };
        }

        public List<int> GetIDs()
        {
            return groupRepository.Read().Select(group => group.ID).ToList();
        }
    }
}
