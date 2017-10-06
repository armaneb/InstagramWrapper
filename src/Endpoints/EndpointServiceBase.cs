namespace InstagramWrapper.Endpoints
{
    public abstract class EndpointServiceBase : IEndpointService
    {
        public string AccessToken { get; set; }
    }
}
