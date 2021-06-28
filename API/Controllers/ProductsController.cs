
using API.Dtos;
using API.Errors;
using API.Helpers;
using API.Infrastructure;
using AutoMapper;
using Core.Entites;
using Core.Interface;
using Core.Specifications;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductCategory> _productCatRepo;
        private readonly IGenericRepository<ProductAttributeLookup> _productAttributeLookup;
        private readonly IMapper _mapper;
        public IGenericRepository<ProductAttribute>  _productAttrRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
                            IGenericRepository<ProductCategory> productCatRepo,
                            IGenericRepository<ProductAttributeLookup> productAttributeLookup, 
                            IGenericRepository<ProductAttribute> productAttrRepo,IMapper mapper)
        {
            _productAttributeLookup = productAttributeLookup;
            _productAttrRepo = productAttrRepo;
            _mapper = mapper;
            _productCatRepo = productCatRepo;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithCatAndLookupSpecification(productSpecParams);
            var countSpec = new ProductWithFiltersForCountSpecificication(productSpecParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var product = await _productRepo.ListAsync(spec);
            var attrlookup =  await _productAttributeLookup.ListAllAsync() ;
            var attribute  = await _productAttrRepo.ListAllAsync();
            // this logic to be in BL layer
            foreach (var item in product)
            {
               item.Atttributes = new List<Dictionary<string, string>>();
               var atributeIds =  attrlookup.Where(x => x.ProdCatId == item.ProdCatId)
               .ToList();
               var attrvalue = atributeIds.Select(x => new  {
                   attribute.FirstOrDefault(y =>  y.AttributeId  == x.Id).AttributeValue,
                   x.AttributeName
               }).ToDictionary(x=> x.AttributeName, z=> z.AttributeValue);
               item.Atttributes.Add(attrvalue);
            } 
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(product);
     
            return Ok(new Pagination<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems ,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithCatAndLookupSpecification(id);
            var product =  await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(400));
            return _mapper.Map<Product,  ProductDto>(product);
        }
        [HttpGet("ProductCat")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetProductCat()
        {
            return Ok(await _productCatRepo.ListAllAsync());
        }

        [HttpGet("ProductLookup")]
        public async Task<ActionResult<IReadOnlyList<ProductAttributeLookup>>> GetProductLookup()
        {
            return Ok(await _productAttributeLookup.ListAllAsync());
        }
        [HttpGet("ProductAttr")]
        public async Task<ActionResult<IReadOnlyList<ProductAttribute>>> GetProductAttribute()
        {
            return Ok(await _productAttrRepo.ListAllAsync());
        }
    }
}