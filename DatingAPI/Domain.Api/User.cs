using System.ComponentModel.DataAnnotations;

namespace Domain.Api
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
