using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIBookstore.Models;

namespace APIBookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);

            if(product == null)
               return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var product = _context.Products.ToList();
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Toupdate(Product product)
        {
            var ProductBanco = _context.Products.Find(product.Id);

            if(ProductBanco == null)
                return NotFound();

            ProductBanco.Name = product.Name;
            ProductBanco.Price = product.Price;
            ProductBanco.Quantity = product.Quantity;
            ProductBanco.Category = product.Category;
            ProductBanco.Img = product.Img;

            _context.Products.Update(ProductBanco);
            _context.SaveChanges();

            return Ok(ProductBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ProductBanco = _context.Products.Find(id);

            if(ProductBanco == null)
                return NotFound();

            _context.Products.Remove(ProductBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}