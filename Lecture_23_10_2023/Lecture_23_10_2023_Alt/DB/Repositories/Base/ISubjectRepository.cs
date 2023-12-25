using Lecture_23_10_2023_Alt.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories.Base
{
    public interface ISubjectRepository
    {
        public void Create(SubjectEntity entity);
        public List<SubjectEntity> Read();
        public SubjectEntity Update(SubjectEntity entity);
        public void Delete(SubjectEntity entity);
    }
}
