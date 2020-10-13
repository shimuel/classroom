
using HotChocolate.Types;
using ClassroomApp.Model;

namespace ClassroomApp.Types
{
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
}