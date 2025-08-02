using System;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly string _adminEmail = "admin@gmail.com";

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        
        public IActionResult ReceiverMessageList()
        {
            var values = writerMessageManager.GetListReceiverMessage(_adminEmail);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            var values = writerMessageManager.GetListSenderMessage(_adminEmail);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            var message = writerMessageManager.TGetByID(id);

            if (message == null) return NotFound();

            writerMessageManager.TDelete(message);

            return RedirectToAction(message.ReceiverMail == _adminEmail ? "ReceiverMessageList" : "SenderMessageList");
        }

        [HttpGet] 
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.SenderMail = _adminEmail;
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
            
            Context c = new Context();
            var userNameSurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname ?? "Unknown";
            
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList"); 
        }

    }
}
