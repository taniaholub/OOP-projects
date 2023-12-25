using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private DbContext context;
        public GroupRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(GroupEntity group)
        {
            context.Groups.Add(group);
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupEntity> Read()
        {
            return context.Groups;
        }

        public void Update(GroupEntity group)
        {
            throw new NotImplementedException();
        }
    }
}
