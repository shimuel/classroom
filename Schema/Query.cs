using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Resolvers;
using ClassroomApp.Model;
using ClassroomApp.Services;

namespace ClassroomApp.Types
{
    public class DepartmentType : ObjectType<Department>
    {
        protected override void Configure(IObjectTypeDescriptor<Department> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field<SharedResolver>(r => r.GetRStudents(default, default))
                .Name("students")
                .Type<ListType<StudentType>>();

            descriptor.Field(t => t.Professor)
                .Type<NonNullType<ProfessorType>>();
        }
    }

    public class PersonType : InterfaceType<IPerson>
    {
        protected override void Configure(IInterfaceTypeDescriptor<IPerson> descriptor)
        {
            descriptor.Name("Character");

            descriptor.Field(f => f.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Name)
                .Type<StringType>();

            descriptor.Field(f => f.Height)
                .Type<FloatType>()
                .Argument("unit", a => a.Type<EnumType<Unit>>());
        }
    }
    public class ProfessorType : ObjectType<Professor>
    {
        protected override void Configure(IObjectTypeDescriptor<Professor> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Employment)
                .Type<NonNullType<EnumType<EmploymentStatus>>>()
                .Name("employment");

            descriptor.Field<SharedResolver>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<EnumType<Unit>>())
                .Name("height");
        }
    }
    public class StudentType : ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Grade)
                .Type<NonNullType<StringType>>();

            descriptor.Field<SharedResolver>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<EnumType<Unit>>())
                .Name("height");

            // descriptor.Field(t => t.Subjects)
            //     .Type<ListType<SubjectType>>();
        }
    }

    public class SubjectType : ObjectType<Subject>
    {
        protected override void Configure(IObjectTypeDescriptor<Subject> descriptor)
        {
            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();
        }
    }

    public class QueryType: ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetDepartments(default, default))
                .Type<NonNullType<ListType<NonNullType<DepartmentType>>>>();

            descriptor.Field(r => r.GetStudents(default, default))
                //.Type<SubjectType>()
                .Name("students")
                .Type<NonNullType<ListType<NonNullType<StudentType>>>>()
                .Argument("deptId", a => a.DefaultValue("Engg"));

            descriptor.Field(t => t.GetSubjects(default, default, default))
                .Name("subjects")
                .Type<NonNullType<ListType<NonNullType<SubjectType>>>>()
                .Argument("deptId", a => a.DefaultValue("Engg"))
                .Argument("stuId", a => a.DefaultValue(6));
        }
    }

    public class Query
    {
        private readonly IClassroomService _repository;

        public Query(IClassroomService repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
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

        public IEnumerable<Student> GetStudents(string deptId, IResolverContext context)
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
                foreach (var s in dept.Students)
                {
                    yield return s;
                }
            }
        }

        public IEnumerable<Subject> GetSubjects(string deptId, int stuId, IResolverContext context)
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
                var subjs = _repository.GetSubjects(deptId, stuId);
                foreach (var subj in subjs)
                {
                    yield return subj;
                }
            }
        }
    }
}
