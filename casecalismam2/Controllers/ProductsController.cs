﻿using casecalismam2.Models;
using casecalismam2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace casecalismam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {

            var products = _productRepository.GetProducts();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Created("", _productRepository.Create(product));

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Product product, int id)
        {
            var p = _productRepository.GetProductById(id);
            if (p == null)
            {
                return NotFound();

            }

            p.Name = product.Name;
            p.Price = product.Price;
            p.Description = product.Description;
            p.Color = product.Color;

            _productRepository.UpdateProduct(p);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = _productRepository.GetProductById(id);
            if (p == null)
            {
                return NotFound();

            }

            _productRepository.DeleteProductById(id);

            return Ok("ürün başarıyla silinmiştir!");
        }


    }
}
