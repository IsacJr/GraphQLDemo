using GraphQLDemo.Domain;

namespace GraphQLDemo.Web
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents any user");

            descriptor.Field(p => p.PhoneNumber).Ignore();
        }
    }
}