using System.Threading.Tasks;
using System.Collections.Generic;
using ClassroomApp.Model;

namespace ClassroomApp.Services
{
    public interface IClassroomService
    {
         Student AddStudent(Student student, Department department);

        Department AddDepartment(Department department);

        Subject AddSubject(Subject subject, Student student, Department department);

        IList<Department> GetAllDepartments();

        Department GetDepartment(string name);
        IList<Student> GetStudents(string department);
        IList<Subject> GetSubjects(string department, int student);
    }
}