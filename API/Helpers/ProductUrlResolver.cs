using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
{
    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
        throw new NotImplementedException();
    }
}
