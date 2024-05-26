using eShop.Catalog.Services;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductTypeQueries
{
    public static async Task<IReadOnlyList<ProductType>> GetProductTypesAsync(
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
        => await productTypeService.GetProductTypesAsync(cancellationToken);

    public static async Task<ProductType?> GetProductTypesByIdAsync(
        int id,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
        => await productTypeService.GetProductTypeByIdAsync(id, cancellationToken);
}
