using App.Web.Business.Abstract;
using App.Web.Data.EntityFreamwork;
using App.Web.Entity.Abstract;
using App.Web.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategory _category;
        public CategoryManager(ICategory category)
        {
            _category = category;
        }

        public void CategoryAdd(Category category)
        {
            _category.Insert(category);

        }

        public void CategoryDelete(Category category)
        {
            _category.Delete(category);
            
        }

        public void CategoryUpdate(Category category)
        {
            _category.Update(category);
        }

        public Category GetById(int id)
        {
            return _category.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _category.GetListAll();
        }
    }
}
