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
    public class AboutManager : IGenericService<About>
    {
        IGenericDal<About> _aboutDal;

        public AboutManager(IGenericDal<About> aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetListAll();
        }

       
    }
}
