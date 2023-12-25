using Lecture_23_10_2023_Alt.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories.Base
{
    public interface IGroupRepository
    {
        public void Create(GroupEntity entity);
        public List<GroupEntity> Read();
        public GroupEntity Update(GroupEntity entity);
        public void Delete(GroupEntity entity);
    }
}
