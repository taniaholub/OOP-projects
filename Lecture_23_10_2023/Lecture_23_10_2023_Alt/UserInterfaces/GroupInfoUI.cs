using Lecture_23_10_2023_Alt.DB;
using Lecture_23_10_2023_Alt.DB.Services;
using Lecture_23_10_2023_Alt.DB.Services.Base;
using Lecture_23_10_2023_Alt.UserInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.UserInterfaces
{
    public class GroupInfoUI : IUserInterface
    {
        IGroupService groupService;

        public GroupInfoUI(DbContext context)
        {
            groupService = new GroupService(context);
        }
        public string Action()
        {
            string result = "";
            foreach (var group in groupService.GetGroups())
            {
                result += group.GetInfo() + "\n";
            }
            return result;
        }

        public string Show()
        {
            return "Show all groups info.";
        }
    }
}
