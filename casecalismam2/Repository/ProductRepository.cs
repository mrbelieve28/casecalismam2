using casecalismam2.Data;
using casecalismam2.Models;
using Microsoft.EntityFrameworkCore;

namespace casecalismam2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;

        public ProductRepository()
        {
        }

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        // create bölümü ürünleri db'ye eklemeye yarar

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        // delete bölümü ürünlerin db'den silinmesini sağlar

        public void DeleteProductById(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                throw new Exception($"{product.Id} not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

        }

        public Product GetProductById(int id)
        {
           
            return _context.Products.Find(id);
        }

        // read komutu verileri okumaya yarıyor

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // update bölümü ürünlerin databasede güncellenmesini sağlar

        public Product UpdateProduct(Product product)
        {

            _context.Products.Update(product);
            _context.SaveChanges();

            return product;
        }
    }
}
