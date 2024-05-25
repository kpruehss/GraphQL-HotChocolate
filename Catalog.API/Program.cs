using eShop.Catalog.Extensions;
using HotChocolate.Data.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(
            builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductFilterInputType>()
    .AddGraphQLConventions();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);

public class CustomStringOperationFilterInputType : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.StartsWith).Type<StringType>();
    }
}

public class SearchStringOperationFilterInputType : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.Contains).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.In).Type<ListType<StringType>>();
        descriptor.Operation(DefaultFilterOperations.StartsWith).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.EndsWith).Type<StringType>();
    }
}
