using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithCatAndLookupSpecification : BaseSpecification<Product>
    {
        public ProductsWithCatAndLookupSpecification(ProductSpecParams productSpecParams) : 
            base(x =>(string.IsNullOrEmpty(productSpecParams.Search)|| x.ProdName.ToLower()
            .Contains(productSpecParams.Search)) && 
            (!productSpecParams.CatId.HasValue || x.ProdCatId == productSpecParams.CatId))
        {
            AddInclude(x => x.ProductCategory);
            AddOrderBy(x => x.ProdName);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.ProdName);
                        break;
                }
            }
        }

        public ProductsWithCatAndLookupSpecification(int  id) : base(x => x.Id == id)

        {
            AddInclude(x => x.ProductCategory);
           
        }
    }
}
