using System.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AtoZProject.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = _messageManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
