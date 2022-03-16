using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.ViewModels
{
    public class MessagesViewModel
    {
        public Clients Client { get; set; }
        public List<Message> Messages { get; set; }
    }
}
