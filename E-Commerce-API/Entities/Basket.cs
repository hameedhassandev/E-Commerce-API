﻿namespace E_Commerce_API.Entities
{
    public class Basket
    {
        public Basket()
        {
                
        }

        public Basket(string id)
        {
                Id = id;   
        }
        public string Id { get; set; }
        public List<BaskeItem> BaskeItems { get; set; } = new List<BaskeItem>();  
    }
} 
