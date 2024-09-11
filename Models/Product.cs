using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectITI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The Title Must be between 3 and 15 character.")]
        [Required(ErrorMessage = "Title is Required.")]
        [DisplayName("Product Title")]
        public string Title { get; set; }
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Name Must be between 20 and 50 character.")]
        [Required(ErrorMessage = "The Description is Required.")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price is Required.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "The Quantity is Required.")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        [DisplayName("Category")]

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
