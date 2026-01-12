using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
