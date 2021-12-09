using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase, IOrderController
    {
        private IOrderDataRepo _orderDataRepo;

        public OrderController(IOrderDataRepo orderDataRepo)
        {
            _orderDataRepo = orderDataRepo;
        }
        
        [HttpGet]
        [Route("{entityId:int}")]
        public async Task<ActionResult<Order>> GetAsync([FromRoute] int entityId)
        {
            Order order = await _orderDataRepo.GetAsync(entityId);
            return order != null ? Ok(order) : NotFound();        }

        [HttpGet]
        public async Task<ActionResult<IList<Order>>> GetAllAsync()
        {
            IList<Order> orders = await _orderDataRepo.GetAllAsync();
            return orders != null ? Ok(orders) : NotFound();
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> PostAddAsync([FromBody] Order entity)
        {
            Console.WriteLine($"Attempting to put {entity} in Database");
            Order order = await _orderDataRepo.AddAsync(entity);
            return order != null ? Ok(order) : NotFound( );        }

        [HttpDelete]
        [Route("{entityId:int}")]
        public async Task<ActionResult<Order>> DeleteAsync([FromRoute] int entityId)
        {
            Order order = await _orderDataRepo.RemoveAsync(entityId);
            return order != null ? Ok(order) : NotFound( );
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> PostUpdateAsync([FromBody] Order entity)
        {
            return Ok(await _orderDataRepo.UpdateAsync(entity));
        }
    }
}