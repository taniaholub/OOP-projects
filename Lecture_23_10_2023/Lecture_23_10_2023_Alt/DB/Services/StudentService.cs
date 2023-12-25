using Lecture_23_10_2023_Alt.DB.Entity;
using Lecture_23_10_2023_Alt.DB.Repositories;
using Lecture_23_10_2023_Alt.DB.Repositories.Base;
using Lecture_23_10_2023_Alt.DB.Services.Base;
using Lecture_23_10_2023_Alt.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_23_10_2023_Alt.DB.Services
{
    public class StudentService:IStudentService
    {
        private IStudentRepository studentRepository;
        private ISubjectRepository subjectRepository;
        public StudentService(DbContext context)
        {
            studentRepository = new StudentRepository(context);
            subjectRepository = new SubjectRepository(context);
        }

        public bool AddStudent(IStudent student, StudentType studentType)
        {
            studentRepository.Create(
                new StudentEntity()
                {
                    ID = student.ID,
                    GroupId = student.GroupId,
                    Type = studentType
                });
            return true;
        }

        public List<IStudent> GetGroupStudents(int groupId)
        {
            List<StudentEntity> studentEntities = studentRepository.Read()
                                                    .Where(student => student.GroupId == groupId)
                                                    .ToList();
            return Map(studentEntities);
        }

        public List<IStudent> GetStudents()
        {
            List<StudentEntity> studentEntities = studentRepository.Read();
            return Map(studentEntities);
        }

        private List<IStudent> Map(List<StudentEntity> studentEntities)
        {
            List<IStudent> students = new List<IStudent>();
            foreach (StudentEntity entity in studentEntities)
            {
                IStudent student;
                if (entity.Type == StudentType.STUDENT)
                    student = new Student();
                else
                    student = new OnlineStudent();
                student.ID = entity.ID;
                student.Name = entity.Name;
                student.GroupId = entity.GroupId;
                List<SubjectEntity> subjects = subjectRepository.Read()
                                                    .Where(subject => subject.StudentID == entity.ID)
                                                    .ToList();
                student.Subjects = subjects.Select(subject => Map(subject)).ToList();
                students.Add(student);
            }


            return students;
        }

        private Subject Map(SubjectEntity subject)
        {
            return new Subject()
            {
                ID = subject.ID,
                Name = subject.Name,
                FinishedLectures = subject.FinishedLectures,
                FinishedPracteces = subject.FinishedPracteces,
                LecturesCount = subject.LecturesCount,
                PracticeCount = subject.PracticeCount,
                Teacher = subject.Teacher
            };
        }
    }
}
