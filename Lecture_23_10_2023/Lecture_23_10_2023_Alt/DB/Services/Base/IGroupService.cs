using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Services.Base
{
    public interface IGroupService
    {
        public List<Group> GetGroups();
        public List<int> GetGroupsIds();
    }
}
