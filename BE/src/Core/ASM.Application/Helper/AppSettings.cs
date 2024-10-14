namespace ASM.Application.Helper
{
    public class AppSettings
    {
        public required string Secret { get; set; }
        public required string BaseUrl { get; set; }
        public required string DomainName { get; set; }
        public required string ApiKey { get; set; }
    }
}
