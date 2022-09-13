using System.ComponentModel.DataAnnotations;

namespace wellaTestApp.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Course info is required")]
        public string course { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public string age { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string emailAddress { get; set; }

    }
}
