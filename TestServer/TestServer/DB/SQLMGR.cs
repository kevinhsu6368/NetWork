using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

 
    public class SQLMGR
    {
        MySqlConnection gdb = new MySqlConnection();
        MySqlCommand gdbCmd = new MySqlCommand();
        string gdbHost = "192.168.1.102";
        string gdbUser = "kevin";
        string gdbPass = "0918854333";
        string gdbName = "sdb";

        private SQLMGR()
        {

        }

        static SQLMGR _Inst = new SQLMGR();

        public static SQLMGR Inst
        {
            get
            {
                return _Inst;
            }
        }

        public void Start()
        {
            string connStr = "server=" + gdbHost + ";uid=" + gdbUser + ";pwd=" + gdbPass + ";database=" + gdbName;
            gdb = new MySqlConnection(connStr);
            gdbCmd = gdb.CreateCommand();
            gdb.Open();
        }

        public Hashtable CustomLogin(string email,string pwd)
        {
            Hashtable hData = new Hashtable();
            gdbCmd.CommandText = string.Format("select uid,country,gender,photoId,firstName,nickName,lastName,birthday,background,animation from account where email='{0}' and pwd='{1}';", email,pwd);


            MySqlDataReader r = gdbCmd.ExecuteReader();

            if (!r.HasRows)
            {
                r.Close();
                return null;
            }

            try
            {
                while (r.Read())
                {
                    hData.Add("country", r.GetString("country"));
                    hData.Add("background", r.GetString("background"));
                    hData.Add("animation", r.GetString("animation"));
                    hData.Add("uid", r.GetInt32("uid"));
                    hData.Add("gender", r.GetInt32("gender"));
                    hData.Add("photoId", r.GetInt32("photoId"));
                    hData.Add("firstName", r.GetString("firstName"));
                    hData.Add("nickName", r.GetString("nickName"));
                    hData.Add("lastName", r.GetString("lastName"));
                    hData.Add("birthday", r.GetString("birthday"));
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
             r.Close();

            }


            


            return hData;
        }

         
        public void Close()
        {
            gdb.Close();
        }

    }

    public class SDB
    {
        public string ip;
        public string pwd;
        public string port;


    }
 