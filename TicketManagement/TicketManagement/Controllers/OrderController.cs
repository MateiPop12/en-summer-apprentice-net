using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Models;
using TicketManagement.Models.DTO;
using TicketManagement.Repositories.RepositoryInterface;

namespace TicketManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository,ITicketCategoryRepository ticketCategoryRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllOrders()
        {
            var orders =  _orderRepository.GetAll();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return Ok(ordersDto);
        }
        [HttpGet]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var @order = await _orderRepository.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(@order);
            return Ok(orderDto);
        }
        [HttpPatch]
        public async Task<ActionResult<Order>> Update(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetOrderById(orderPatch.OrderId);
            var ticketCategoryEntity = await _ticketCategoryRepository.GetById(orderPatch.TicketCategoryId);
            float price = (float)(ticketCategoryEntity.TicketCategoryPrice * orderEntity.NumberOfTickets);
            orderEntity.TotalPrice = price;
            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}