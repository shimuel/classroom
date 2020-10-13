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
    public class QueryType: ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            // descriptor.Field(t => t.GetAllDepartments())
            //     .Type<NonNullType<ListType<NonNullType<DepartmentType>>>>();

            // descriptor.Field(t => t.GetDepartments(default, default))
            //     .Type<NonNullType<ListType<NonNullType<DepartmentType>>>>();

            // descriptor.Field(r => r.GetStudents(default, default))
            //     .Name("students")
            //     .Type<NonNullType<ListType<NonNullType<StudentType>>>>()
            //     .Argument("deptId", a => a.DefaultValue("Engg"));

            // descriptor.Field(t => t.GetSubjects(default, default, default))
            //     .Name("subjects")
            //     .Type<NonNullType<ListType<NonNullType<SubjectType>>>>()
            //     .Argument("deptId", a => a.DefaultValue("Engg"))
            //     .Argument("stuId", a => a.DefaultValue(6));
        }
    }
}