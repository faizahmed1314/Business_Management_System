using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        internal Product IsNameExist(string name)
        {
            var product = _db.Products.Where(c => c.Name == name).FirstOrDefault();
            return product;
        }

        internal Product IsCodeNoExist(string code)
        {
            var product = _db.Products.Where(c => c.Code == code).FirstOrDefault();
            return product;
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

        public List<SelectListItem> GetCategorySelectListItems()
        {
            var categoryList = _db.Categories.ToList();

            var categorySelectListItems = new List<SelectListItem>();

            categorySelectListItems.AddRange(GetDefaultSelectListItem());

            if (categoryList != null && categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = category.Name;
                    selectListItem.Value = category.Id.ToString();

                    categorySelectListItems.Add(selectListItem);
                }
            }
            return categorySelectListItems;
        }



        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }
    }
}