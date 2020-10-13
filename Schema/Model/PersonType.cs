
using HotChocolate.Types;
using ClassroomApp.Model;

namespace ClassroomApp.Types
{
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
}