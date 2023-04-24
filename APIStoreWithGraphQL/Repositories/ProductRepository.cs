using APIStoreWithGraphQL.Data;
using APIStoreWithGraphQL.Models;

namespace APIStoreWithGraphQL.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(a => a.ProductId == id).FirstOrDefault();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.ProductUpdateDate = DateTime.Now;
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updateProduct = _dbContext.Products.Find(product.ProductId);
            if(updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName ?? updateProduct.ProductName;
                updateProduct.ProductDescription = product.ProductDescription ?? updateProduct.ProductDescription;
                updateProduct.ProductSku = product.ProductSku ?? updateProduct.ProductSku;
                updateProduct.ProductPrice = product.ProductPrice ?? updateProduct.ProductPrice;
                updateProduct.ProductUpdateDate = DateTime.Now;
                updateProduct.ProductStatus = product.ProductStatus ?? updateProduct.ProductStatus;
                _dbContext.Products.Update(updateProduct);
                await _dbContext.SaveChangesAsync();
            }
            return updateProduct;
        }
    }
}
