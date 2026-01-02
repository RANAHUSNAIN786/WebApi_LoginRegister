using System.ComponentModel.DataAnnotations;

namespace Webapinew.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
