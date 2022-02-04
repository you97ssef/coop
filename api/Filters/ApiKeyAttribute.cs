using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKeyHeaderName = "ApiKey";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var clientApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // api key in app setting
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey = configuration.GetValue<string>(ApiKeyHeaderName);

        if (!apiKey.Equals(clientApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Before
        await next();
        // After
    }
}