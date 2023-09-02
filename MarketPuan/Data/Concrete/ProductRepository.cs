using MarketPuan.Data;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(p => p.Id == productId);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
