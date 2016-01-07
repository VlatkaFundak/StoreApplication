using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApplication.Models
{
    /// <summary>
    /// Item class.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id of the product.
        /// </summary>
        public virtual Guid Id { get; set;}

        /// <summary>
        /// Name of the product.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public virtual double Price { get; set; }

        /// <summary>
        /// Category of the product.
        /// </summary>
        public virtual string Category { get; set; }
    }
}