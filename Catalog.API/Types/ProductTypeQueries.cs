namespace eShop.Catalog.Types;

[QueryType]
public static class ProductTypeQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public static IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<ProductType?> GetProductTypesById(CatalogContext context, int id)
        => context.ProductTypes.Where(pt => pt.Id == id);
}
