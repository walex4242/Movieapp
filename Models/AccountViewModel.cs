using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class AccountViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}
