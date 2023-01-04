using ATM_BO;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ATM_DAL
{
    public class AtmDal
    {
        public string AuthenticateUser(AtmBoCust bo)
        {
            //Establishing the connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //Defining a SQL Query for verifying user
            string query = "Select * from Customer Where UserName=@u and UserPin=@p";
            //Adding parameters 
            SqlParameter p1 = new SqlParameter("u", bo.Name);
            SqlParameter p2 = new SqlParameter("p", bo.Pin);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            //initializing the data reader
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //returning name from table 
                return $"{ dr[0]}";
            }
            else
            {
                return null;
            }
        }

        public void WithDrawCash(int id, int amnt)
        {
            //Establishing the connection
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //Sql Query for cash deduction
            string query = "UPDATE dbo.Customer SET Cash-=@a WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("a", amnt);
            SqlParameter p2 = new SqlParameter("id", id);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            //using ExecuteNonQuery for updation of balance in database
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //Function to deduct normal cash
        public void NormalCash(AtmBoCust b, int a)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //query for Normal Cash
            string query = "UPDATE dbo.Customer SET Cash-=@a WHERE UserName=@u AND UserPin=@p";

            //parameters in query
            SqlParameter p1 = new SqlParameter("u", b.Name);
            SqlParameter p2 = new SqlParameter("p", b.Pin);
            SqlParameter p3 = new SqlParameter("a", a);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //checking if user is available for cash transfer or not
        public string isUserAvailable(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //query to check user 
            string query = "SELECT * FROM dbo.Customer WHERE id=@i";
            SqlParameter p1 = new SqlParameter("i", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //returning username
                string res = $"{dr[1]}";
                return res;
            }
            else
            {
                string res = null;
                return res;
            }

        }

        //cash transfer
        public void CashTransfer(int id1, int id2, int amnt)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            if (isUserAvailable(id2) != null)
            {
                string ctquery = $"UPDATE dbo.Customer SET Cash+=@a WHERE Id=@id";
                SqlParameter p1 = new SqlParameter("id", id2);
                SqlParameter p2 = new SqlParameter("a", amnt);
                SqlCommand cmd = new SqlCommand(ctquery, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

                cmd.ExecuteNonQuery();

                string ctquery2 = $"UPDATE dbo.Customer SET Cash-=@ax WHERE Id=@idx";
                SqlParameter p1x = new SqlParameter("idx", id1);
                SqlParameter p2x = new SqlParameter("ax", amnt);

                SqlCommand cmd2 = new SqlCommand(ctquery2, con);

                cmd2.Parameters.Add(p1x);
                cmd2.Parameters.Add(p2x);


                cmd2.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("User With This Id is not Available");
            }
            con.Close();
        }

        //function to deposit cash
        public void DepositCash(int id, int amnt)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //query for adding cash in database
            string query = $"UPDATE dbo.Customer SET Cash+=@a WHERE Id=@id";
            SqlParameter p1 = new SqlParameter("a", amnt);
            SqlParameter p2 = new SqlParameter("id", id);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //function to display balance
        public string DisplayBal(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            string query = "SELECT * FROM dbo.Customer WHERE Id=@id";
            SqlParameter p1 = new SqlParameter("id", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return $"Account Number : {dr[0]} \n Account Name : {dr[1]} \n  Balance : {dr[3]}\n";
            }
            else
            {
                return null;
            }
        }

        //checking if correct admin logging in 
        public string checkAdmin(AtmBoAd d)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            string query = "Select * from Admin Where AdminName=@u and AdminPW=@p";
            SqlParameter p1 = new SqlParameter("u", d.AdminName);
            SqlParameter p2 = new SqlParameter("p", d.Pin);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return $"{ dr[0]}";
            }
            else
            {
                return null;
            }
        }

        //admin creating account
        public void CreateAccount(string login, string hName, int pin, string t, string s, int bal)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //username in database is login info and is a primary key
            //login - login , holdername -hName , Pin - pin  , Type -t , Status -s , Balance - bal 
            string query = "INSERT INTO dbo.Customer(UserName,UserPin,Cash,HolderName,Type,Status) VALUES(@login,@pin,@bal,@hName,@t,@s) ";

            SqlParameter p1 = new SqlParameter("@login", login);
            SqlParameter p2 = new SqlParameter("@hName", hName);
            SqlParameter p3 = new SqlParameter("@pin", pin);
            SqlParameter p4 = new SqlParameter("@t", t);
            SqlParameter p5 = new SqlParameter("@s", s);
            SqlParameter p6 = new SqlParameter("@bal", bal);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        //getting information of user 
        public string getUserInfo(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            string query = "SELECT * FROM dbo.Customer where Id=@id";

            SqlParameter p1 = new SqlParameter("id", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return $"Account Id : {dr[0]} \n Login : {dr[1]} \n Account Holder : {dr[4]} \n  Account Type: {dr[5]} \n Status :  {dr[6]} ";
            }
            else
            {
                return null;
            }

        }

        //delete account from customer database 
        public void DelAccount(int id)
        {
            string name = isUserAvailable(id);

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            if (name != null)
            {
                string query = "DELETE FROM dbo.Customer WHERE Id=@id";

                SqlParameter p1 = new SqlParameter("id", id);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
            }
            else
            {
                return;
            }
        }


        //Updating account 
        public void UpdateAccount(int id, string login, int pin, string hName, string status)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "UPDATE dbo.Customer SET  UserName=@login,UserPin=@p,HolderName=@hName,Status=@status WHERE Id=@id";

            SqlParameter p1 = new SqlParameter("login", login);
            SqlParameter p2 = new SqlParameter("p", pin);
            SqlParameter p3 = new SqlParameter("hName", hName);
            SqlParameter p4 = new SqlParameter("id", id);
            SqlParameter p5 = new SqlParameter("Status", status);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        //searching accounts on the basis of ammount 
        public List<AtmBoCust> SeacrhAccount(int m1, int m2)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            string query = $"SELECT * FROM dbo.Customer WHERE Cash>=@m1 AND Cash<=@m2";
            SqlParameter p1 = new SqlParameter("m1", m1);
            SqlParameter p2 = new SqlParameter("m2", m2);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            SqlDataReader dr = cmd.ExecuteReader();
            List<AtmBoCust> rows = new List<AtmBoCust>();

            while(dr.Read())
            {
                rows.Add(new AtmBoCust
                {
                    cid = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["HolderName"]),
                    Cash = Convert.ToInt32(dr["Cash"]),
                    type = Convert.ToString(dr["Type"]),
                    status = Convert.ToString(dr["Status"])
                });         
            }

            con.Close();
            return rows;
        }

        public string PrintReceipt(int id)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //print receipt Sql Query 
            string query = "SELECT * FROM dbo.Customer WHERE ID=@id";
            SqlParameter p1 = new SqlParameter("id", id);

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                // ID ,            Login Name , Cash , Holder Name , Account Type, Status
                return $"{dr[0]} , {dr[1]} , {dr[3]} , {dr[4]} , {dr[5]} , {dr[6]}";
            }

            else
            {
                return null;
            }
        }

    }



}