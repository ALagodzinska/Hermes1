using Entity;
using System.ComponentModel.DataAnnotations;


namespace HermesChat.Models
{
    public class GroupModel
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<Users> UsersList { get; set; }
    }
}
