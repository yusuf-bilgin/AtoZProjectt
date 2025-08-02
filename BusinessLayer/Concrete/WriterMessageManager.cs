using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        // Göndericisi olunan mesajları listeleme
        public List<WriterMessage> GetListReceiverMessage(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.ReceiverMail == p);
        }
        // Alıcısı olunan mesajları listeleme
        public List<WriterMessage> GetListSenderMessage(string p)
        {
            return _writerMessageDal.GetByFilter(x => x.SenderMail == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDal.Delete(t);
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDal.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
