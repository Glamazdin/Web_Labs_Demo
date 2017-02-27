using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLabs_V2.DAL.Entities;

namespace WebLabs_V2.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}