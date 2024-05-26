namespace eShop.Catalog.Service;

[QueryType]
public sealed class ProductTypeService(CatalogContext context)
{
    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync(CancellationToken cancellationToken = default) =>
        await context.ProductTypes.ToListAsync(cancellationToken);

    public async Task<ProductType?> GetProductTypeByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await context.ProductTypes
            .FirstOrDefaultAsync(t =>
                    t.Id == id,
                cancellationToken
            );
}
