using AutoMapper;
using GraphQLDemo.Domain;
using GraphQLDemo.Infrastructure;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Web
{
    public class Mutation
    {
        private readonly IMapper _mapper;

        public Mutation(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
            {

                var user = _mapper.Map<User>(input);

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                await eventSender.SendAsync(nameof(Subscription.OnUserAdded), user, cancellationToken);

                return new AddUserPayload(user);
            }
    }   
}