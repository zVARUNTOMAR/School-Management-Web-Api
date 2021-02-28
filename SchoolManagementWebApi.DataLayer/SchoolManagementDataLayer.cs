using SchoolManagementWebApi.DataLayer.Models;
using SchoolManagementWebApi.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementWebApi.DataLayer
{
    public class SchoolManagementDataLayer : ISchoolManagementDataLayer
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;

        public SchoolManagementDataLayer(SchoolManagementDbContext schoolManagementDbContext)
        {
            _schoolManagementDbContext = schoolManagementDbContext;
        }

        public School AddSchool(School school)
        {
            SchoolModel schoolModel = new SchoolModel();

            schoolModel.SchoolId = school.SchoolId;
            schoolModel.Name = school.Name;
            schoolModel.Address = school.Address;

            _schoolManagementDbContext.schools.Add(schoolModel);
            _schoolManagementDbContext.SaveChanges();
            return school;
        }

        public School ShowSchoolRecord(int id)
        {
            SchoolModel schoolModel = _schoolManagementDbContext.schools.Find(id);

            School school = new School();

            school.SchoolId = schoolModel.SchoolId;
            school.Name = schoolModel.Name;
            school.Address = school.Address;

            return school;
        }

        public List<School> ShowSchools()
        {
            List<SchoolModel> schoolModels = _schoolManagementDbContext.schools.ToList();

            List<School> schools = new List<School>();

            foreach (var item in schoolModels)
            {
                School school = new School();

                school.SchoolId = item.SchoolId;
                school.Name = item.Name;
                school.Address = item.Address;

                schools.Add(school);
            }

            return schools;
        }

        public School UpdateSchool(School school)
        {
            var existingSchool = _schoolManagementDbContext.schools.Find(school.SchoolId);
            if (existingSchool != null)
            {
                existingSchool.Name = school.Name;
                existingSchool.Address = school.Address;
                _schoolManagementDbContext.schools.Update(existingSchool);
                _schoolManagementDbContext.SaveChanges();
            }

            return school;
        }

        //Teacher
        public Teacher AddTeacher(Teacher teacher)
        {
            TeacherModel teacherModel = new TeacherModel();

            teacherModel.TeacherId = teacher.TeacherId;
            teacherModel.Name = teacher.Name;
            teacherModel.SubjectId = teacher.SubjectId;
            teacherModel.SchoolId = teacher.SchoolId;

            teacherModel.school = _schoolManagementDbContext.schools.Find(teacher.SchoolId);
            teacherModel.subject = _schoolManagementDbContext.subjects.Find(teacher.SubjectId);

            _schoolManagementDbContext.teachers.Add(teacherModel);
            _schoolManagementDbContext.SaveChanges();

            return teacher;
        }

        public List<Teacher> ShowTeachers()
        {
            List<TeacherModel> teacherModels = _schoolManagementDbContext.teachers.ToList();

            List<Teacher> teachers = new List<Teacher>();

            foreach (var item in teacherModels)
            {
                Teacher teacher = new Teacher();

                teacher.TeacherId = item.TeacherId;
                teacher.Name = item.Name;
                teacher.SubjectId = item.SubjectId;
                teacher.SchoolId = item.SchoolId;

                SchoolModel schoolModel = _schoolManagementDbContext.schools.Find(item.SchoolId);
                teacher.school = new School();
                teacher.school.SchoolId = schoolModel.SchoolId;
                teacher.school.Name = schoolModel.Name;
                teacher.school.Address = schoolModel.Address;

                SubjectModel subjectModel = _schoolManagementDbContext.subjects.Find(item.SubjectId);
                teacher.subject = new Subject();
                teacher.subject.SubjectId = subjectModel.SubjectId;
                teacher.subject.SubjectName = subjectModel.SubjectName;

                teachers.Add(teacher);
            }

            return teachers;
        }

        public List<Teacher> ShowTeachersInSchool(int id)
        {
            List<TeacherModel> teacherModels = (from t in _schoolManagementDbContext.teachers where t.SchoolId == id select t).ToList();
            List<Teacher> teachers = new List<Teacher>();

            foreach (var item in teacherModels)
            {
                Teacher teacher = new Teacher();

                teacher.TeacherId = item.TeacherId;
                teacher.Name = item.Name;
                teacher.SubjectId = item.SubjectId;
                teacher.SchoolId = item.SchoolId;

                SchoolModel schoolModel = _schoolManagementDbContext.schools.Find(item.SchoolId);
                teacher.school = new School();
                teacher.school.SchoolId = schoolModel.SchoolId;
                teacher.school.Name = schoolModel.Name;
                teacher.school.Address = schoolModel.Address;

                SubjectModel subjectModel = _schoolManagementDbContext.subjects.Find(item.SubjectId);
                teacher.subject = new Subject();
                teacher.subject.SubjectId = subjectModel.SubjectId;
                teacher.subject.SubjectName = subjectModel.SubjectName;

                teachers.Add(teacher);
            }

            return teachers;
        }

        public Teacher ShowTeacherRecord(int id) {

            TeacherModel teacherModel = _schoolManagementDbContext.teachers.Find(id);

            Teacher teacher = new Teacher();

            teacher.TeacherId = teacherModel.TeacherId;
            teacher.Name = teacherModel.Name;
            teacher.SubjectId = teacherModel.SubjectId;
            teacher.SchoolId = teacherModel.SchoolId;

            SchoolModel schoolModel = _schoolManagementDbContext.schools.Find(teacherModel.SchoolId);
            teacher.school = new School();
            teacher.school.SchoolId = schoolModel.SchoolId;
            teacher.school.Name = schoolModel.Name;
            teacher.school.Address = schoolModel.Address;

            SubjectModel subjectModel = _schoolManagementDbContext.subjects.Find(teacherModel.SubjectId);
            teacher.subject = new Subject();
            teacher.subject.SubjectId = subjectModel.SubjectId;
            teacher.subject.SubjectName = subjectModel.SubjectName;

            return teacher;
        }

        public bool DeleteTeacher(int id)
        {
            _schoolManagementDbContext.teachers.Remove(_schoolManagementDbContext.teachers.Find(id));
            _schoolManagementDbContext.SaveChanges();

            return true;
        }

        public bool DeleteSchool(int id) {
            _schoolManagementDbContext.schools.Remove(_schoolManagementDbContext.schools.Find(id));
            _schoolManagementDbContext.SaveChanges();

            return true;
        }
    }
}