using HotChocolate.Data.Filters;

namespace eShop.Catalog.Types;

public class Query
{

    #region ProductTypes

    [UsePaging] // Override Global Pagination Settings
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

    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    public IQueryable<Brand> GetBrands
        (CatalogContext context) => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Brand?> GetBrandById(CatalogContext context, int id)
        => context.Brands.Where(brand => brand.Id == id);

    #endregion

    #region Products

    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);

    #endregion

}

public class ProductFilterInputType : FilterInputType<Product>
{
    protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
    {
        // Constrain which fields can be filtered by
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name);
        descriptor.Field(f => f.Type);
        descriptor.Field(f => f.Brand);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.AvailableStock);
    }
}
