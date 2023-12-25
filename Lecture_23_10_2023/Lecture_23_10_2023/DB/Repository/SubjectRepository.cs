using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private DbContext context;
        public SubjectRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(SubjectEntity subject)
        {
            context.Subjects.Add(subject);
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectEntity> Read()
        {
            return context.Subjects;
        }

        public void Update(SubjectEntity subject)
        {
            throw new NotImplementedException();
        }
    }
}
