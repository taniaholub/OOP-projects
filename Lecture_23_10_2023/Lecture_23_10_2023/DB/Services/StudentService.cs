using Lecture_23_10_2023.DB.Entities;
using Lecture_23_10_2023.DB.Repository;
using Lecture_23_10_2023.DB.Repository.Base;
using Lecture_23_10_2023.DB.Services.Base;
using Lecture_23_10_2023.Students;
using Lecture_23_10_2023.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023.DB.Services
{
    public class StudentService : IStudentService
    {
        private IStudentsRepository studentsRepository;
        private ISubjectRepository subjectRepository;
        private IGroupRepository groupRepository;
        public StudentService(DbContext context)
        {
            studentsRepository = new StudentRepository(context);
            subjectRepository = new SubjectRepository(context);
            groupRepository = new GroupRepository(context);
        }

        public List<IStudent> GetAllStudents()
        {
            List<StudentEntity> studentsEntites = studentsRepository.Read().ToList();
            return Map(studentsEntites);
        }

        private List<IStudent> Map(List<StudentEntity> studentsEntites)
        {
            List<IStudent> students = new List<IStudent>();
            foreach (StudentEntity studentEntity in studentsEntites)
            {
                IStudent student;
                if (studentEntity.Type == StudentType.STUDENT)
                    student = new Student();
                else
                    student = new OnlineStudent();
                student.ID = studentEntity.ID;
                student.GroupId = studentEntity.GroupId;
                List<SubjectEntity> subjectEntities = subjectRepository.Read()
                                                        .Where(x => x.StudentID == studentEntity.ID)
                                                        .ToList();
                student.Subjects = subjectEntities.Select(subject => Map(subject))
                                                  .ToList();
                students.Add(student);
            }
            return students;
        }

        private Subject Map(SubjectEntity entity) 
        {
            return new Subject(entity.ID, entity.Name, entity.LectureCount, entity.PracticeCount)
            {
                FinishedLectures = entity.FinishedLectures,
                FinishedPracteces = entity.FinishedPracteces
            };
        }

        public List<IStudent> GetGroupStudents(int groupID)
        {
            List<StudentEntity> studentsEntites = studentsRepository
                                                    .Read()
                                                    .Where(student => student.GroupId == groupID)
                                                    .ToList();
            return Map(studentsEntites);
            //return GetAllStudents().Where(student => student.GroupId == groupID).ToList();
        }

        public bool AddStudent(IStudent student, StudentType studentType)
        {
            if (!groupRepository.Read().Select(group => group.ID).Contains(student.GroupId))
                throw new ArgumentOutOfRangeException("Unknown group ID.");
            studentsRepository.Create(
                new StudentEntity
                {
                    ID=student.ID,
                    GroupId = student.GroupId, 
                    Type=studentType
                }
                );
            return true;
        }
    }
}
