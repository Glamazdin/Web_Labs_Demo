using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLabs_V3.DAL.Entities;

namespace WebLabs_V3.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}