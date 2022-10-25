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
    public class BlogManager : IGenericService<Blog>
    {
        IGenericDal<Blog> _blogDal;

        public BlogManager(IGenericDal<Blog> blogDal)
        {
            _blogDal = blogDal;
        }
        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
