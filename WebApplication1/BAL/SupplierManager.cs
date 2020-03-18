using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        public bool Save(Supplier supplier)
        {
            return _supplierRepository.Save(supplier);
        }

        public Supplier GetSupplierById(int id)
        {
            return _supplierRepository.GetSupplierById(id);
        }

        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }

        public bool Delete(Supplier supplier)
        {
            return _supplierRepository.Delete(supplier);
        }
    }
}