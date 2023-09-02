using MarketPuan.Data;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(int productId);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
}