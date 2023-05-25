namespace ServiceRegistory.Business.Services.Interface
{
    public interface IHeartBeatService
    {
        public Task<List<KeyValuePair<long, Exception>>> CheckForHeartBeats();
        public Task QueueCheckForHeartBeats();
    }
}