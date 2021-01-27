using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class MsSqlDataMapper : MsSqlConnect, ILoginDataMapper
    {

        public MsSqlDataMapper(string connectionString) : base(connectionString)
        {
        }

        public void CreateTable(string table_name)
        {
            this.ConnectDB();
            sqlCommandString = "CREATE TABLE " + table_name + "(email varchar(255) NOT NULL,password varchar(255) NOT NULL,balance int NOT NULL,PRIMARY KEY (email));";
            this.cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        public void ClearTable()
        {
            ConnectDB();
            sqlCommandString = "TRUNCATE TABLE AuctionHouseProjectLetterB";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        public List<User> ReadAllUsers()
        {
            ConnectDB();
            sqlCommandString = "SELECT * FROM AuctionHouseProjectLetterB";
            cmd = new SqlCommand(sqlCommandString, dbconn);

            List<User> users = new List<User>();
            string[] usfield = new string[2];
            int balance = -1;
            reader = cmd.ExecuteReader();
            bool existing = true;
            do
            {
                existing = reader.Read();
                if (existing)
                {
                    usfield[0] = (string)reader["email"];
                    usfield[1] = (string)reader["password"];
                    balance = (int)reader["balance"];
                    users.Add(new User(usfield[0], usfield[1],balance));
                    
                }
            }
            while (existing);
            CloseDB();
            return users;
        }
        

        public void DeleteTable(string table_name)
        {
            ConnectDB();
            sqlCommandString = "DROP TABLE " + table_name;
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }
        
        
        public void Create(User us)
        {
            foreach (User u in ReadAllUsers())
            {
                if (u.getEmail().Equals(us.getEmail()))
                {
                    throw new AlreadyExistingUserException();
                }
            }
            ConnectDB();
            sqlCommandString = "insert into AuctionHouseProjectLetterB(email,password,balance) values ('" + us.getEmail() + "','" + us.getPassword() + "','" + us.getBalance()+ "')";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        //TODO: decouple Read and delete?
        public void Delete(string email)
        {
            User u = Read(email);
            ConnectDB();

            if (u != null)
            {
                if (u.getPassword() != null)
                {
                    sqlCommandString = "delete from AuctionHouseProjectLetterB where email = '" + email + "'";
                    cmd = new SqlCommand(sqlCommandString, dbconn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new DifferentPasswordException();
                }
            }
            else
            {
                throw new InvalidMailException();
            }

            CloseDB();
        }


        public User Read(string email)
        {
            ConnectDB();
            sqlCommandString = "select email, password, balance from AuctionHouseProjectLetterB where email = '" + email + "'";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            reader = cmd.ExecuteReader();
            User newU = null;
            if (reader.Read())
            {
                newU = new User(email, (string)reader["password"], (int)reader["balance"]);
            }
            CloseDB();
            return newU;
        }

        public void UpdateMail(string email, string newMail)
        {

            ConnectDB();
            sqlCommandString = "update AuctionHouseProjectLetterB set email = '" + newMail + "'where email='" + email + "'";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            int i = cmd.ExecuteNonQuery();
            CloseDB();
            if (i == 0)
                throw new InvalidMailException();
        }

        public void UpdatePassword(string email, string newPassword)
        {
            User u = Read(email);
            ConnectDB();

            if (u != null)
            {
                if (u.getPassword() != null)
                {
                    sqlCommandString = "update AuctionHouseProjectLetterB set password = '" + newPassword + "'where email='" + email;
                    cmd = new SqlCommand(sqlCommandString, dbconn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new DifferentPasswordException();
                }
            }
            else
            {
                throw new InvalidMailException();
            }

            CloseDB();
        }

        public void UpdateBalance(string email, int newBalance)
        {
            User u = Read(email);
            ConnectDB();
            if (u != null)
            {
                sqlCommandString = "update AuctionHouseProjectLetterB set balance = '" + newBalance + "'where email='" + email + "'";
                cmd = new SqlCommand(sqlCommandString, dbconn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
