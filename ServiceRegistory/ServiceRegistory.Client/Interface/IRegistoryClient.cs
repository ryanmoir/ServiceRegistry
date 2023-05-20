namespace ServiceRegistory.Client.Interface
{
    using HttpRequestWrapper;
    using ServiceRegistory.Models.Dto.Controllers.Discovery;

    /// <summary>
    /// The sending and making split into 2 to allow support for sending the request to a third part e.g a discovery service
    /// </summary>
    public interface IRegistoryClient
    {
        Task<HttpResponseContainer> RegistoryAdd(RegistoryAddDto registoryAddDto);
        Task<HttpResponseContainer> RegistoryDelete(long registoryId);
        Task<HttpResponseContainer> RegistoryGet(long registoryId);

        RequestWrapper MakeRegistoryAdd(RegistoryAddDto registoryAddDto);
        RequestWrapper MakeRegistoryDelete(long registoryId);
        RequestWrapper MakeRegistoryGet(long registoryId);
    }
}