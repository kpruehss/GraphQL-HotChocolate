using eShop.Catalog.Types.Filtering;
using HotChocolate.Execution.Configuration;

namespace eShop.Catalog.Extensions;

public static class CustomRequestExecutorBuilderExtensions
{
    public static IRequestExecutorBuilder AddGraphQLConventions(
        this IRequestExecutorBuilder builder)
    {
        builder
            .AddProjections()
            .AddFiltering(c =>
            {
                c.AddDefaults()
                    .BindRuntimeType<string, CustomStringOperationFilterInputType>();
            });

        // .SetPagingOptions(new PagingOptions
        // {
        //     // Global Pagination Defaults
        //     DefaultPageSize = 2,
        //     MaxPageSize = 5,
        //     AllowBackwardPagination = false,
        //     RequirePagingBoundaries = true,
        // });

        return builder;
    }
}
