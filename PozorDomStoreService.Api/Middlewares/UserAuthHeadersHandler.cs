using System.Security.Claims;

namespace PozorDomStoreService.Api.Middlewares
{
    public class UserAuthHeadersHandler(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("X-User-Id", out var userId))
            {
                if (Guid.TryParse(userId, out var parsedUserId))
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.NameIdentifier, parsedUserId.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, "user");
                    context.User = new ClaimsPrincipal(identity);
                }
            }

            await next(context);
        }
    }
}
