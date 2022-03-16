using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class ClientRepo : GeneralInterface<Clients> , ExtraMethodForClient
    {
        private readonly ChatyDbContext myDB;

        public ClientRepo(ChatyDbContext MyDB)
        {
            myDB = MyDB;
        }
        public void AddNewItem(Clients NewItem)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Name == NewItem.Name || x.Email == NewItem.Email).FirstOrDefault();
            if (SearchedClient == null)
            {
                myDB.Clients.Add(NewItem);
                AccessDB.GetDB = myDB;
            }
        }

        public void DeleteItem(int ItemIndex)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Id == ItemIndex).FirstOrDefault();
            myDB.Clients.Remove(SearchedClient);
            AccessDB.GetDB = myDB;
        }

        public void EditItem( Clients NewItem, int OldItemId)
        {
            myDB.Clients.Update(NewItem);
            myDB.SaveChanges();
        }

        public List<Clients> GetAllData()
        {
            return myDB.Clients.ToList();
     
        }

        public Clients IsClientExist(string UserNmae, string PassWord)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Name == UserNmae && x.PassWord == PassWord).FirstOrDefault();
            if (SearchedClient == null)
            {
                return new Clients() { Name = "No_One" };
            }
            return SearchedClient;
        }

        public Clients SearchedByClientName(string UserName)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Name == UserName).FirstOrDefault();
            if (SearchedClient == null)
            {
                return new Clients() { Name = "No_One" };
            }
            return SearchedClient;
        }

        public Clients SearchedById(int UserId)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Id == UserId).FirstOrDefault();
            if (SearchedClient == null)
            {
                return new Clients() { Name = "No_One" };
            }
            return SearchedClient;
        }
        public Clients SearchedByCode(string UserCode)
        {
            return myDB.Clients.ToList().Where(x => x.UserCode == UserCode).FirstOrDefault();
        }
        public void AddClientToOffer(string ClientCode , string OfferTitle)
        {
            var SearchedClient = myDB.Clients.Where(x => x.UserCode == ClientCode).FirstOrDefault();
            var SearchedOffer = myDB.Offers.Where(x => x.OfferTitle == OfferTitle).FirstOrDefault();
            myDB.ClientOffer.Add(new ClientOffer()
            {
                ClientId = SearchedClient.Id,
                OfferId = SearchedOffer.id
            });
            myDB.SaveChanges();
        }
    }
}
