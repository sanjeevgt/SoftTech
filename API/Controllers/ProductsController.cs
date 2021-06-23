
using API.Infrastructure;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }
         [HttpGet]
        public async Task<ActionResult<List<ProductCategory>>> GetProducts()
        {
            var product =  await  _context.ProductCategorys.ToListAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>>  GetProduct(int id)
        {
            return await _context.ProductCategorys.FindAsync(id);
        }
        
    }
}