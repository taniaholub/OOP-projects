using Lecture_23_10_2023.DB;
using Lecture_23_10_2023.DB.Services;
using Lecture_23_10_2023.DB.Services.Base;
using Lecture_23_10_2023.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.UI
{
    public class GroupInfoUI : IUserInterface
    {
        IGroupService groupService; 
        IStudentService studentService;
        public GroupInfoUI(DbContext context)
        {
            groupService = new GroupService(context);
            studentService = new StudentService(context);
        }
        public string Action()
        {
            var groups = groupService.GetAllGroups();
            string result = "";
            foreach (var group in groups)
            {
                group.Students = studentService.GetGroupStudents(group.ID);
                result += group.GetInfo() + "\n";
            }
            return result;
        }

        public string Show()
        {
            return "Show groups info.";
        }
    }
}
