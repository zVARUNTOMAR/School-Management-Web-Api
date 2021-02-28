using SchoolManagementWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagementWebApi.DataLayer;
using SchoolManagementWebApi.DataLayer.Models;

namespace SchoolManagementWebApi.BussinessLayer
{
    public class SchoolManagementBussinessLayer : ISchoolManagementBussinessLayer
    {
        private readonly ISchoolManagementDataLayer _schoolManagementDataLayer;
        public SchoolManagementBussinessLayer(ISchoolManagementDataLayer schoolManagementDataLayer)
        {
            _schoolManagementDataLayer = schoolManagementDataLayer;
        }
        public School AddSchool(School school)
        {
            School schoolNew = _schoolManagementDataLayer.AddSchool(school);
            return school;
        }

        public School ShowSchoolRecord(int id)
        {
            School school = _schoolManagementDataLayer.ShowSchoolRecord(id);

            return school;
        }

        public List<School> ShowSchools()
        {
            List<School> schools = _schoolManagementDataLayer.ShowSchools();
            return schools;
        }

        public School UpdateSchool(School school)
        {
            School schoolUpdated = _schoolManagementDataLayer.UpdateSchool(school);

            return school;
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            Teacher teacherNew = _schoolManagementDataLayer.AddTeacher(teacher);
            return teacher;
        }

        public List<Teacher> ShowTeachers()
        {
            List<Teacher> teachers = _schoolManagementDataLayer.ShowTeachers();
            return teachers;
        }

        public List<Teacher> ShowTeachersInSchool(int id)
        {
            List<Teacher> teachers = _schoolManagementDataLayer.ShowTeachersInSchool(id);
            return teachers;
        }

        public Teacher ShowTeacherRecord(int id)
        {
            Teacher teacher = _schoolManagementDataLayer.ShowTeacherRecord(id);
            return teacher;
        }

        public bool DeleteTeacher(int id) {

            bool flag;

            flag = _schoolManagementDataLayer.DeleteTeacher(id);

            return flag;
        }

        public bool DeleteSchool(int id)
        {
            bool flag;

            flag = _schoolManagementDataLayer.DeleteSchool(id);

            return flag;
        }
    }
}
