using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    static public class AccessDB
    {
        static public ChatyDbContext GetDB { get; set; }
        static public void AccessChangesDB()
        {
            GetDB.SaveChanges();
        }
    }
}
