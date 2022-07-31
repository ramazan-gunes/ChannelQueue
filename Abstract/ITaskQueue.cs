namespace ChannelQueue.Abstract
{
    public interface ITaskQueue<T>
    {
        ValueTask AddQueue(T queueItem);
        ValueTask<T> DeQueue(CancellationToken cancellationToken);
    }
}
