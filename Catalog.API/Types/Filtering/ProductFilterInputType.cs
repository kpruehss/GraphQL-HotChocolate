using HotChocolate.Data.Filters;

namespace eShop.Catalog.Types.Filtering;

public class ProductFilterInputType : FilterInputType<Product>
{
    protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
    {
        // Constrain which fields can be filtered by. Unless they are added below, they will not be in schema
        descriptor.BindFieldsExplicitly();

        // Apply special filtering rules to Name
        descriptor.Field(f => f.Name).Type<SearchStringOperationFilterInputType>();
        descriptor.Field(f => f.Type);
        descriptor.Field(f => f.Brand);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.AvailableStock);
    }
}
