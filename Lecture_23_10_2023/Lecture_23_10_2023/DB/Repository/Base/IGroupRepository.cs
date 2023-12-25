using Lecture_23_10_2023.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository.Base
{
    public interface IGroupRepository
    {
        public void Create(GroupEntity group);
        public IEnumerable<GroupEntity> Read();
        public void Update(GroupEntity group);
        public void Delete(int ID);
    }
}
