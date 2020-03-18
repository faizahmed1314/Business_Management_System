using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    
    public class CategoryRepository
    {
        BmsContext _db = new BmsContext();

        public bool Save(Category category)
        {
            _db.Categories.Add(category);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            _db.Entry(category).State=EntityState.Modified;
            var rowAffected=_db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCategory(int id)
        {
            var category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            _db.Categories.Remove(category);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}