namespace eShop.Catalog.Services;

public sealed class ProductService(CatalogContext context)
{
    public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken = default) =>
        await context.Products.ToListAsync(cancellationToken);

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Products.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
