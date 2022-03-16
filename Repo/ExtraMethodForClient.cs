using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public interface ExtraMethodForClient
    {
        public Clients SearchedByClientName(string UserName);
        public Clients SearchedById(int UserId);
        public Clients IsClientExist(string UserNmae, string PassWord);

    }
}
