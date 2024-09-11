using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace ProjectITI.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Name is Required.")]
        [DisplayName("User First Name")]
        public string FirstName { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Name is Required.")]
        [DisplayName("User Last Name")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Email is InValid.")]
        public string Email {  get; set; }
        [StringLength(20,MinimumLength =8 ,ErrorMessage ="The Password is Weak.")]
        [Required(ErrorMessage = "Name is Required.")]
        public string Password { get; set; }
    }
}
