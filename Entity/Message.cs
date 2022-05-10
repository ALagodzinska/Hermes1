using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int UserId { get; set; } 
        public int ToUserId { get; set; }   
        public string Text { get; set; }    
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }  
    }
}
