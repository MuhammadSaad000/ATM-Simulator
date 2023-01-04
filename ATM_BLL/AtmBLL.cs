using ATM_BO;
using ATM_DAL;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ATM_BLL
{
    public class AtmBLL
    {
        //calling authentication of user from DAL
        public string checkUser(AtmBoCust b)
        {
            AtmDal dal = new AtmDal();
            return dal.AuthenticateUser(b);
        }

        //invoking fast cash
        public void FastCash(int id, int a)
        {
            AtmDal dal = new AtmDal();
            dal.WithDrawCash(id, a);
        }

        //invoking normal cash
        public void NormalCash(AtmBoCust b, int a)
        {
            AtmDal dal = new AtmDal();
            dal.NormalCash(b, a);
        }

        //invoking cash transfer
        public void CashTransfer(int b, int id, int amnt)
        {
            AtmDal dal = new AtmDal();
            dal.CashTransfer(b, id, amnt);
        }

        //checking if user available or not
        public string isUserAvailable(int id)
        {
            AtmDal dal = new AtmDal();
            return dal.isUserAvailable(id);
        }

        //depositing cash
        public void DepositCash(int id, int amnt)
        {
            AtmDal dal = new AtmDal();
            dal.DepositCash(id, amnt);
        }

        //displaying balance
        public string DisplayBalance(int id)
        {
            AtmDal dal = new AtmDal();
            return dal.DisplayBal(id);
        }

        //Checking if admin is authenticated
        public string checkAdmin(AtmBoAd d)
        {
            AtmDal dal = new AtmDal();
            return dal.checkAdmin(d);
        }

        //creating account function from DAL
        public void CreateAccount(string login, int pin, string hName, string t, string s, int bal)
        {
            AtmDal dal = new AtmDal();
            dal.CreateAccount(login, hName, pin, t, s, bal);
        }

        //getting user information
        public string getUserInfo(int id)
        {
            AtmDal dal = new AtmDal();
            return dal.getUserInfo(id);
        }

        //deleting account from database
        public void DeleteAccount(int id)
        {
            AtmDal dal = new AtmDal();
            dal.DelAccount(id);
        }

        //updating account
        public void UpdateAccount(int id, string login, int pin, string hName, string status)
        {
            AtmDal dal = new AtmDal();
            dal.UpdateAccount(id, login, pin, hName, status);
        }
        
        //searching account on the basis of amount
        public List<AtmBoCust> SearchAccount(int m1,int m2)
        {
            AtmDal dal = new AtmDal();
            return dal.SeacrhAccount(m1, m2);
        }
   
        //print receipt
        public string PrintReceipt(int id)
        {
            AtmDal dal = new AtmDal();
            return dal.PrintReceipt(id);
        }

    }

}
