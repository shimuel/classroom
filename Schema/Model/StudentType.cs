
using HotChocolate.Types;
using ClassroomApp.Model;

namespace ClassroomApp.Types
{
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

            descriptor.Field<Query>(r => r.GetSubjects(default, default))
                .Name("subjects")
                .Type<ListType<SubjectType>>();
        }
    }
}