using eShop.Catalog.Services;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductQueries
{
    public static async Task<IReadOnlyList<Product>> GetProductsAsync(
        ProductService productService,
        CancellationToken cancellationToken = default)
        => await productService.GetProductsAsync(cancellationToken);

    public static async Task<Product?> GetProductByIdAsync(
        int id,
        ProductService productService,
        CancellationToken cancellationToken = default)
        => await productService.GetProductByIdAsync(id, cancellationToken);
}
