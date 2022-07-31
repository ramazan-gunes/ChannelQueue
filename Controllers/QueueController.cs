using ChannelQueue.Abstract;
using ChannelQueue.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChannelQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ITaskQueue<Product> _productQueueService;

        public QueueController(ITaskQueue<Product> productQueueService)
        {
            _productQueueService = productQueueService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(List<Product> products)
        {

            foreach (var product in products)
            {
                await _productQueueService.AddQueue(product);
            }

            return Ok();
        }

    }
}
