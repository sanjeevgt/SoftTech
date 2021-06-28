using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecificication : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecificication(ProductSpecParams productSpecParams)
            : base(x =>
                  (string.IsNullOrEmpty(productSpecParams.Search) || x.ProdName.ToLower()
                  .Contains(productSpecParams.Search)) &&
                (string.IsNullOrEmpty(productSpecParams.Search) || x.ProdName.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.CatId.HasValue || x.ProdCatId == productSpecParams.CatId)
            )
        {
        }
    }
}
