namespace eShop.Catalog.Types;

public class Query
{
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)] // Override Global Pagination Settings
    [UseProjection]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);

    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)] // Override Global Pagination Settings
    [UseProjection]
    public IQueryable<Brand> GetBrands
        (CatalogContext context) => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Brand?> GetBrandById(CatalogContext context, int id)
        => context.Brands.Where(brand => brand.Id == id);

    [UsePaging] // Override Global Pagination Settings
    [UseProjection]
    public IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<ProductType?> GetProductTypesById(CatalogContext context, int id)
        => context.ProductTypes.Where(pt => pt.Id == id);
}
