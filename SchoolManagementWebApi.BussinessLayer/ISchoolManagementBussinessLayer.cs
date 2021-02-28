using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagementWebApi.Entity;

namespace SchoolManagementWebApi.BussinessLayer
{
    public interface ISchoolManagementBussinessLayer
    {
        //School Operations

        //Add new School
        School AddSchool(School school);

        //Update School
        School UpdateSchool(School school);

        //Get School Record
        School ShowSchoolRecord(int id);

        //Show all Schools
        List<School> ShowSchools();


        //Teacher Operation

        //Add teacher
        Teacher AddTeacher(Teacher teacher);

        //Show Teachers
        List<Teacher> ShowTeachers();

        //Show Teachers in School
        List<Teacher> ShowTeachersInSchool(int id);

        //Show Teacher Record
        Teacher ShowTeacherRecord(int id);

        //Delete teacher
        bool DeleteTeacher(int id);

        //DeletSchool
        bool DeleteSchool(int id);

    }
}
