using ChannelQueue.Abstract;
using ChannelQueue.Dtos;

namespace ChannelQueue.Services
{
    public class QueueHostedService : BackgroundService
    {
        private readonly ITaskQueue<Product> _queue;
        private readonly ILogger<QueueHostedService> _logger;

        public QueueHostedService(ITaskQueue<Product> queue, ILogger<QueueHostedService> logger)
        {
            _queue = queue;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var item = await _queue.DeQueue(stoppingToken);
                await Task.Delay(1500, stoppingToken);
                _logger.LogInformation($"Added Product Name : {item.Name}, Price : {item.Price}");

            }
        }
    }
}
