using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    public class Item
    {
        public virtual Guid Id { get; set;}
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual string Category { get; set; }
    }
}