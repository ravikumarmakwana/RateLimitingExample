namespace RateLimitingExample.Options
{
    public class FixedWindowOptions
    {
        public int PermitLimit { get; set; }
        public int WindowSeconds { get; set; }
    }
}
