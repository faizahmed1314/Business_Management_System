using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class ProductRepository
    {
        BmsContext _db = new BmsContext();

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public bool Save(Product product)
        {
            _db.Products.Add(product);
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }
        public Product GetProductById(int id)
        {
            var product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public bool Update(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            var rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Product product)
        {

            _db.Products.Remove(product);
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

        public bool CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            var isSave=_db.SaveChanges();
            if (isSave>0)
            {
                return true;
            }
            return false;
        }
    }
}