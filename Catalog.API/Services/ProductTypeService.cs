using HotChocolate.Pagination;

namespace eShop.Catalog.Services;

public sealed class ProductTypeService(CatalogContext context)
{
    public async Task<Page<ProductType>> GetProductTypesAsync(
        PagingArguments pagingArguments,
        CancellationToken cancellationToken = default) =>
        await context.ProductTypes
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    public async Task<ProductType?> GetProductTypeByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await context.ProductTypes
            .FirstOrDefaultAsync(t =>
                    t.Id == id,
                cancellationToken
            );
}
