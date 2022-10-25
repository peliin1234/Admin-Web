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
    public class OtherCompanyManager : IGenericService<OtherCompany>
    {
        IGenericDal<OtherCompany> _companyDal;
        public OtherCompanyManager(IGenericDal<OtherCompany> dal)
        {
            _companyDal = dal;
        }
        public OtherCompany GetById(int id)
        {
            return _companyDal.GetByID(id);
        }

        public List<OtherCompany> GetList()
        {
            return _companyDal.GetListAll();
        }

        public void TAdd(OtherCompany t)
        {
            _companyDal.Insert(t);
        }

        public void TDelete(OtherCompany t)
        {
            _companyDal.Delete(t);
        }

        public void TUpdate(OtherCompany t)
        {
            _companyDal.Update(t);
        }
    }
}
