using Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HermesChat.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int ToUserId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
