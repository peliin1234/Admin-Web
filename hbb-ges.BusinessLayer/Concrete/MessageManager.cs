using hbb_ges.BusinessLayer.Abstract;
using hbb_ges.DataAccessLayer.Abstract;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.Concrete
{
    public class MessageManager : IGenericService<Message>
    {
        IGenericDal<Message> _messageDal;
        public MessageManager(IGenericDal<Message> messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message> GetList()
        {
            return _messageDal.GetListAll();
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
