using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Product
    {   
        /// <summary> 
        /// The unique identifier for the product.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// The user facing title of the product.
        /// </summary>
        [StringLength(50, ErrorMessage = "Title cannot be more than 50 characters.")]
        public required string Title { get; set; }

        /// <summary>
        /// The current sales price of the product in USD.
        /// </summary>
        [Range(0, 10_000)]
        public decimal Price { get; set; }
    }
}
