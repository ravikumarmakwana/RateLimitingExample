namespace RateLimitingExample.Options
{
    public class TokenBucketOptions
    {
        public int TokenLimit { get; set; }
        public int TokenPerPeriod { get; set; }
        public int ReplenishmentSeconds { get; set; }
    }
}
