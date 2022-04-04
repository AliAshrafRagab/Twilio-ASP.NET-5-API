using AutoMapper;
using System.Security.Claims;
using Twilio.Web.Areas.Admin.Models;

namespace Twilio.Web.Areas.Admin.Mappings
{
    public class ClaimsProfile : Profile
    {
        public ClaimsProfile()
        {
            CreateMap<Claim, RoleClaimsViewModel>().ReverseMap();
        }
    }
}