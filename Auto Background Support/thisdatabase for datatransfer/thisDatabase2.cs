using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using Npgsql;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
namespace Accounting_Application_System
{
    public class thisDatabase2
    {
        public static String server = "localhost";//System.IO.File.ReadAllText(thisDatabase.driveloc + thisDatabase.comp_folder + "\\Publish\\serverDatabase.txt"); //
        public static String lcl_db = thisDatabase.lcl_db;
        public static String svr_pass = thisDatabase.svr_pass;
        String schema = thisDatabase.schema_static;//*/
        string cipher = "", mac_add = "", decipher = "";
        NpgsqlConnection conn = new NpgsqlConnection("Server=" + server + ";Port=5432;User Id=postgres;Password=" + svr_pass + ";Database=" + lcl_db + ";");
        String ok;
        GlobalMethod gm = new GlobalMethod();

        public void OpenConn()
        {
            CloseConn();

            try
            {
                conn.Open();

                //MessageBox.Show("Connection State " + conn.State.ToString());
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Exception : " + er.Message);
            }
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(er.Message);
            }
        }

        public Boolean InsertOnTable(String table, String column, String value)
        {
            Boolean flag = false;

            try
            {
                this.OpenConn();

                string SQL = "INSERT INTO " + this.schema + "." + table + "(" + column + ") VALUES (" + value + ")";
                 //MessageBox.Show(SQL);
                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

                Int32 rowsaffected = command.ExecuteNonQuery();

                this.CloseConn();

                flag = true;
            }
            catch (Exception er)
            {
                flag = false;
                MessageBox.Show(er.Message);
            }

            return flag;
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        void auto_cipher()
        {
            if (mac_add != string.Empty)
            {

                if (mac_add != string.Empty)
                {
                    //Here key is of 128 bit  
                    //Key should be either of 128 bit or of 192 bit  
                    cipher = thisDatabase.Encrypt(mac_add, "sblw-3hn8-sqoy19");
                }
                if (cipher != string.Empty)
                {
                    //Key shpuld be same for encryption and decryption  
                    decipher = thisDatabase.Decrypt(cipher, "sblw-3hn8-sqoy19");
                }
                DataTable dt = new DataTable();
                dt = this.QueryBySQLCode("SELECT * from rssys.x09 WHERE licensed_pc='" + cipher + "'");
                if (dt.Rows.Count <= 0)
                {
                    //activation_form ac = new activation_form(this, mac_add, cipher);
                    //ac.ShowDialog();
                }
                else
                {
                    ok = "ok";
                }
            }
        }
        public Boolean UpdateOnTable(String table, String col_upd, String cond)
        {
            Boolean flag = false;

            try
            {
                this.OpenConn();

                if (cond != "")
                {
                    cond = " WHERE " + cond + "";
                }

                string SQL = "UPDATE " + this.schema + "." + table + " SET " + col_upd + "" + cond + ";";
                //MessageBox.Show(SQL);
                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

                Int32 rowsaffected = command.ExecuteNonQuery();

                this.CloseConn();

                flag = true;
            }
            catch (Exception er)
            {
                flag = false;
                MessageBox.Show(er.Message);
            }

            return flag;
        }

        public Boolean DeleteOnTable(String table, String cond)
        {
            Boolean flag = false;

            try
            {
                this.OpenConn();

                string SQL = "DELETE FROM " + this.schema + "." + table + " WHERE " + cond + ";";
                //MessageBox.Show(SQL);
                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

                Int32 rowsaffected = command.ExecuteNonQuery();

                this.CloseConn();

                flag = true;
            }
            catch (Exception)
            { flag = false; }

            return flag;
        }

        public DataTable QueryAllOnTable(string table)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                this.OpenConn();

                string SQL = "SELECT * FROM " + this.schema + "." + table + ";";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(SQL, conn);

                ds.Reset();

                da.Fill(ds);

                this.CloseConn();

                return ds.Tables[0];
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
                return null;
            }
        }

        public DataTable QueryOnTableWithParams(string table, String param, String cond, String addcode)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                this.OpenConn();

                if (cond == null || cond == "")
                {
                    cond = "";
                }
                else
                {
                    cond = " WHERE " + cond;
                }

                string SQL = "SELECT " + param + " FROM " + this.schema + "." + table + " " + cond + " " + addcode;
                //MessageBox.Show(SQL);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(SQL, conn);

                ds.Reset();

                da.Fill(ds);

                this.CloseConn();

                return ds.Tables[0];
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
                return null;
            }
        }

        public DataTable QueryBySQLCode(String SQL)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                this.OpenConn();

                //MessageBox.Show(SQL);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(SQL, conn);

                ds.Reset();

                da.Fill(ds);

                this.CloseConn();

                return ds.Tables[0];
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
                return null;
            }
        }
    }
}