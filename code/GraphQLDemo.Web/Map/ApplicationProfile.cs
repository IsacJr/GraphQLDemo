using AutoMapper;
using GraphQLDemo.Domain;

namespace GraphQLDemo.Web
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // Source -> Destination
            // Both Way: ReverseMap
            CreateMap<AddUserInput, User>().ReverseMap();
        }
    }
}