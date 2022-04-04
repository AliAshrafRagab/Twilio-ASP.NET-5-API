using AutoMapper;
using Twilio.Application.Features.Products.Commands.Create;
using Twilio.Application.Features.Products.Queries.GetAllCached;
using Twilio.Application.Features.Products.Queries.GetAllPaged;
using Twilio.Application.Features.Products.Queries.GetById;
using Twilio.Domain.Entities.Catalog;

namespace Twilio.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}