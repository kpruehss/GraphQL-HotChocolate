using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;

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
    public IQueryable<Product> GetProducts(CatalogContext context, IFilterContext filterContext, ISortingContext sortingContext)
    {
        #region Provide default sorting/filtering for requests

        // Disable automatic hands-off filtering/sorting
        filterContext.Handled(false);
        sortingContext.Handled(false);

        IQueryable<Product> query = context.Products;

        // Inspect if user provide a filter
        if (!filterContext.IsDefined)
        {
            // Add a default filter, ex: by BrandId
            // This can be used to create "Tenants" since any result will be appended to the base result
            query = query.Where(f => f.BrandId == 1);
        }

        // Inspect if user provided sorting options
        if (!sortingContext.IsDefined)
        {
            query = query.OrderBy(f => f.Brand!.Name).ThenByDescending(f => f.Price);
        }

        #endregion

        return query;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);

    #endregion

}
