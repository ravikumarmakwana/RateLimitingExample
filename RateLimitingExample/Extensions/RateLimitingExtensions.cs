using Microsoft.AspNetCore.RateLimiting;
using RateLimitingExample.Options;
using System.Threading.RateLimiting;

namespace RateLimitingExample.Extensions
{
    public static class RateLimitingExtensions
    {
        public static void AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            RateLimitingOptions rateLimitingOptions =
                configuration.GetSection("RateLimiting").Get<RateLimitingOptions>() ?? new();

            services.AddRateLimiter((options) =>
            {
                // Global rejection handler
                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429;

                    await context.HttpContext.Response.WriteAsJsonAsync(new
                    {
                        message = "Too many requests",
                        retryAfter = "Try again later"
                    });
                };

                // 1. Fixed Window
                options.AddFixedWindowLimiter("fixed", opt =>
                {
                    opt.PermitLimit = rateLimitingOptions.Fixed.PermitLimit;
                    opt.Window = TimeSpan.FromSeconds(rateLimitingOptions.Fixed.WindowSeconds);
                    opt.QueueLimit = 0;
                });

                // 2. Sliding Window
                options.AddSlidingWindowLimiter("sliding", opt =>
                {
                    opt.PermitLimit = rateLimitingOptions.Sliding.PermitLimit;
                    opt.Window = TimeSpan.FromSeconds(rateLimitingOptions.Sliding.WindowSeconds);
                    opt.SegmentsPerWindow = rateLimitingOptions.Sliding.Segments;
                });

                // 3. Token Bucket
                options.AddTokenBucketLimiter("token", opt =>
                {
                    opt.TokenLimit = rateLimitingOptions.Token.TokenLimit;
                    opt.TokensPerPeriod = rateLimitingOptions.Token.TokenPerPeriod;
                    opt.ReplenishmentPeriod =
                        TimeSpan.FromSeconds(rateLimitingOptions.Token.ReplenishmentSeconds);
                    opt.AutoReplenishment = true;
                });

                // 4. Concurrency
                options.AddConcurrencyLimiter("concurrency", opt =>
                {
                    opt.PermitLimit = rateLimitingOptions.Concurrency.PermitLimit;
                    opt.QueueLimit = 0;
                });

                // 5. Partitioned (per IP)
                options.AddPolicy("partitioned", context =>
                {
                    var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                    return System.Threading.RateLimiting.RateLimitPartition.GetFixedWindowLimiter(ip, _ =>
                        new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 3,
                            Window = TimeSpan.FromSeconds(10),
                            QueueLimit = 0
                        });
                });
            });

        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void AddRateLimiterOptions(this IServiceCollection services, IConfiguration configuration)
            => services.AddRateLimiting(configuration);
    }
}