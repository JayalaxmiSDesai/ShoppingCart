using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Discounts()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Shopping()
        {
            List<ProductDetails> list = new List<ProductDetails>();
            ProductDetails p1 = new ProductDetails() { slno = 1, ItemName = "A", Price = 50,Quantity=0 };
            ProductDetails p2 = new ProductDetails() { slno = 2, ItemName = "B", Price = 30, Quantity = 0 };
            ProductDetails p3 = new ProductDetails() { slno = 3, ItemName = "C", Price = 20, Quantity = 0 };
            ProductDetails p4 = new ProductDetails() { slno = 4, ItemName = "D", Price = 15, Quantity = 0 };

            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            return View(list);
        }

        [HttpPost]
        public ActionResult Shopping(List<ProductDetails> model)
        {
            if (ModelState.IsValid)
            {
                List<ProductDetails> list = model;
               ViewBag.Total =ApplyDiscounts(model);

            }
            
            return View(model);
        }

        public double? ApplyDiscounts(List<ProductDetails> cart)
        {
            bool flag = false;
            double? total = 0;

            int Discount_3A = 130;
            int Discount_2B = 45;
            int Discount_CD = 30;
            int? C_Quantity = 0;
            double? C_Price = 0;

            foreach (var m in cart)
            {
               if(m.ItemName == "A")
                {
                    if (m.Quantity < 3)
                    {
                        total = total + (m.Quantity * m.Price);
                    }
                    else if (m.Quantity == 3)
                    {
                        total = total + Discount_3A;
                    }
                    else 
                    {
                        var qty = m.Quantity % 3;
                        if (qty == 0)
                        {
                            total = total + Discount_3A;
                        }
                        else
                        {
                            total = total + (Discount_3A * ((m.Quantity-qty)/3)) + (qty * m.Price);
                        }
                    }

                }
                if (m.ItemName == "B")
                {
                    if (m.Quantity < 2)
                    {
                        total = total + (m.Quantity * m.Price);
                    }
                    else if (m.Quantity == 2)
                    {
                        total = total + Discount_2B;
                    }
                    else
                    {
                        var qty = m.Quantity % 2;
                        if (qty == 0)
                        {
                            total = total + Discount_2B;
                        }
                        else {
                            total = total + (Discount_2B * ((m.Quantity-qty)/2)) + (qty * m.Price);
                        }
                    }
                }
                if (m.ItemName == "C")
                {
                    flag = true;
                    C_Quantity = m.Quantity;
                    C_Price = m.Price;

                    if(m.Quantity > 1)
                    {
                        total = total + ((C_Quantity - 1) * C_Price);

                    }
                   
                    
                }
                if (m.ItemName == "D")
                {
                    if (m.Quantity == 0 && C_Quantity == 1)
                    {
                        total = total + (C_Quantity * C_Price);

                    }
                    if (m.Quantity == 1 && C_Quantity == 0)
                    {
                        total = total + (m.Quantity * m.Price);

                    }
                    if (m.Quantity > 1)
                    {
                        total = total + ((m.Quantity - 1) * m.Price);

                    }
                    if (m.Quantity == 1 && C_Quantity==1)
                    {
                        total = total + Discount_CD;
                    }
                    //else
                    //{
                    //    total = Discount_CD + (m.Quantity-1 * m.Price)+(C_Quantity-1 * C_Price);
                    //}
                }
            }
            return total;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}