namespace eShop.Catalog.Types;

[QueryType]
public static class BrandQueries
{
    // [UsePaging(DefaultPageSize = 10, MaxPageSize = 20)] // Override Global Pagination Settings
    [UsePaging] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    public static IQueryable<Brand> GetBrands(CatalogContext context) => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Brand?> GetBrandById(CatalogContext context, int id)
        => context.Brands.Where(brand => brand.Id == id);
}
