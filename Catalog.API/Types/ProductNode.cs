using eShop.Catalog.Services;

namespace eShop.Catalog.Types;

[ObjectType<Product>]
public static partial class ProductNode
{
    static partial void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        // Remove fields you don't want to expose to GraphQL on the Product type
        descriptor
            .Ignore(t => t.BrandId)
            .Ignore(t => t.TypeId)
            .Ignore(t => t.AddStock(default))
            .Ignore(t => t.RemoveStock(default));
    }

    /*
     * Things can also be added to the GraphQL layer to connect types (Product to Brand and Product Type).
     * What follows is a naive implementation which won't scale well (n+1 query)
     * and will be refactored using a Data-loader
     */

    // product needs to be annotated with [Parent] to indicate that it's NOT an input
    public static async Task<Brand?> GetBrandAsync(
        [Parent] Product product,
        BrandService brandService,
        CancellationToken cancellationToken)
        => await brandService.GetBrandByIdAsync(product.BrandId, cancellationToken);

    public static async Task<ProductType?> GetProductTypeAsync(
        [Parent] Product product,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
        => await productTypeService.GetProductTypeByIdAsync(product.TypeId, cancellationToken);
}
