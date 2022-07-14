using GraphQLDemo.Domain;
using GraphQLDemo.Infrastructure;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQLDemo.Web
{

    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUser([ScopedService] ApplicationDbContext context)
        {
            return context.Users;
        }
    }
}