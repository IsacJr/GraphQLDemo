using GraphQLDemo.Domain;

namespace GraphQLDemo.Web
{
    public class Subscription
    {
        
        [Subscribe]
        [Topic]
        public User OnUserAdded([EventMessage] User user)
        {
            return user;
        }
    }
}