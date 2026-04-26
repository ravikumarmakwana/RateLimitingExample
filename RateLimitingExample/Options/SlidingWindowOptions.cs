namespace RateLimitingExample.Options
{
    public class SlidingWindowOptions
    {
        public int PermitLimit { get; set; }
        public int WindowSeconds { get; set; }
        public int Segments { get; set; }
    }
}
