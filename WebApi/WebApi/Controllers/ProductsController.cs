using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Controllers
{
    //abc.com.tr/api/Products

    //Ok 200
    //NoContent 204
    //NoContent
    //Created 201
    //Problem

    //HttpGet, HttpPut, HttPost, HttpDelete
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebApiContext _context;
        public ProductsController(WebApiContext context)
        {
            _context = context;
        }
        //api/products/getProducts
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.FirstOrDefault(I => I.Id == id));
        }

        //api/products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var updateProduct = _context.Products.FirstOrDefault(I => I.Id == id);
            updateProduct.Name = product.Name;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _context.Products.FirstOrDefault(I => I.Id == id);
            _context.Remove(deleteProduct);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Created("", product);

        }

    }
}
