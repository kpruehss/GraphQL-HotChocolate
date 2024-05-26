using eShop.Catalog.Services;
using HotChocolate.Pagination;
using HotChocolate.Types.Pagination;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductTypeQueries
{
    public static async Task<Connection<ProductType>> GetProductTypesAsync(
        PagingArguments pagingArguments,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
        => await productTypeService
            .GetProductTypesAsync(pagingArguments, cancellationToken)
            .ToConnectionAsync();

    public static async Task<ProductType?> GetProductTypesByIdAsync(
        int id,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
        => await productTypeService.GetProductTypeByIdAsync(id, cancellationToken);
}
