using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class ProductDetails
    {
        public int? slno
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        [RegularExpression("([0-9])",ErrorMessage ="Please enter numbers only")]
        public int? Quantity
        {
            get;
            set;
        }
        public double? Total
        {
            get;
            set;
        }
    }
}