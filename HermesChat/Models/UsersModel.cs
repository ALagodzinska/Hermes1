using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HermesChat.Models
{
    public class UsersModel /*: IdentityUser*/
    {
       [Key]
        public int UserId { get; set; }
        [Required, MinLength(6)] 
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(10), DataType(DataType.Password)]
        public string Password { get; set; }
        public string ProfileImg { get; set; }  
    }
}
