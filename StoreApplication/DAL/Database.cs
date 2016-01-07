using StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.DAL
{
    public static class Database
    {
        public static List<Item> ListOfItems { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        static Database()
        {
            Item item1 = new Item();
            item1.Id = Guid.NewGuid();
            item1.Name = "Big Mac";
            item1.Description = "beef meet, cheese, pickles, onion";
            item1.Category = "Sandwich";
            item1.Price = 5.99;

            Item item2 = new Item();
            item2.Id = Guid.NewGuid();
            item2.Name = "McCountry";
            item2.Description = "pork meet, cheese, salad, tomato";
            item2.Category = "Sandwich";
            item2.Price = 3.99;

            Item item3 = new Item();
            item3.Id = Guid.NewGuid();
            item3.Name = "Royal Cheese";
            item3.Description = "beef meet, 2 slices of cheese, pickles, onion";
            item3.Category = "Sandwich";
            item3.Price = 5.99;

            Item item4 = new Item();
            item4.Id = Guid.NewGuid();
            item4.Name = "Big Tasty";
            item4.Description = "beef meet, tomato, onion, salad, Big Tasty sauce";
            item4.Category = "Sandwich";
            item4.Price = 4.99;

            ListOfItems = new List<Item>();
            ListOfItems.Add(item1);
            ListOfItems.Add(item2);
            ListOfItems.Add(item3);
            ListOfItems.Add(item4);
        }
    }
}