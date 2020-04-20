using LHBOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHDAL
{
    public interface ICategoryDb
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
    public class CategoryDb : ICategoryDb
    {
        LHDbContext LHDbContext;
        public CategoryDb(LHDbContext _LHDbContext)
        {
            LHDbContext = _LHDbContext;
        }
        public bool Create(Category category)
        {
            LHDbContext.Add(category);
            LHDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var category = LHDbContext.Categories.Find(id);
            LHDbContext.Remove<Category>(category);
            LHDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return LHDbContext.Categories;
        }

        public Category GetById(int id)
        {
            var category = LHDbContext.Categories.Find(id);
            return category;
        }

        public bool Update(Category category)
        {
            LHDbContext.Update<Category>(category);
            LHDbContext.SaveChanges();
            return true;
        }
    }
}
