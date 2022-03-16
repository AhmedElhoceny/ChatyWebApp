using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class MessageRepo : GeneralInterface<Message> , ExtraMessagesFuns
    {
        private readonly ChatyDbContext myDB;

        public MessageRepo(ChatyDbContext myDB)
        {
            this.myDB = myDB;
        }
        public void AddNewItem(Message NewItem)
        {
            myDB.Messages.Add(NewItem);
            AccessDB.GetDB = myDB;
        }

        public void DeleteItem(int ItemIndex)
        {
            var SearchedMessage = myDB.Messages.Where(x => x.Id == ItemIndex).FirstOrDefault();
            myDB.Messages.Remove(SearchedMessage);
            AccessDB.GetDB = myDB;
        }

        public void EditItem(Message NewItem, int OldItemId)
        {
            myDB.Messages.Update(NewItem);
            myDB.SaveChanges();
        }

        public List<Message> GetAllData()
        {
            return myDB.Messages.ToList();
        }

        public List<Message> GetClientMessages(string UserName)
        {
            var SearchedClient = myDB.Clients.Where(X => X.Name == UserName).FirstOrDefault();
            return myDB.Messages.ToList().Where(x => x.ClientId == SearchedClient.Id).ToList();
        }
    }
}
