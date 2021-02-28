using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagementWebApi.Entity;

namespace SchoolManagementWebApi.DataLayer
{
    public interface ISchoolManagementDataLayer
    {
        //Add new School
        School AddSchool(School school);

        //Update School
        School UpdateSchool(School school);

        //Get School Record
        School ShowSchoolRecord(int id);

        //Show all Schools
        List<School> ShowSchools();


        //Teacher Operation
        Teacher AddTeacher(Teacher teacher);

        //Show Teachers
        List<Teacher> ShowTeachers();

        //Show Teachers in School
        List<Teacher> ShowTeachersInSchool(int id);

        //Show Teacher Record
        Teacher ShowTeacherRecord(int id);

        //Delete Teacher
        bool DeleteTeacher(int id);

        //DeleteSchool
        bool DeleteSchool(int id);
    }
}
