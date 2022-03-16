using Chaty.Models;
using Chaty.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class ChatyChattingController : Controller
    {
        private readonly ClientRepo clientFuns;
        private readonly MessageRepo messageFuns;
        private readonly OfferRepo offerFuns;
        public ChatyChattingController(ClientRepo ClientFuns, MessageRepo MessageFuns, OfferRepo OfferFuns)
        {
            clientFuns = ClientFuns;
            messageFuns = MessageFuns;
            offerFuns = OfferFuns;
        }
        public string SendTextMessageWhatsApp(string To , string Message , string UserCode)
        {
            try
            {
                var SearchedClient = clientFuns.SearchedByCode(UserCode);
                if (SearchedClient == null)
                {
                    return "Failed";
                }
                string SendMessage = "This Message From " + SearchedClient.Name + " : -----> " + Message;
                if (SearchedClient.Activated == false)
                {
                    return "Failed";
                }
                var SearchClientOffer = offerFuns.SearchOfferByClientCode(UserCode);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/chat");
                HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + To + "&body=" + SendMessage + "&priority=" + 10).Result; 
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                return "true";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public string SendImageMessageWhatsApp(string To, string ImageURL, string UserCode , string caption)
        {
            try
            {
                var SearchedClient = clientFuns.SearchedByCode(UserCode);
                if (SearchedClient == null)
                {
                    return "Failed";
                }
                if (SearchedClient.Activated == false)
                {
                    return "Failed";
                } 
                var SearchClientOffer = offerFuns.SearchOfferByClientCode(UserCode);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/image");
                HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + To + "&image=" + ImageURL + "&caption=" + caption).Result;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                return "true";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public string SendFileMessageWhatsApp(string To, string FileURL, string UserCode, string filename)
        {
            try
            {
                var SearchedClient = clientFuns.SearchedByCode(UserCode);
                if (SearchedClient == null)
                {
                    return "Failed";
                }
                if (SearchedClient.Activated == false)
                {
                    return "Failed";
                }
                var SearchClientOffer = offerFuns.SearchOfferByClientCode(UserCode);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/document");
                HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + To + "&filename=" + filename + "&document=" + FileURL).Result;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                return "true";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public string SendLinkMessageWhatsApp(string To, string Link, string UserCode)
        {
            try
            {
                var SearchedClient = clientFuns.SearchedByCode(UserCode);
                if (SearchedClient == null)
                {
                    return "Failed";
                }
                if (SearchedClient.Activated == false)
                {
                    return "Failed";
                }
                var SearchClientOffer = offerFuns.SearchOfferByClientCode(UserCode);


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/link");
                HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + To + "&link=" + Link).Result;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                return "true";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
    }
}
