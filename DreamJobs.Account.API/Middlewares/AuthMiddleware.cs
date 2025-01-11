using DreamJobs.Account.Domain.Interfaces.Repositories;
using DreamJobs.Account.Infrastructure.Providers;

namespace DreamJobs.Account.API.Middlewares;

public class AuthMiddleware(IJwtProvider jwtProvider)
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var isValidateToken = jwtProvider.IsValidateToken(token);
            if (isValidateToken)
            {
                var userRepository = context.RequestServices.GetRequiredService<IUserRepository>();
                var (id, email) = jwtProvider.DecodeToken(token);
                var user = await userRepository.GetByIdAsync(id);
                if (user != null)
                {
                    context.Items["User"] = user;
                }
            }
        }

        await next(context);
    }
}