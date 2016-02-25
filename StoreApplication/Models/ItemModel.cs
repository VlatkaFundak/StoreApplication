using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreApplication.Models
{
    /// <summary>
    /// Item class.
    /// </summary>
    public class ItemModel
    {
        /// <summary>
        /// Id of the product.
        /// </summary>
        public virtual Guid Id { get; set;}

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required(ErrorMessage ="Please enter the name.")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        [Required(ErrorMessage = "Please enter description.")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        [Range(1,100, ErrorMessage = "Please enter number between 1 and 100.")]
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Category of the product.
        /// </summary>
        [Required( ErrorMessage = "Please enter category.")]
        public virtual Guid CategoryId { get; set; }

        public virtual ItemCategory Category { get; set; }
    }
}