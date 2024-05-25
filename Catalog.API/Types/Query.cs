namespace eShop.Catalog.Types;

public class Query
{
    [UsePaging]
    [UseProjection]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);

    public IQueryable<Brand> GetBrands
        (CatalogContext context) => context.Brands;
}
