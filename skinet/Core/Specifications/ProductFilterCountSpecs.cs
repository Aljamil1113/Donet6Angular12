﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductFilterCountSpecs : BaseSpecification<Product>
    {
        public ProductFilterCountSpecs(ProductSpecParams prodSpecParams)
            : base(x =>
            (!prodSpecParams.BrandId.HasValue || x.ProductBrandId == prodSpecParams.BrandId) &&
            (!prodSpecParams.TypeId.HasValue || x.ProductTypeId == prodSpecParams.TypeId))           
        {

        }
    }
}
