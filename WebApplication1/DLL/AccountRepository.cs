using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.DLL
{
    public class AccountRepository
    {
        BmsContext _db=new BmsContext();

        public List<UserAccount> GetAllUser()
        {
            return _db.UserAccounts.ToList();
        }

        public bool Save(UserAccount user)
        {
            _db.UserAccounts.Add(user);
            var rowAffected=_db.SaveChanges();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsLogin(UserAccount user)
        {
            var obj = _db.UserAccounts.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}