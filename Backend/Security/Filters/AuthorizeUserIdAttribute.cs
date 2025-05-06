using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Backend.Security.Filters;

public class AuthorizeUserIdAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _parameterName;

    public AuthorizeUserIdAttribute(string parameterName = "userId")
    {
        _parameterName = parameterName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpContext = context.HttpContext;
        string? extractedUserId = null;

        if (context.RouteData.Values.TryGetValue(_parameterName, out var routeValue))
        {
            extractedUserId = routeValue?.ToString();
        }

        if (string.IsNullOrEmpty(extractedUserId))
        {
            httpContext.Request.EnableBuffering();

            using var reader = new StreamReader(httpContext.Request.Body, leaveOpen: true);
            var body = reader.ReadToEndAsync().Result;
            httpContext.Request.Body.Position = 0;

            if (!string.IsNullOrEmpty(body))
            {
                try
                {
                    using var jsonDoc = JsonDocument.Parse(body);
                    if (jsonDoc.RootElement.TryGetProperty(_parameterName, out var userIdProp))
                    {
                        extractedUserId = userIdProp.GetRawText().Trim('"');
                    }
                }
                catch (JsonException)
                {
                    context.Result = new BadRequestObjectResult("Invalid JSON in request body.");
                    return;
                }
            }
        }

        var loggedInUserId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(loggedInUserId) || extractedUserId != loggedInUserId)
        {
            context.Result = new ForbidResult();
        }
    }
}