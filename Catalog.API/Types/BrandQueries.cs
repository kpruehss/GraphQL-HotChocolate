using eShop.Catalog.Service;

namespace eShop.Catalog.Types;

public static class BrandQueries
{
    public static async Task<IReadOnlyList<Brand>> GetBrandsAsync(BrandService brandService, CancellationToken cancellationToken) =>
        await brandService.GetBrandsAsync(cancellationToken);

    public static async Task<Brand?> GetBrandByIdAsync(int id,
        BrandService brandService,
        CancellationToken cancellationToken) =>
        await brandService.GetBrandByIdAsync(id, cancellationToken);
}
