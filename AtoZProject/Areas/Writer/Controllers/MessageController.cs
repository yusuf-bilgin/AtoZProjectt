using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager _messageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageManager.GetListReceiverMessage(p); // Get messages where the receiver is the logged-in user
            return View(messageList);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageManager.GetListSenderMessage(p); // Get messages where the sender is the logged-in user
            return View(messageList);
        }

        [HttpGet]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = _messageManager.TGetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = _messageManager.TGetByID(id);
            return View(writerMessage);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;

            Context c = new Context();
            var userNameSurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname ?? "Unknown";
            _messageManager.TAdd(p);
            return RedirectToAction("SenderMessage", "Message");
        }
    }
}
