using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    interface ExtraMessagesFuns
    {
        List<Message> GetClientMessages(string UserName);
    }
}
