using Chaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public class OfferRepo : GeneralInterface<Offer>
    {
        private readonly ChatyDbContext myDB;

        public OfferRepo(ChatyDbContext myDB)
        {
            this.myDB = myDB;
        }
        public void AddNewItem(Offer NewItem)
        {
            myDB.Offers.Add(NewItem);
            AccessDB.GetDB = myDB;
        }

        public void DeleteItem(int ItemIndex)
        {
            var SearchedOffer = myDB.Offers.Where(x => x.id == ItemIndex).FirstOrDefault();
            myDB.Offers.Remove(SearchedOffer);
            AccessDB.GetDB = myDB;
        }

        public void EditItem(Offer NewItem, int OldItemId)
        {
            myDB.Offers.Update(NewItem);
            myDB.SaveChanges();
        }

        public List<Offer> GetAllData()
        {
            return myDB.Offers.ToList();
        }
        public Offer SearchOfferByClientCode(string ClientCode)
        {
            var SearchedClient = myDB.Clients.Where(x => x.UserCode == ClientCode).FirstOrDefault();
            var SearchedClientOfferId = myDB.ClientOffer.Where(x => x.ClientId == SearchedClient.Id).FirstOrDefault().OfferId;
            var SearchedOffer = myDB.Offers.Where(x => x.id == SearchedClientOfferId).FirstOrDefault();
            return SearchedOffer;
        }
        public Offer SearchOfferByPrice(double Money)
        {
            return myDB.Offers.Where(x => x.Money == Money).FirstOrDefault();
        }
        public void DeleteAllClientOffer(string ClientCode)
        {
            var SearchedClient = myDB.Clients.Where(x => x.UserCode == ClientCode).FirstOrDefault();
            var SearchedClientOfferId = myDB.ClientOffer.Where(x => x.ClientId == SearchedClient.Id).ToList();
            myDB.ClientOffer.RemoveRange(SearchedClientOfferId);
            myDB.SaveChanges();
        }
        public void SendProcessingRequest(int ClientId , int OfferId)
        {
            myDB.ProcessingRequest.Add(new ProcessingRequest()
            {
                ClientId = ClientId,
                OfferId = OfferId,
                RequestTime = DateTime.Now
            });
            myDB.SaveChanges();
        }
        public List<ProcessingRequest> GetAllProcessingRequests()
        {
            return myDB.ProcessingRequest.ToList();
        }
        public ProcessingRequest SearchProcessingRequest(int ClientId)
        {
            return myDB.ProcessingRequest.Where(x => x.ClientId == ClientId).FirstOrDefault();
        }
        public void AcceptProcessingRequest(int ClientId)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Id == ClientId).FirstOrDefault();
            SearchedClient.Activated = true;
            SearchedClient.PayedOrNot = true;
            myDB.Clients.Update(SearchedClient);
            myDB.SaveChanges();
        }
        public void RejectProcessingRequest(int ClientId , int RequestId)
        {
            var SearchedClient = myDB.Clients.Where(x => x.Id == ClientId).FirstOrDefault();
            SearchedClient.PayedOrNot = false;
            myDB.Clients.Update(SearchedClient);
            var SearchedProcessingRequest = myDB.ProcessingRequest.Where(x => x.Id == RequestId).FirstOrDefault();
            myDB.ProcessingRequest.Remove(SearchedProcessingRequest);
            myDB.SaveChanges();
        }
    }
}
