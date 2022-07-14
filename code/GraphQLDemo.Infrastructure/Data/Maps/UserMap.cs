using GraphQLDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.Infrastructure
{
    public class UserMap : BaseDomainMap<User>
    {
        public UserMap() : base("user") { }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").IsRequired();
        }
    }
}