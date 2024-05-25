using HotChocolate.Data.Sorting;

namespace eShop.Catalog.Types.Sorting;

public sealed class ProductSortInputType : SortInputType<Product>
{
    protected override void Configure(ISortInputTypeDescriptor<Product> descriptor)
    {
        #region Set Sortable Fields

        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.Brand).Type<BrandSortInputType>();
        descriptor.Field(f => f.Type).Type<ProductTypeSortInputType>();

        #endregion
    }
}

public sealed class BrandSortInputType : SortInputType<Brand>
{
    protected override void Configure(ISortInputTypeDescriptor<Brand> descriptor)
    {
        #region Set Sortable Fields

        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name);

        #endregion
    }
}

public sealed class ProductTypeSortInputType : SortInputType<ProductType>
{
    protected override void Configure(ISortInputTypeDescriptor<ProductType> descriptor)
    {
        #region Set Sortable Fields

        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name);

        #endregion
    }
}
