
using HotChocolate.Types;
using ClassroomApp.Model;

namespace ClassroomApp.Types
{
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
}