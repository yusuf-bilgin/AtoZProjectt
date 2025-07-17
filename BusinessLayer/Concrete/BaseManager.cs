using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    // Bu SINIFI İLERİDE KULLANMAYA ÇALIŞSACAGIM
    public class BaseManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _dal;
        public BaseManager(IGenericDal<T> dal)
        {
            _dal = dal;
        }
        public void TAdd(T t) => _dal.Insert(t);

        public void TDelete(T t) => _dal.Delete(t);

        public void TUpdate(T t) => _dal.Update(t);

        public T TGetByID(int id) => _dal.GetById(id);

        public List<T> TGetList() => _dal.GetList();

        
        // Buradaki soruna çözüm gerekiyor
        public List<T> TGetListByFilter(Expression<Func<T, bool>> filter) => _dal.GetByFilter(filter);

        public List<T> TGetListByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
