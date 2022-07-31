using System.Threading.Channels;
using ChannelQueue.Abstract;
using ChannelQueue.Dtos;

namespace ChannelQueue.Queues
{
    public class ProductsQueue : ITaskQueue<Product>
    {
        private readonly Channel<Product> queue;

        public ProductsQueue(IConfiguration configuration)
        {
            int.TryParse(configuration["QueueCapacity"], out int capacity);

            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            queue = Channel.CreateBounded<Product>(options);
        }


        public async ValueTask AddQueue(Product queueItem)
        {
            ArgumentNullException.ThrowIfNull(queueItem);

            await queue.Writer.WriteAsync(queueItem);
        }

        public ValueTask<Product> DeQueue(CancellationToken cancellationToken)
        {
            var workItem = queue.Reader.ReadAsync(cancellationToken);
            return workItem;
        }
    }
}
