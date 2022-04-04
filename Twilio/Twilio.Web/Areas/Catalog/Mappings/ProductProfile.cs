using AutoMapper;
using Twilio.Application.Features.Products.Commands.Create;
using Twilio.Application.Features.Products.Commands.Update;
using Twilio.Application.Features.Products.Queries.GetAllCached;
using Twilio.Application.Features.Products.Queries.GetById;
using Twilio.Web.Areas.Catalog.Models;

namespace Twilio.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}