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
    public class GalleryManager : IGenericService<Gallery>
    {
        IGenericDal<Gallery> _galleryDal;
        public GalleryManager(IGenericDal<Gallery> gdal)
        {
            _galleryDal = gdal;
        }
        public Gallery GetById(int id)
        {
            return _galleryDal.GetByID(id);
        }

        public List<Gallery> GetList()
        {
            return _galleryDal.GetListAll();
        }

        public void TAdd(Gallery t)
        {
            _galleryDal.Insert(t);
        }

        public void TDelete(Gallery t)
        {
            _galleryDal.Delete(t);
        }

        public void TUpdate(Gallery t)
        {
            _galleryDal.Update(t);
        }
    }
}
