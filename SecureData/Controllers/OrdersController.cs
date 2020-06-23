using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureData.BLL;
using SecureData.Data;
using SecureData.Interface;
using SecureData.Models;
using SecureData.Services;
using Order = SecureData.Models.Order;
namespace SecureData.Controllers
{
    public class OrdersController : Controller
    {

        private UnitOfWork unitOfWork;
        private IConfiguration _configruation;
        
        public OrdersController(IConfiguration configruation, IServiceProvider serviceProvider)
        {
            
            _configruation = configruation;
            unitOfWork = new UnitOfWork(serviceProvider);
        }
        
        public IActionResult Index()
        {            
           
            List<Order> orders = ordersList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult Post(List<Order> orders)
        {
            OrderProcessing process = new OrderProcessing(unitOfWork, _configruation);
            if(process.saveDataToContext(orders) && process.saveDataToFile(orders))            
                return Ok("Success");
            return BadRequest("Unexpected error occurred.");
        }
        private List<Order> ordersList()
        {
            
            return new List<Order>
            {
                 new Order
                {
                    number = 1,
                    amount = 20.00,
                    company = "Company 1",
                    date = DateTime.Now,
                    paid = false
                },
                new Order
                {
                    number = 2,
                    amount = 3.00,
                    company = "Company 2",
                    date = DateTime.Now,
                    paid = false
                },
                new Order
                {
                    number = 3,
                    amount = 5.00,
                    company = "Company 3",
                    date = DateTime.Now,
                    paid = false
                },                
                new Order
                {
                    number = 4,
                    amount = 50.00,
                    company = "Company 4",
                    date = DateTime.Now,
                    paid = false
                },
                new Order
                {
                    number = 5,
                    amount = 100.00,
                    company = "Company 5",
                    date = DateTime.Now,
                    paid = false
                }
            };
        }
    }   
}
