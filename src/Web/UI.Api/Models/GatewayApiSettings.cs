namespace UI.Api.Models
{
    public class GatewayApiSettings
    {
        public string BaseUrl { get; set; }
        public ServiceApi Customer { get; set; }
        public ServiceApi Product { get; set; }
        public ServiceApi Order { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
