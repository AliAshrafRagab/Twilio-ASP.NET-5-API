using AutoMapper;
using Twilio.Application.Features.Brands.Commands.Create;
using Twilio.Application.Features.Brands.Commands.Update;
using Twilio.Application.Features.Brands.Queries.GetAllCached;
using Twilio.Application.Features.Brands.Queries.GetById;
using Twilio.Web.Areas.Catalog.Models;

namespace Twilio.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}