using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserMessageService : IGenericService<UserMessage>
    {
        List<UserMessage> GetUserMessagesWithUserService();
        // Bu metot, kullanıcı mesajlarını ilgili kullanıcı bilgileriyle birlikte getirir.
        // UserMessage ile User entity’si arasındaki ilişki kullanılarak,
        // her mesajın hangi kullanıcıya ait olduğu bilgisiyle birlikte döndürülmesini sağlar.
    }
}
