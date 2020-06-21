using System.Collections.Generic;

namespace ClassroomApp.Services
{
    interface IClassroomService
    {
        bool AddStudent(Student student);

        IEnumerable<Student> GetAllStudents();
    }
}