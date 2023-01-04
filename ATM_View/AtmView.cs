using ATM_BO;
using ATM_BLL;
using System;
using System.Collections.Generic;

namespace ATM_View
{
    public class AtmView
    {
        //getting the user
        public void selectUser()
        {
      
            Console.Write("1- Press 1 if you are Customer : ");
            Console.Write("1- Press 2 if you are Admin : ");

            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                //calling customer input if user press 1
                getInput();
            }
            else if (op == 2)
            {
                //calling admin view if user presses 2 
                getInputAdmin();
            }
        }

        //view to get input from customer user 
        public void getInput()
        {
            
            int count = 0, flag = 0;
            AtmBLL bx = new AtmBLL();
            //customer business object 
            AtmBoCust b1 = new AtmBoCust();
            do
            {
                Console.Write("Enter Login Name : ");
                string userName = Console.ReadLine();
                Console.Write("Enter Pin Code : ");
                int userPin = int.Parse(Console.ReadLine());

                b1 = new AtmBoCust() { Name = userName, Pin = userPin };

                if (bx.checkUser(b1) != null)
                {
                    flag = 1;  //return value if successfully loging in
                    
                    count = 3;
                    CustomerMenu(b1);
                    count = 0;
                }
                else
                {
                    flag = 0;
                    count++;
                }
            }
            //checking if user consecutively enter wrong password for third time
            while ((bx.checkUser(b1) == null) && count != 3);
            {
                if (flag == 0)
                {
                    Console.WriteLine("Login Attempt Failed");
                }
                else if (flag == 1)
                {
                    CustomerMenu(b1);
                }
            }

        }

        //customer menu after login
        public void CustomerMenu(AtmBoCust b)
        {
            Console.WriteLine("Please Select one of the below options ");
            Console.WriteLine("1-- Withdraw Cash");
            Console.WriteLine("2-- Cash Transfer");
            Console.WriteLine("3-- Deposit Cash");
            Console.WriteLine("4-- Display Balance");
            Console.WriteLine("5-- Exit");
            int opt = int.Parse(Console.ReadLine());

            //whihc option user want to select 
            if (opt == 1)
            {
                Console.WriteLine("1-- Fast Cash ");
                Console.WriteLine("2-- Normal Cash");
                int opX = int.Parse(Console.ReadLine());
                if (opX == 1)
                {
                    Console.WriteLine("1-- 500");
                    Console.WriteLine("2-- 1000");
                    Console.WriteLine("3-- 2000");
                    Console.WriteLine("4-- 5000");
                    Console.WriteLine("5-- 10000");
                    Console.WriteLine("6-- 15000");
                    Console.WriteLine("7-- 20000");

                    int md = int.Parse(Console.ReadLine());
                    if (md == 1)
                    {
                        int cash = 500;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 2)
                    {
                        int cash = 1000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 3)
                    {
                        int cash = 2000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 4)
                    {
                        int cash = 5000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 5)
                    {
                        int cash = 10000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 6)
                    {
                        int cash = 15000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                    else if (md == 7)
                    {
                        int cash = 20000;
                        Console.Write($"Are you sure you want to WithDraw Rs.{cash} (Y/N) ? ");
                        string res = (Console.ReadLine());
                        AtmBLL b1 = new AtmBLL();
                        int id = int.Parse(b1.checkUser(b));

                        b1.FastCash(id, cash);
                        if (res == "Y" || res == "y")
                        {
                            Console.WriteLine("Cash Successfully Withdrawn ");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)? ");
                            string rec = Console.ReadLine();
                            if (rec == "Y" || rec == "y")
                            {
                                //call print receipt 
                                Console.WriteLine(b1.PrintReceipt(b.cid));
                                Console.WriteLine("Print receipt function called");
                            }
                            else
                            {
                                Console.WriteLine("Transaction completed without receipt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed");
                        }
                    }
                }
                else if (opX == 2)
                {
                    Console.WriteLine("Enter the withdrawal amount : ");
                    int cash = int.Parse(Console.ReadLine());

                    AtmBLL b1 = new AtmBLL();
                    b1.NormalCash(b, cash);
                    Console.WriteLine("Do you want to print receipt (Y/N ) ?");
                    string rec = (Console.ReadLine());
                    if (rec == "Y" || rec == "y")
                    {
                        //call print receipt 
                        Console.WriteLine(b1.PrintReceipt(b.cid));
                        Console.WriteLine("Print receipt function called");
                    }
                    else
                    {
                        Console.WriteLine("Transaction completed without receipt");
                    }
                }

            }
            else if (opt == 2)
            {

                Console.Write("Enter the amount in multiples of 500 : ");
                int amnt = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter id of person for transaction : ");
                int id1 = int.Parse(Console.ReadLine());

                AtmBLL b1 = new AtmBLL();
                string r = b1.isUserAvailable(id1);

                Console.WriteLine($"Do you wish to transfer Rs.{amnt} in account held by Mr. {r} If this info is correct please " +
                    $"re-enter the account number : ");
                int id2 = int.Parse(Console.ReadLine());
                if (id1 == id2)
                {
                    int idofPerson = int.Parse(b1.checkUser(b));
                    b1.CashTransfer(idofPerson, id1, amnt);

                    Console.WriteLine("Do you want to print receipt (Y/N) ?");
                    string rec = (Console.ReadLine());
                    if (rec == "Y" || rec == "y")
                    {
                        //call print receipt 
                        Console.WriteLine(b1.PrintReceipt(b.cid));
                        Console.WriteLine("Print receipt function called");
                    }
                    else
                    {
                        Console.WriteLine("Transaction completed without receipt");
                    }

                }
            }
            else if (opt == 3)
            {
                Console.WriteLine("Enter the cash amount you want to deposit : ");
                int amnt = int.Parse(Console.ReadLine());


                AtmBLL b1 = new AtmBLL();
                int idofPerson = int.Parse(b1.checkUser(b));

                b1.DepositCash(idofPerson, amnt);

                Console.WriteLine("Cash deposited successfully ");
                Console.WriteLine("Do you want to print receipt (Y/N) ?");
                string rec = (Console.ReadLine());
                if (rec == "Y" || rec == "y")
                {
                    //call print receipt 
                    Console.WriteLine(b1.PrintReceipt(b.cid));
                    Console.WriteLine("Print receipt function called");
                }
                else
                {
                    Console.WriteLine("Transaction completed without receipt");
                }
            }

            else if (opt == 4)
            {
                AtmBLL b1 = new AtmBLL();
                int idofPerson = int.Parse(b1.checkUser(b));
                //b1.DisplayBalance(idofPerson);
                Console.WriteLine(b1.DisplayBalance(idofPerson));
            }
            else if (opt == 5)
            {
                Environment.Exit(2);
            }
        }

        //view for admin 
        public void getInputAdmin()
        {
            int count = 0, flag = 0;
            AtmBLL bx = new AtmBLL();
            //admin business object 
            AtmBoAd d1 = new AtmBoAd();

            do
            {
                Console.Write("Enter Admin Login Name : ");
                string userName = Console.ReadLine();
                Console.Write("Enter Pin Code : ");
                int userPin = int.Parse(Console.ReadLine());

                d1 = new AtmBoAd() { AdminName = userName, Pin = userPin };

                if (bx.checkAdmin(d1) != null)
                {
                    flag = 1;  //return value if successfully loging in

                    count = 3;
                    AdminMenu();
                    count = 0;
                }
                else
                {
                    flag = 0;
                    count++;
                }
            }
            while ((bx.checkAdmin(d1) == null) && count != 3);
            {
                if (flag == 0)
                {
                    Console.WriteLine("Login Attempt Failed");
                }
                else if (flag == 1)
                {
                    AdminMenu();
                }
            }
            
        }
        
        //admin menu
        public void AdminMenu()
        {
            Console.WriteLine("Select one of the options below ");
            Console.WriteLine("1-- Create Account");
            Console.WriteLine("2-- Delete Existing Account");
            Console.WriteLine("3-- Update Account Information");
            Console.WriteLine("4-- Search for Account");
            Console.WriteLine("5-- View Reports");
            Console.WriteLine("6-- Exit ");
            int adminInput = int.Parse(Console.ReadLine());
            if (adminInput == 1)
            {
                //Admin view for creating account
                CreateAccountView();
            }
            else if (adminInput == 2)
            {
                DeleteAccountView();
            }
            else if (adminInput == 3)
            {
                UpdateAccountInfo();
            }
            else if (adminInput == 4)
            {
                SearchAccount();
            }
        }

        //creating account view
        public void CreateAccountView()
        {

            Console.Write("Enter Login : ");
            string login = Console.ReadLine();

            Console.Write("Enter PIN : ");
            int pin = int.Parse(Console.ReadLine());

            Console.WriteLine("Holders Name : ");
            string name = Console.ReadLine();

            Console.Write("Type (Savings/ Current)");
            string type = Console.ReadLine();

            Console.Write("Starting Balance : ");
            int bal = int.Parse(Console.ReadLine());

            Console.WriteLine("Status (Active/Blocked)");
            string status = Console.ReadLine();


            AtmBLL b1 = new AtmBLL();
            b1.CreateAccount(login, pin, name, type, status, bal);

            Console.WriteLine("Account Successfully Created");
        }

        //delete account view
        public void DeleteAccountView()
        {
            Console.WriteLine("Enter the user id whose account you want to delete ");
            int id1 = int.Parse(Console.ReadLine());
            AtmBLL b1 = new AtmBLL();
            string r = b1.isUserAvailable(id1);
            Console.WriteLine($"Do you wish to delete account held by Mr. {r} If this info is correct please " +
                    $"re-enter the account number : ");
            int id2 = int.Parse(Console.ReadLine());
            if (id1 == id2)
            {
                b1.DeleteAccount(id1);
                Console.WriteLine($"User Account with id :{id1} deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete account");
            }

        }

        //updating account
        public void UpdateAccountInfo()
        {

            Console.Write("Enter the account Id : ");
            int id = int.Parse(Console.ReadLine());
            AtmBLL b1 = new AtmBLL();
            string cuurInfo = b1.getUserInfo(id);

            if (b1.getUserInfo(id) == null)
            {
                Console.WriteLine("User With tis id not found");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine(cuurInfo);
            }

            Console.WriteLine("Please enter the fields you wish to update (leave Blank Otherwise)");
            Console.Write("Login : ");
            string login = Console.ReadLine();

            Console.Write("Enter PinCode : ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("HolderName : ");
            string hName = Console.ReadLine();

            Console.Write("Status : ");
            string status = Console.ReadLine();

            b1.UpdateAccount(id, login, pin, hName, status);
            Console.WriteLine("Account Info Updated Successfully ");
        }

        //searching account 
        public void SearchAccount()
        {
            Console.WriteLine("1-- Search by Amount ");
            Console.WriteLine("2-- Search by Date ");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                Console.Write("Enter the minimum amount : ");
                int m1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the maximum amount : ");
                int m2 = int.Parse(Console.ReadLine());

                List<AtmBoCust> data = new List<AtmBoCust>();
                AtmBLL b1 = new AtmBLL();
                data = b1.SearchAccount(m1, m2);

                Console.WriteLine("Id" + "\t Name \t" + "\t Type" + " \t Cash " + " \t Status" );

                foreach (var i in data)
                {
                    Console.WriteLine(Convert.ToString(i.cid) + '\t' + i.Name + '\t' + i.type + '\t' + i.Cash + '\t' + i.status);
                }


            }

        }

    }
}

