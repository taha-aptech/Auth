using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Auth.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }


        // Foreign Key
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
