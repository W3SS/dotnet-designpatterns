using MvcDesignPattern.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MvcDesignPattern.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessOrder(string paymentMode)
        {
            var address = new Address();
            var cardInfo = (CardInfo)null;

            var order = new Order
            {
                OrderId = new Random().Next(1000, 9000),
                ShippingAddress = address,
                CardInfo = cardInfo
            };

            if (paymentMode == "card")
            {
                var oop = new OnlineOrderProcessor();
                cardInfo = new CardInfo
                {
                    CardNo = "123456789",
                    ExpiryMonth = 12,
                    ExpiryYear = 2018
                };
                order.CardInfo = cardInfo;

                oop.ValidateCardInfo(cardInfo);
                oop.ValidateShippingAddress(address);
                oop.ProcessOrder(order);
            }
            else
            {
                var codop = new CashOnDeliveryOrderProcessor();
                codop.ValidateShippingAddress(address);
                codop.ProcessOrder(order);
            }

            return View("Success", order);
        }
    }
}