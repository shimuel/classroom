using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Resolvers;
using ClassroomApp.Model;
using ClassroomApp.Services;

namespace ClassroomApp.Types
{
    public class Query
    {
        private readonly IClassroomService _repository;

        public Query(IClassroomService repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            var departments = _repository.GetAllDepartments();
            foreach (Department  department in departments)
            {
                yield return department;
            }
        }

        public IEnumerable<Department> GetDepartments(string[] departments, IResolverContext context)
        {
            foreach (string deptId in departments)
            {
                Department dept = _repository.GetDepartment(deptId);
                if (dept == null)
                {
                    context.ReportError(
                        "Could not resolve a department for the " +
                        $"department-id {deptId}.");
                }
                else
                {
                    yield return dept;
                }
            }
        }

        public IEnumerable<Student> GetStudents([Parent]Department department, IResolverContext context)
        {
            var dept = _repository.GetDepartment(department.Id);
            if (dept == null)
            {
                context.ReportError(
                    "Could not resolve a department for the " +
                    $"department-id {department.Id}.");
            }
            else
            {
                foreach (var s in dept.Students)
                {
                    yield return s;
                }
            }
        }
        public IEnumerable<Subject> GetSubjects([Parent]Student student, IResolverContext context)
        {
            foreach (var subj in student.Subjects)
            {
                yield return subj;
            }
        }

        // public IEnumerable<Subject> GetSubjects(string deptId, int stuId, IResolverContext context)
        // {
        //     var subjs = _repository.GetSubjects(deptId, stuId);
        //     if (subjs == null)
        //     {
        //         context.ReportError(
        //             "Could not resolve a subjects for the " +
        //             $"department-id {deptId} & student-id {stuId}.");
        //     }
        //     foreach (var subj in subjs)
        //     {
        //         yield return subj;
        //     }
        // }
    }
}
