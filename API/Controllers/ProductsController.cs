using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _context;
        public ProductsController(StoreContext  context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){

            return await _context.Products.ToListAsync();
            //var products = context.Products.ToList();  // if not async use this line
            //return Ok(products);
        }

        [HttpGet("{id}")]  //   api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _context.Products.FindAsync(id);
            //return context.Products.Find(id); // if not async use this line
        }


    }
}