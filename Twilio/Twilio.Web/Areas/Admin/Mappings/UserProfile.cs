using AutoMapper;
using Twilio.Infrastructure.Identity.Models;
using Twilio.Web.Areas.Admin.Models;

namespace Twilio.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}