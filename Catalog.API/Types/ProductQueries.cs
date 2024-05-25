using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductQueries
{


    [UsePaging] // Override Global Pagination Settings
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Product> GetProducts(CatalogContext context, IFilterContext filterContext, ISortingContext sortingContext)
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
    public static IQueryable<Product?> GetProductById(CatalogContext context, int id)
        => context.Products.Where(prd => prd.Id == id);
}
