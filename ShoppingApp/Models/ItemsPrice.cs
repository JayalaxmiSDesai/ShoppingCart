using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ShoppingApp.Models
{
    public class ItemsPrice
    {
        public List<string> GetItems()
        {
          List<string> items_ = new List<string>();
            items_.Add("A");
            items_.Add("B");
            items_.Add("C");
            items_.Add("D");
            return items_;
        }

        public Dictionary<string, int> GetPrice()
        {
            Dictionary<string,int> price = new Dictionary<string, int>();
            price.Add("A", 50);
            price.Add("B", 30);
            price.Add("C", 20);
            price.Add("D", 15);
            return price;
        }

       

    }
}