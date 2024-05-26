using HotChocolate.Pagination;

namespace eShop.Catalog.Services;

public sealed class BrandService(CatalogContext context)
{
    public async Task<Page<Brand>> GetBrandsAsync(
        PagingArguments pagingArguments,
        CancellationToken cancellationToken = default) =>
        await context.Brands
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    public async Task<Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Brands.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
