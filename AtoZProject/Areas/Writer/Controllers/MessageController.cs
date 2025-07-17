using System.Threading.Tasks;
using BusinessLayer.Concrete;
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
    }
}
