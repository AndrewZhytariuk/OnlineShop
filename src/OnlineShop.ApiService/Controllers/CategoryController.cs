using Confluent.Kafka;
using MessageBroker.Kafka.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApiService.Authorization;
using OnlineShop.ApiService.Helpers;
using OnlineShop.CategoryData.Interfaces;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Models.Interfaces;
using OnlineShop.Lib.Clients;
using OnlineShop.Lib.Constants;

namespace OnlineShop.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class CategoryController : ControllerWithClientAuthorization<IRepoClient<Item>>
    {
        private readonly IBaseEventProducer<ItemAdd> _itemAddEventProducer;
        private readonly IBaseEventProducer<ItemUpdate> _itemUpdateEventProducer;
        private readonly IBaseEventProducer<IIdentifiable> _itemDeleteEventProducer;

        public CategoryController(IRepoClient<Item> client,
            IClientAuthorization clientAuthorization,
            IServiceProvider serviceProvider) : base(client, clientAuthorization)
        {
            _itemAddEventProducer = serviceProvider.GetRequiredService<IBaseEventProducer<ItemAdd>>();
            _itemUpdateEventProducer = serviceProvider.GetRequiredService<IBaseEventProducer<ItemUpdate>>();
            _itemDeleteEventProducer = serviceProvider.GetRequiredService<IBaseEventProducer<IIdentifiable>>();
        }

        [HttpPost(RepoActions.Add)]
        public async Task<IActionResult> Add([FromBody] Item entity)
        {
            try
            {
                var itemAdd = ItemHelperMaper.MapToItemAddHelper<Item>(entity);
                _itemAddEventProducer.SendMessage(new Message<Null, ItemAdd> { Value = itemAdd });

            } catch(Exception ex)
            {
                throw new Exception($"Produser Add not work! {ex.Message} ");
            }

            return Ok(200);
        }

        [HttpGet(RepoActions.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Client.GetAll();

            return Ok(result);
        }

        [HttpPost(RepoActions.Update)]
        public async Task<IActionResult> Update([FromBody] Item entry)
        {
            try
            {
                ItemUpdate itemUpdate = ItemHelperMaper.MapToItemUpdateHelper(entry);

                _itemUpdateEventProducer.SendMessage(new Message<Null, ItemUpdate> { Value = itemUpdate });
            }
            catch(Exception ex)
            {
                throw new Exception($"Produser Update not work! {ex.Message} ");
            }

            return Ok(200);
        }

        [HttpPost(RepoActions.Remove)]
        public async Task<IActionResult> Remove([FromBody] Item entry)
        {
            try
            {
                IIdentifiable itemUpdate = ItemHelperMaper.MapToIIdentifiableHelper(entry);
                _itemDeleteEventProducer.SendMessage(new Message<Null, IIdentifiable> { Value = entry });
            }
            catch (Exception ex)
            {
                throw new Exception($"Produser Remove not work! {ex.Message} ");
            }

            return Ok(200);
        }
    }
}
