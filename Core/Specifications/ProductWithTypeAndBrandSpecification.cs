using Core.Entities;

namespace Core.Specifications;

public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
{
    public ProductWithTypeAndBrandSpecification(ProductSpecParams productParam)
    : base(c => 
    (!string.IsNullOrEmpty(productParam.Search) || c.Name.ToLower().Contains(productParam.Search))&&
    (!productParam.BrandId.HasValue || c.ProductBrandId == productParam.BrandId) &&
    (!productParam.TypeId.HasValue || c.ProductTypeId == productParam.TypeId))
    {
        AddInclude(c => c.ProductType);
        AddInclude(c => c.ProductBrand);
        AddOrderBy(c => c.Name);
        ApplyPaging(productParam.PageSize * (productParam.PageIndex - 1), productParam.PageSize);
        if (!string.IsNullOrEmpty(productParam.Sort))
        {
            switch (productParam.Sort)
            {
                case "priceAsc":
                    AddOrderBy(c => c.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(c => c.Price);
                    break;
                default:
                    AddOrderBy(c => c.Name);
                    break;
            }
        }
    }

    public ProductWithTypeAndBrandSpecification(int id) : base(c => c.Id == id)
    {
        AddInclude(c => c.ProductType);
        AddInclude(c => c.ProductBrand);
    }
}
