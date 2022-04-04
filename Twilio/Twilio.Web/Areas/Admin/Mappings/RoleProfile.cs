using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Twilio.Web.Areas.Admin.Models;

namespace Twilio.Web.Areas.Admin.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }
    }
}