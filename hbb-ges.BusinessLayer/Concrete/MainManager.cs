using hbb_ges.BusinessLayer.Abstract;
using hbb_ges.EntityLayer.Concrete;
using hbb_ges.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.Concrete
{
    public class MainManager : IGenericService<MainPage>
    {
        IGenericDal<MainPage> _mainDal;
        public MainManager(IGenericDal<MainPage> m)
        {
            _mainDal = m;
        }
        public MainPage GetById(int id)
        {
            return _mainDal.GetByID(id);
        }

        public List<MainPage> GetList()
        {
            return _mainDal.GetListAll();
        }

        public void TAdd(MainPage t)
        {
            _mainDal.Insert(t);
        }

        public void TDelete(MainPage t)
        {
            _mainDal.Delete(t);
        }

        public void TUpdate(MainPage t)
        {
            _mainDal.Update(t);
        }
    }
}
