using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private DbContext context;
        public GroupRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(GroupEntity entity)
        {
            context.Groups.Add(entity);
        }

        public void Delete(GroupEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<GroupEntity> Read()
        {
            return context.Groups;
        }

        public GroupEntity Update(GroupEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
