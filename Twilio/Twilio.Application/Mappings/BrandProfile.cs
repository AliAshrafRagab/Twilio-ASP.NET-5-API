using AutoMapper;
using Twilio.Application.Features.Brands.Commands.Create;
using Twilio.Application.Features.Brands.Queries.GetAllCached;
using Twilio.Application.Features.Brands.Queries.GetById;
using Twilio.Domain.Entities.Catalog;

namespace Twilio.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}