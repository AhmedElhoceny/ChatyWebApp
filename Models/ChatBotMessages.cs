using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class ChatBotMessages
    {
        [Key]
        public int id { get; set; }
        public int ClientId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
