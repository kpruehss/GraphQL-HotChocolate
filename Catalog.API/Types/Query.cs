namespace eShop.Catalog.Types;

public class Query
{

    #region ProductTypes

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<ProductType?> GetProductTypesById(CatalogContext context, int id)
        => context.ProductTypes.Where(pt => pt.Id == id);

    #endregion

    #region Brands

    // [UsePaging(DefaultPageSize = 10, MaxPageSize = 20)] // Override Global Pagination Settings
    [UsePaging] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    public IQueryable<Brand> GetBrands(CatalogContext context) => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Brand?> GetBrandById(CatalogContext context, int id)
        => context.Brands.Where(brand => brand.Id == id);

    #endregion

    #region Products

    [UsePaging] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);

    #endregion

}
