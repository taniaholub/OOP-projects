using Lecture_23_10_2023.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository.Base
{
    public interface ISubjectRepository
    {
        public void Create(SubjectEntity subject);
        public IEnumerable<SubjectEntity> Read();
        public void Update(SubjectEntity subject);
        public void Delete(int ID);
    }
}
