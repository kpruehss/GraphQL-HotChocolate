namespace eShop.Catalog.Service;

[QueryType]
public sealed class BrandService(CatalogContext context)
{
    public async Task<IReadOnlyList<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default) =>
        await context.Brands.ToListAsync(cancellationToken);

    public async Task<Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Brands.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
