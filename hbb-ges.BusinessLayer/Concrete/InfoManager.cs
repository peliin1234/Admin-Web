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
    public class InfoManager : IGenericService<Info>
    {
        IGenericDal<Info> _infoDal;
        public InfoManager(IGenericDal<Info> dal)
        {
            _infoDal = dal;
        }
        public Info GetById(int id)
        {
            return _infoDal.GetByID(id);
        }

        public List<Info> GetList()
        {
            return _infoDal.GetListAll();
        }

        public void TAdd(Info t)
        {
            _infoDal.Insert(t);
        }

        public void TDelete(Info t)
        {
            _infoDal.Delete(t);
        }

        public void TUpdate(Info t)
        {
            _infoDal.Update(t);
        }
    }
}
