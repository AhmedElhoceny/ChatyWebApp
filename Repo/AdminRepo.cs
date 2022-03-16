using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class AdminRepo : GeneralInterface<AdminData>
    {
        private readonly ChatyDbContext myDB;

        public AdminRepo(ChatyDbContext MyDB)
        {
            myDB = MyDB;
        }
        public void AddNewItem(AdminData NewItem)
        {
            myDB.AdminData.Add(NewItem);
            myDB.SaveChanges();
        }

        public void DeleteItem(int ItemIndex)
        {
            myDB.AdminData.Remove(myDB.AdminData.Where(x => x.id == ItemIndex).FirstOrDefault());
        }

        public void EditItem(AdminData NewItem, int OldItemId)
        {
            myDB.AdminData.Remove(myDB.AdminData.FirstOrDefault());
            myDB.AdminData.Add(NewItem);
            myDB.SaveChanges();
        }

        public List<AdminData> GetAllData()
        {
            return myDB.AdminData.ToList();
        }
        public AdminData GetAdminData()
        {
            return myDB.AdminData.FirstOrDefault();
        }
    }
}
