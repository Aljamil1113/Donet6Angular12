using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsTypeBrandSpec : BaseSpecification<Product>
    {
        public ProductsTypeBrandSpec(ProductSpecParams prodSpecParams)
            : base(x => 
            (string.IsNullOrEmpty(prodSpecParams.Search) || x.Name.ToLower().Contains(prodSpecParams.Search)) &&
            (!prodSpecParams.BrandId.HasValue || x.ProductBrandId == prodSpecParams.BrandId) &&
            (!prodSpecParams.TypeId.HasValue || x.ProductTypeId == prodSpecParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            ApplyPaging(prodSpecParams.PageSize * (prodSpecParams.PageIndex - 1), prodSpecParams.PageSize);

            if(!string.IsNullOrEmpty(prodSpecParams.Sort))
            {
                switch(prodSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsTypeBrandSpec(int id) : base(x => x.Id == id)
        {

            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
