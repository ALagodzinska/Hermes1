using System.ComponentModel.DataAnnotations;

namespace HermesChat.Models
{
    public class RoomModel
    {
        [Key]
        public int RoomId { get; set; } 
        public string RoomName { get; set; }
    }
}
