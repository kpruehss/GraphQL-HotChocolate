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
            .AddSorting()
            .AddPagingArguments()
            .AddFiltering(c =>
            {
                c.AddDefaults()
                    .BindRuntimeType<string, CustomStringOperationFilterInputType>();
            });

        #region GLOBAL Pagination Defaults

        // Append this to the builder middleware above
        // .SetPagingOptions(new PagingOptions
        // {
        //     // Global Pagination Defaults
        //     DefaultPageSize = 2,
        //     MaxPageSize = 5,
        //     AllowBackwardPagination = false,
        //     RequirePagingBoundaries = true,
        // });

        #endregion

        return builder;
    }
}
