using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class AdminMessageRepo : GeneralInterface<AdminMessage>
    {
        private readonly ChatyDbContext myDB;

        public AdminMessageRepo(ChatyDbContext MyDB)
        {
            myDB = MyDB;
        }
        public void AddNewItem(AdminMessage NewItem)
        {
            myDB.AdminMessage.Add(new AdminMessage()
            {
                Email = NewItem.Email,
                Message = NewItem.Message,
                Name = NewItem.Name,
                Phone = NewItem.Phone
            });
            myDB.SaveChanges();
        }
        public void DeleteItem(int ItemIndex)
        {
            var SearchedMessage = myDB.AdminMessage.Where(x => x.Id == ItemIndex).FirstOrDefault();
            myDB.AdminMessage.Remove(SearchedMessage);
            myDB.SaveChanges();
        }

        public void EditItem(AdminMessage NewItem, int OldItemId)
        {
            myDB.AdminMessage.Update(NewItem);
            myDB.SaveChanges();
        }

        public List<AdminMessage> GetAllData()
        {
            return myDB.AdminMessage.ToList();
        }
    }
}
