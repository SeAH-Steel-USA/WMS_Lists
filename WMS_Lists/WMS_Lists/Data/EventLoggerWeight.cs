namespace WMS_Lists.Data
{
    public class EventLoggerWeight
    {
        public long? EventID { get; set; }
        public long? TubeID { get; set; }
        public string? TestPassed { get; set; }
        public string? TubeRejected { get; set; }
        public string? Nominal { get; set; }
        public string? Measured { get; set; }
        public string? RangePlus { get; set; }
        public string? RangeMinus { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime Date_timestamp { get; set; }
    }
}
