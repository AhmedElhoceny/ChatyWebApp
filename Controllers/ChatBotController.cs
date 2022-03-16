using Chaty.Models;
using Chaty.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class ChatBotController : Controller
    {
        private readonly ChatBotRepo chatBotFuns;
        private readonly ClientRepo clientFuns;

        public ChatBotController(ChatBotRepo ChatBotFuns , ClientRepo ClientFuns)
        {
            chatBotFuns = ChatBotFuns;
            clientFuns = ClientFuns;
        }
        public IActionResult ChatBotView()
        {
            return View();
        }
        public string GetQuestionAnswer(string ClientCode , string Question)
        {
            return chatBotFuns.SearchQuestionAnswerByClientCodeAndQuestion(ClientCode, Question);
        }
        public string AddChatBotItemToClient(string ClientCode , string Question, string Answer)
        {
            try
            {
                var SearchedClient = clientFuns.SearchedByCode(ClientCode);
                chatBotFuns.AddNewItem(new ChatBotMessages()
                {
                    ClientId = SearchedClient.Id,
                    Question = Question,
                    Answer = Answer
                });
                return "Done";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public IActionResult ShowMyChatBot()
        {
            return View();
        }
        public IActionResult ConfirmClientCode(string ClientCode)
        {
            try
            {
                List<ChatBotMessages> ClientChatBotItems = chatBotFuns.GetAllUserChatBotItems(ClientCode);
                if (ClientChatBotItems != null)
                {
                    return View(ClientChatBotItems);
                }
                return RedirectToAction(nameof(ChatBotView));
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(ChatBotView));
            }
        }
        public IActionResult RemoveChatBotItem(int ItemId)
        {
            try
            {
                chatBotFuns.DeleteItem(ItemId);
                return RedirectToAction(nameof(ShowMyChatBot));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(ChatBotView));
            }

        }
    }
}
