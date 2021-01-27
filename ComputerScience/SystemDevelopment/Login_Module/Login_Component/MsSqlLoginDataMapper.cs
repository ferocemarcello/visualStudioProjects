using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Component;
using Login_Component.Exceptions;

namespace Login_Component
{
    public class MsSqlLoginDataMapper : MsSqlConnect, ILoginDataMapper
    {

        public MsSqlLoginDataMapper(string connectionString) : base(connectionString)
        {
        }

        public void CreateTable(string table_name)
        {
            ConnectDB();
            sqlCommandString = "CREATE TABLE "+table_name+"(email varchar(255),password varchar(255));";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        public User[] ReadAllUsers()
        {
            ConnectDB();
            sqlCommandString = "SELECT * FROM UserFeroceNemati";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            
            LinkedList<User> users = new LinkedList<User>();
            string[] usfield = new string[2];
            reader = cmd.ExecuteReader();
            bool existing = true;
            do
            {
                existing = reader.Read();
                if (existing)
                {
                    usfield[0] = (string)reader["email"];
                    usfield[1] = (string)reader["password"];
                    users.AddLast(new User(usfield[0], usfield[1]));
                }
            }
            while (existing);
            CloseDB();
            return users.ToArray();
        }
        public string[] SelectTables()
        {
            ConnectDB();
            sqlCommandString = "USE EAL5_DB GO SELECT * FROM INFORMATION_SCHEMA.TABLES;";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            reader.Read();
            CloseDB();
            return (string[])reader[0];

        }

        public void DeleteTable(string table_name)
        {
            ConnectDB();
            sqlCommandString = "DROP TABLE "+table_name;
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }
        public LinkedList<string> AllDatabases()
        {
            LinkedList<string> dbs = new LinkedList<string>();
            ConnectDB();
            sqlCommandString = "SELECT name FROM master.dbo.sysdatabases";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            reader = cmd.ExecuteReader();
            bool existing = true;
            do
            {
                existing=reader.Read();
                if (existing)
                {
                    dbs.AddLast((string)reader["name"]);
                }
                
            }
            while(existing);
            return dbs;
        }
        /*public string[] SelectTables()
        {
            ConnectDB();
            sqlCommandString = "USE EAL5_DB GO SELECT * FROM INFORMATION_SCHEMA.TABLES;";
           cmd = new SqlCommand(sqlCommandString, dbconn);
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            reader.Read();
            CloseDB();
            return (string[])reader[0];
            
        }*/
        public void CreateDatabase(string databaseName)
        {
            ConnectDB();
            sqlCommandString = "CREATE DATABASE "+databaseName+";";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            CloseDB();
        }
        public void Create(string email, string encryptedPassword)
        {
            foreach (User u in ReadAllUsers())
            {
                if (u.GetEmail().Equals(email))
                {
                    throw new AlreadyExistingUserException();
                }
            }
            ConnectDB();
            sqlCommandString = "insert into UserFeroceNemati(email,password) values ('" + email + "','" +encryptedPassword + "')";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            cmd.ExecuteNonQuery();
            CloseDB();
        }

        //TODO: decouple Read and delete?
        public void Delete(string email, string encryptedPassword)
        {
            User u = Read(email, encryptedPassword);
            ConnectDB();
            
            if (u != null)
            {
                if (u.GetPassword()!=null)
                {
                    sqlCommandString = "delete from UserFeroceNemati where email = '"+email+ "'";
                    cmd = new SqlCommand(sqlCommandString, dbconn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new InvalidPasswordException();
                }
            }
            else
            {
                throw new NonExistingUserException();
            }
                
            CloseDB();
        }

        public void DeleteTODELETE(string email, string encryptedPassword)
        {
            ConnectDB();

                    sqlCommandString = "delete from UserFeroceNemati where email = '" + email + "'";
                    cmd = new SqlCommand(sqlCommandString, dbconn);
                    cmd.ExecuteNonQuery();

            CloseDB();
        }

        public User Read(string email, string encryptedPassword)
        {
            ConnectDB();
            sqlCommandString = "select email, password from UserFeroceNemati where email = '" + email + "'";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            reader = cmd.ExecuteReader();
            User newU = null;
            if (reader.Read())
            {
                if (((string)reader["password"]).Equals(encryptedPassword))
                {
                    newU = new User(email, encryptedPassword);
                }
                else
                {
                    newU= new User(email,null);
                }

            }
            CloseDB();
            return newU;
        }

        public void UpdateMail(string email, string newMail)
        {
           
            ConnectDB();
            sqlCommandString = "update UserFeroceNemati set email = '" + newMail + "'";
            cmd = new SqlCommand(sqlCommandString, dbconn);
            int i = cmd.ExecuteNonQuery();
            CloseDB();
            if (i==0)
                throw new NonExistingUserException();
        }

        public void UpdatePassword(string email, string encryptedPassword, string encryptedNewPassword)
        {
            User u = Read(email, encryptedPassword);
            ConnectDB();

            if (u != null)
            {
                if (u.GetPassword() != null)
                {
                    sqlCommandString = "update UserFeroceNemati set password = '" + encryptedNewPassword + "'";
                    cmd = new SqlCommand(sqlCommandString, dbconn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new InvalidPasswordException();
                }
            }
            else
            {
                throw new NonExistingUserException();
            }

            CloseDB();
        }
    }
}
