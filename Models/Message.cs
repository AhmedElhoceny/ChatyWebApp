using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ToPhoneNumber { get; set; }
        public string MessageContent { get; set; }
        public string ImageURL { get; set; }
        public string Link { get; set; }
        public string State { get; set; }
        public DateTime MessageTime { get; set; }

    }
}
