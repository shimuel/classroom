using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ClassroomApp.Model;

namespace ClassroomApp.Services
{
    public class ClassroomService : IClassroomService
    {
        private IList<Department> _departments = new List<Department>();

        public ClassroomService()
        {
           _departments = new List<Department>();
            Guid phy = Guid.NewGuid();
            Guid chem = Guid.NewGuid();
            Guid bio = Guid.NewGuid();
            Guid cacl = Guid.NewGuid();
            Guid math = Guid.NewGuid();
            Guid lang = Guid.NewGuid();
            Guid arts = Guid.NewGuid();

            _departments.Add(new Department(){ Id= "sci", Name = "Science", Students = new List<Student> {
                    new Student(){
                        Id = 1,
                        Name = "Jon Doe",
                        Grade = "1",
                        Subjects = new List<Subject> {
                            new Subject(){Id = phy, Name = "Phy"},
                            new Subject(){Id = chem, Name = "Chem"},
                            new Subject(){Id = bio, Name = "Bio"}
                        }
                    },
                    new Student(){
                        Id = 2,
                        Name = "Alice Paul",
                        Grade = "2",
                        Subjects = new List<Subject> {
                            new Subject(){Id = chem, Name = "Chem"}
                        } 
                    },
                    new Student(){
                        Id = 3,
                        Name = "Rob Barr",
                        Grade = "2",
                        Subjects = new List<Subject> {
                            new Subject(){Id = bio, Name = "Bio"}
                        }
                    }
                },Professor = new Professor(){Id=7,Name="Ken", Employment = EmploymentStatus.FullTime}
            });
            _departments.Add(new Department(){ Id= "eng", Name = "Eng", Students = new List<Student> {
                    new Student(){
                        Id = 3,
                        Name = "Doe Doe",
                        Grade = "1",
                        Subjects = new List<Subject> {
                            new Subject(){Id = lang, Name = "Language"}
                        } 
                    },
                    new Student(){
                        Id = 4,
                        Name = "Paul Paul",
                        Grade = "2",
                        Subjects = new List<Subject> {
                            new Subject(){Id = arts, Name = "Arts"}
                        } 
                    },
                    new Student(){
                        Id = 5,
                        Name = "Bar Barr",
                        Grade = "2",
                         Subjects = new List<Subject> {
                            new Subject(){Id = lang, Name = "Language"},
                            new Subject(){Id = arts, Name = "Arts"}
                        }
                    }
                }, Professor = new Professor(){Id=8,Name="Dorothy", Employment = EmploymentStatus.PartTime, Height=1.8d}
            });
            _departments.Add(new Department()
            {
                Id = "engg",
                Name = "Engineering",
                Students = new List<Student> { new Student() { Id = 6, Name = "Bar Barr", Grade = "2", Subjects = new List<Subject> { new Subject() { Id = cacl, Name = "Calculus" }, new Subject() { Id = math, Name = "Discrete Math" } } } },
                Professor = new Professor() { Id = 8, Name = "Jim", Employment = EmploymentStatus.FullTime, Height = 1.69d }
            });
        }

        public Department AddDepartment(Department department){
            var dObj = _departments.Single( d => d.Id ==  department.Name);
            if(dObj == null)
            {
                _departments.Add(department);
                return department;
            }
            return null;
        }
        public Subject AddSubject(Subject subject, Student student, Department department){
            var dObj = _departments.Single( d => d.Name ==  department.Name);
            var sObj = dObj.Students.Single( s => s.Name ==  student.Name);
            if(sObj != null)
            {
                sObj.Subjects.Add(subject);
                return subject;
            }
            return null;
        }
        public Student AddStudent(Student student, Department department)
        {
            if(student != null)
            {
                var dObj = _departments.Single( d => d.Name ==  department.Name);
                dObj.Students.Add(student);
                return student;
            }

            return null;
        }
        public  IList<Student> GetStudents(string department){
            //await Task.Delay(5000).ConfigureAwait(false);
            return _departments.Single( d => d.Id ==  department).Students;
        }

        public  IList<Subject> GetSubjects(string department, int student){
            //await Task.Delay(5000).ConfigureAwait(false);
            return _departments.Single( d => d.Id ==  department).Students.Single(s => s.Id == student).Subjects;
        }

        public  Department GetDepartment(string department){
            //await Task.Delay(5000).ConfigureAwait(false);
            return _departments.Single( d => d.Id ==  department);
        }

        public IList<Department> GetAllDepartments()
        {
            //await Task.Delay(5000).ConfigureAwait(false);
            return _departments;
        }
    }
}