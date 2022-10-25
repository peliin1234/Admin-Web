using hbb_ges.BusinessLayer.Abstract;
using hbb_ges.DataAccessLayer.Abstract;
using hbb_ges.EntityLayer.Concrete;

namespace hbb_ges.BusinessLayer.Concrete
{
	public class CategoryManager : IGenericService<Category>
	{
		IGenericDal<Category> _categoryDal;

        public CategoryManager(IGenericDal<Category> categoryDal)
        {
            _categoryDal = categoryDal;
        }


		public Category GetById(int id)
		{
			return _categoryDal.GetByID(id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.GetListAll();
		}

        public void TAdd(Category t)
        {
			_categoryDal.Insert(t);
		}

        public void TDelete(Category t)
        {
			_categoryDal.Delete(t);
		}

        public void TUpdate(Category t)
        {
			_categoryDal.Update(t);
		}
    }
}
