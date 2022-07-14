using GraphQLDemo.Domain;
using GraphQLDemo.Infrastructure;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Web
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
            {
                var user = new User {
                    Name = input.Name,
                    Email = input.Name,
                    PhoneNumber = input.PhoneNumber
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                await eventSender.SendAsync(nameof(Subscription.OnUserAdded), user, cancellationToken);

                return new AddUserPayload(user);
            }
    }   
}