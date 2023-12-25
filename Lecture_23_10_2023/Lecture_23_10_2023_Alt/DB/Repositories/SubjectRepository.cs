using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Repositories
{
    public class SubjectRepository:ISubjectRepository
    {
        private DbContext context;
        public SubjectRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(SubjectEntity entity)
        {
            context.Subjects.Add(entity);
        }

        public void Delete(SubjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<SubjectEntity> Read()
        {
            return context.Subjects;
        }

        public SubjectEntity Update(SubjectEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
