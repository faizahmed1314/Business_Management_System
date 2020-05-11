using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class ProductManager
    {
        ProductRepository _productRepository=new ProductRepository();
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public bool Save(Product product)
        {
            return _productRepository.Save(product);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public List<Category> GetAllCategories()
        {
            return _productRepository.GetAllCategories();
        }

        public bool CreateCategory(Category category)
        {
            return _productRepository.CreateCategory(category);
        }

        internal Product IsCodeNoExist(string code)
        {
            return _productRepository.IsCodeNoExist(code);
        }

        internal Product IsNameExist(string name)
        {
            return _productRepository.IsNameExist(name);
        }
    }
}