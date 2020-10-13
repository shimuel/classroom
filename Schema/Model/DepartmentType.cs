
using HotChocolate.Types;
using ClassroomApp.Model;
using HotChocolate.Types.Relay;

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

}