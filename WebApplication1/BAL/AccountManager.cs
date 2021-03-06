﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DLL;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public class AccountManager
    {
        AccountRepository _accountRepository=new AccountRepository();

        public List<UserAccount> GetAllUser()
        {
            return _accountRepository.GetAllUser();
        }

        public bool Save(UserAccount user)
        {
            return _accountRepository.Save(user);
        }

        public UserAccount IsLogin(RegisteredUser user)
        {
            return _accountRepository.IsLogin(user);
        }

        public UserAccount IsUserNameExist(string username)
        {
            return _accountRepository.IsUserNameExist(username);
        }
    }
}