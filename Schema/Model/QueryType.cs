using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;


namespace ClassroomApp.Types
{
    public class QueryType: ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetAllDepartments())
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .UsePaging<NonNullType<DepartmentType>>();
                //.AddPagingArguments();
        }
    }
}