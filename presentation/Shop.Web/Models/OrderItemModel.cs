﻿namespace Shop.Web.Models
{
    public class OrderItemModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }   

        public string Author { get; set; }

        public string Count { get; set; }

        public decimal Price { get; set; }   
    }
}
