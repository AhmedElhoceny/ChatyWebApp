using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class ChatBotRepo : GeneralInterface<ChatBotMessages>
    {
        private readonly ChatyDbContext myDb;

        public ChatBotRepo(ChatyDbContext MyDb)
        {
            myDb = MyDb;
        }
        public void AddNewItem(ChatBotMessages NewItem)
        {
            myDb.ChatBotMessages.Add(NewItem);
            myDb.SaveChanges();
        }

        public void DeleteItem(int ItemIndex)
        {
            var SearchedChatBotItem = myDb.ChatBotMessages.Where(x => x.id == ItemIndex).FirstOrDefault();
            myDb.ChatBotMessages.Remove(SearchedChatBotItem);
            myDb.SaveChanges();
        }

        public void EditItem(ChatBotMessages NewItem, int OldItemId)
        {
            myDb.ChatBotMessages.Update(NewItem);
            myDb.SaveChanges();
        }

        public List<ChatBotMessages> GetAllData()
        {
            return myDb.ChatBotMessages.ToList();
        }
        public string SearchQuestionAnswerByClientCodeAndQuestion(string ClientCode , string Question)
        {
            try
            {
                var SearchedCleint = myDb.Clients.Where(x => x.UserCode == ClientCode).FirstOrDefault();
                if (SearchedCleint == null)
                {
                    return "Failed";
                }
                var SearchedChatBotItem = myDb.ChatBotMessages.ToList().Where(x => x.ClientId == SearchedCleint.Id && x.Question == Question).FirstOrDefault();
                return SearchedChatBotItem.Answer;
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public List<ChatBotMessages> GetAllUserChatBotItems(string ClientCode)
        {
            var SearchedCleint = myDb.Clients.Where(x => x.UserCode == ClientCode).FirstOrDefault();
            if (SearchedCleint == null)
            {
                return null;
            }
            return myDb.ChatBotMessages.ToList().Where(x => x.ClientId == SearchedCleint.Id).ToList();
        }
    }
}
