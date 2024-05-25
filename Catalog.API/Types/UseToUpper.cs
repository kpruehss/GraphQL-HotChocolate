using System.Reflection;
using System.Runtime.CompilerServices;
using HotChocolate.Types.Descriptors;

namespace eShop.Catalog.Types;

public static class UseToUpperObjectFieldDescriptorExtension
{
    public static IObjectFieldDescriptor UseToUpper
        (this IObjectFieldDescriptor descriptor)
    {
        return descriptor.Use(next => async context =>
        {
            await next(context);

            if (context.Result is string s)
                context.Result = s.ToUpperInvariant();
        });
    }
}

public class UseToUpperAttribute : ObjectFieldDescriptorAttribute
{

    public UseToUpperAttribute([CallerLineNumber] int order = default)
        => Order = order;

    protected override void OnConfigure
    (
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member
    )
        => descriptor.UseToUpper();
}
