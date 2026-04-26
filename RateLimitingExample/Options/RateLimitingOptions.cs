namespace RateLimitingExample.Options
{
    public class RateLimitingOptions
    {
        public FixedWindowOptions Fixed { get; set; }
        public SlidingWindowOptions Sliding { get; set; }
        public TokenBucketOptions Token { get; set; }
        public ConcurrencyOptions Concurrency { get; set; }
    }
}
