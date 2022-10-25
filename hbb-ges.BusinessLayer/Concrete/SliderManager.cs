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
    public class SliderManager : IGenericService<Slider>
    { 
    
        IGenericDal<Slider> _sliderDal;
        public SliderManager(IGenericDal<Slider> d)
        {
            _sliderDal = d;
        }
        public Slider GetById(int id)
        {
            return _sliderDal.GetByID(id);
        }

        public List<Slider> GetList()
        {
            return _sliderDal.GetListAll();
        }

        public void TAdd(Slider t)
        {
            _sliderDal.Insert(t);
        }

        public void TDelete(Slider t)
        {
            _sliderDal.Delete(t);
        }

        public void TUpdate(Slider t)
        {
            _sliderDal.Update(t);
        }
    }
}
