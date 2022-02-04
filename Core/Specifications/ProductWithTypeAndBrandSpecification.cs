using Core.Entities;

namespace Core.Specifications;

public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
{
    public ProductWithTypeAndBrandSpecification()
    {
        AddInclude(c => c.ProductType);
        AddInclude(c => c.ProductBrand);
    }

    public ProductWithTypeAndBrandSpecification(int id) : base(c => c.Id == id)
    {
        AddInclude(c => c.ProductType);
        AddInclude(c => c.ProductBrand);
    }
}
