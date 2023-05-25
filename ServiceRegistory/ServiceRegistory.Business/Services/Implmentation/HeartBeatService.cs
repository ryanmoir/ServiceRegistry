using HttpRequestWrapper;
using Microsoft.Extensions.Logging;
using ServiceRegistory.Business.Services.Interface;
using ServiceRegistory.Entity;
using ServiceRegistory.EntityAcceess.Repository.Interface;
using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;

namespace ServiceRegistory.Business.Services.Implmentation
{
    public class HeartBeatService : IHeartBeatService
    {
        private readonly IRegistoryRepository RegistoryRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger Logger;

        public HeartBeatService(IRegistoryRepository registoryRepository, IUnitOfWork unitOfWork, ILogger<HeartBeatService> logger)
        {
            RegistoryRepository = registoryRepository;
            UnitOfWork = unitOfWork;
            Logger = logger;
        }

        public Task QueueCheckForHeartBeats()
        {
            return Task.Factory.StartNew(() => { this.CheckForHeartBeats(); });
        }

        public async Task<List<KeyValuePair<long,Exception>>> CheckForHeartBeats()
        {
            var records = await RegistoryRepository.GetAll();
            var errors = new List<KeyValuePair<long,Exception>>();

            Parallel.ForEach(
                records,
                new ParallelOptions { MaxDegreeOfParallelism = 5 },
                async record =>
            {
                var wrapper = new RequestWrapper(HttpMethod.Get, new Uri(record.GlobalAddress + @"api/v1/HeartBeat"));
                var client = new HttpClientHelper();

                try
                {
                    var heartbeat = await client.SendAsync(wrapper);
                    if (heartbeat.IsSuccess)
                    {
                        if (record.ServiceStatus != ServiceStatus.Healthy.ToString())
                        {
                            record.ServiceStatus = ServiceStatus.Healthy.ToString();
                            RegistoryRepository.Update(record);
                        }
                    }
                    else
                    {
                        if (record.ServiceStatus != ServiceStatus.NotResponding.ToString())
                        {
                            record.ServiceStatus = ServiceStatus.NotResponding.ToString();
                            RegistoryRepository.Update(record);
                        }
                        else
                        {
                            await RegistoryRepository.Delete(record.Id);
                        }
                    }
                }
                catch (Exception e)
                {
                    errors.Add(new KeyValuePair<long, Exception>(record.Id, e));
                    Logger.LogError($"Error getting heartbeat for {record.Id} {record.ServiceName}");
                }
            });

            await UnitOfWork.SaveChangesAsync();

            return errors;
        }
    }
}