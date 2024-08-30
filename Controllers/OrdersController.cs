using gestionaleMedeXpress.Models;
using gestionaleMedeXpress.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestionaleMedeXpress.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            List<Order> orders = await _orderService.GetOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(string id)
        {
            var order = await _orderService.GetOrderAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
