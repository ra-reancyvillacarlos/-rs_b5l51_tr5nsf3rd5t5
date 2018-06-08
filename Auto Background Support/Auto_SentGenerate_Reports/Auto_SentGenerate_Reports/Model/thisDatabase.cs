using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using Npgsql;

namespace Auto_SentGenerate_Reports
{
    public class thisDatabase
    {
        public static String driveloc = "\\\\RIGHTAPPS\\RightApps\\";//"\\\\RA-PDAC\\RightApps\\";// 
        public static String comp_folder = "BALAI";
        public static String lcl_db = "inv_balai_060818"; // "inv_balai_stotomas2"; inv_balai_060818
        public static String svr_pass = "Rightech777";

        public static String schema_static = "rssys";

        //public static String servers = System.IO.File.ReadAllText(driveloc + comp_folder + "\\Publish\\localDatabase.txt");
        public static String servers = "localhost";
         public String schema = schema_static;
         
         GlobalMethod gm;

         NpgsqlConnection conn;

         public thisDatabase()
         {
             try
             {
                 gm = new GlobalMethod();
                 conn = new NpgsqlConnection("Server=" + servers + ";Port=5432;User Id=postgres;Password=" + svr_pass + ";Database=" + lcl_db + ";");
             }
             catch(Exception er)
             {
                 MessageBox.Show(er.Message);
             }
         }
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

        //return user id if success, otherwise null
        public String validate_login(String user, String pass, String comp)
        {
            try
            {
                String flag = null;

                this.OpenConn();

                String SQL = "Select uid FROM " + schema + ".X08 WHERE uid='" + user.ToUpper() + "' AND pwd='" + pass + "'";

                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                    flag = dr[0].ToString();

                this.CloseConn();


                return flag;
            }
            catch (Exception)
            { }

            return null;
        }

        public String getFullName()
        {
            thisDatabase db = new thisDatabase();
            DataTable dt = db.QueryOnTableWithParams("x08", "opr_name", "", "");

            String fullName = "";

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fullName = dt.Rows[i]["opr_name"].ToString();
                }
            }
            catch (Exception)
            {

            }

            return (fullName != null) ? fullName : "NONAME";
        }

        public Boolean InsertOnTable(String table, String column, String value)
        {
            Boolean flag = false;

            if (GlobalClass.branch != "001" && GlobalClass.DontSendToMain == false)
            {
                //thisDatabase2 db2 = new thisDatabase2();
                //db2.InsertOnTable(table, column, value);
            }

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
            catch (NpgsqlException er)
            {
                flag = false;
                MessageBox.Show(er.Message + "\n" + er.Message);
            }

            return flag;
        }

        public Boolean UpdateOnTable(String table, String col_upd, String cond)
        {
            Boolean flag = false;

            if (GlobalClass.branch != "001" && GlobalClass.DontSendToMain == false)
            {
                thisDatabase2 db2 = new thisDatabase2();
                db2.UpdateOnTable(table, col_upd, cond);
            }

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

            if (GlobalClass.branch != "001" && GlobalClass.DontSendToMain == false)
            {
                thisDatabase2 db2 = new thisDatabase2();
                db2.DeleteOnTable(table, cond);
            }
            
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

        /// EXTRA METHODS

        public Boolean isExists(String table, String sqlcheck)
        {
            DataTable dt;
            Boolean flag = false;

            try
            {
                dt = this.QueryOnTableWithParams(table, "1", sqlcheck, "");

                if (dt.Rows[0][0].ToString() == "1")
                {
                    flag = true;
                }
            }
            catch (Exception)
            { }

            return flag;
        }

        public String str_E(String str)
        {
            if (String.IsNullOrEmpty(str))
            {
                str = "'" + str + "'";
            }
            else
            {
                str = "$$" + str + "$$";
            }

            return str;
        }

        public String castToInteger(String col)
        {
            return "COALESCE(CAST(SUBSTRING(" + col + " FROM '([0-9]{1,10})') AS INTEGER), 0)";
            //            return "COALESCE(CAST(SUBSTRING(" + col + " FROM '([0-9]{1,10})') AS INTEGER), 0)";
        }

        /// END OF EXTRA METHODS 

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

                if (String.IsNullOrEmpty(cond))
                {
                    cond = "";
                }
                else
                {
                    cond = " WHERE " + cond;
                }

                string SQL = "SELECT " + param + " FROM " + this.schema + "." + table + " " + cond + " " + addcode;
                //MessageBox.Show(SQL);
                Console.WriteLine(SQL);
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
                Console.WriteLine(SQL);

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

        public String get_m99comp_name()
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("m99", "comp_name", "", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["comp_name"].ToString();
                }
            }
            catch (Exception er)
            { }

            return val;
        }

        public String get_m99comp_addr()
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("m99", "comp_addr", "", "");

            for (   Int32 i = 0; i < dt.Rows.Count; i++)
            {
                //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                val = dt.Rows[i]["comp_addr"].ToString();
            }

            return val;
        }

        //current default branch
        public String get_m99branch()
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("m99", "branch", "", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["branch"].ToString();
                }
            }
            catch (Exception er)
            { }

            return val;
        }

        public String get_branchname(String branch_code)
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("branch", "name", "code='"+branch_code+"'", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["name"].ToString();
                }
            }
            catch (Exception)
            { }

            return val;
        }

        public String get_branchnameOfWhouse(String whs_code)
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("whouse", "branch", "whs_code='" + whs_code + "'", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["branch"].ToString();
                }
            }
            catch (Exception)
            { }

            return val;
        }

        public String get_systemdate(String format)
        {
            String tdate = "";
            DataTable dt = this.QueryOnTableWithParams("m99", "trnx_date", "", "");

            try
            {
                if (String.IsNullOrEmpty(format) == false)
                {
                    format = "yyyy-MM-dd";
                }

                if (GlobalClass.projcompany == "1" || GlobalClass.projcompany == "4")
                {
                    tdate = DateTime.Now.ToString(format);
                }
                else
                {
                    tdate = Convert.ToDateTime(dt.Rows[0]["trnx_date"]).ToString(format);
                }

                //temporary
                tdate = DateTime.Now.ToString(format);
            }
            catch (Exception er)
            {
                tdate = DateTime.Now.ToString("yyyy-MM-dd");

                MessageBox.Show("Error on date. Date/Time set to your workstation date and time. " + tdate + "\n\n Error :" + er.Message);
            }

            return tdate;
        }

        public String get_systemtime()
        {
            return DateTime.Now.ToString("HH:mm");
        }

        public String get_system_loc()
        {
            String system_loc = "";
            DateTime ldt;
            DataTable dt = this.QueryOnTableWithParams("m99", "system_loc", "", "");

            try
            {
                system_loc = dt.Rows[0]["system_loc"].ToString();
            }
            catch (Exception) { }

            return system_loc;
        }

        //get pk value that used for the table. input: m99col = column of m99
        public String get_pk(String m99col)
        {
            String pk = "";
            
            try
            {
                DataTable dt = this.QueryOnTableWithParams("m99", m99col, "", "");

                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    pk = dt.Rows[i][m99col].ToString();
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return pk;
        }

        public String get_nextincrementlimitchar(String val, int limit)
        {
            string newvalue = "";
            int len = val.Length;            
            var split = val.ToCharArray();
            int num = 0;

            try
            {
                if (split[0] == 'A')
                {
                    split[0] = '0';
                    var temp = new String(split);
                    num = Convert.ToInt32(temp);
                    num++;
                }
                else
                {
                    num = Convert.ToInt32(val);
                    num++;
                }

                while (len > 0)
                {
                    newvalue += "0";
                    len--;
                }

                newvalue = num.ToString(newvalue);                
            }
            catch (Exception er) { MessageBox.Show("Exception on get_nextincrementlimitchar " + er.Message ); }

            return newvalue;
        }

        public Boolean set_all_pk(String table, String pkcol, String pk_val, String cond, int limit)
        {
            String newpk = get_nextincrementlimitchar(pk_val, limit);

            return this.UpdateOnTable(table, pkcol + "='" + newpk + "'", cond);
        }
        
        public Boolean set_pkm99(String m99col, String val)
        {
            return this.UpdateOnTable("m99", m99col + "='" + val + "'", "");
        }

        public Boolean set_cancel(String table, String code_or_cond)
        {
            return this.UpdateOnTable(table, "cancel='Y'", code_or_cond);
        }

        // get next increment value with 6 characters.. 
        public String get_nextincrement(String val)
        {
            string newvalue = string.Empty;

            int len = val.Length;
            //string split = val.Substring(2, len - 2);
            int num = Convert.ToInt32(val);
            num++;
            //newvalue = val.Substring(0, 2) + num.ToString("0000");

            newvalue = num.ToString("000000");

            return newvalue;
        }

        //get next increment value with limit of characters.. min: 3 chars. max: 8chars
        //public String get_nextincrementlimitchar(String val, int limit)
        //{
        //    string newvalue = string.Empty;
        //    //MessageBox.Show(val.ToString());
        //    int len = val.Length;
        //    //string split = jid.Substring(2, len - 2);
        //    int num = Convert.ToInt32(val);
        //    num++;
        //    //newvalue = jid.Substring(0, 2) + num.ToString("0000");

        //    if (limit == 3)
        //        newvalue = num.ToString("000");
        //    else if (limit == 4)
        //        newvalue = num.ToString("0000");
        //    else if (limit == 5)
        //        newvalue = num.ToString("00000");
        //    else if (limit == 6)
        //        newvalue = num.ToString("000000");
        //    else if (limit == 7)
        //        newvalue = num.ToString("0000000");
        //    else if (limit == 8)
        //        newvalue = num.ToString("00000000");

        //    return newvalue;
        //}

        //get the last value of key in a table.
        public String get_colval(String table, String col, String cond)
        {
            String pk = "";

            DataTable dt = this.QueryOnTableWithParams(table, col, cond, "ORDER BY " + col + " ASC");

            for (Int32 i = 0; i < dt.Rows.Count; i++)
            {
                pk = dt.Rows[i][col].ToString();
            }

            return pk;
        }

        public int get_cntrow(String table, String col, String cond)
        {
            DataTable dt = this.QueryOnTableWithParams(table, col, cond, "ORDER BY " + col + " ASC");

            return dt.Rows.Count;
        }

        public String get_schema()
        {
            return this.schema;
        }


        ////////////////////////////////////////////

        public String get_m99time()
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("m99", "sched_time", "", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["sched_time"].ToString();
                }
            }
            catch (Exception er)
            { }

            return val;
        }
        public String get_m99smsrecipient()
        {
            String val = "";

            DataTable dt = this.QueryOnTableWithParams("m99", "sms_recipient_num", "", "");
            try
            {
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    //tdate = Convert.ToDateTime(dt.Rows[i]["trnx_date"]).ToString("MMM dd, yyyy");
                    val = dt.Rows[i]["sms_recipient_num"].ToString();
                }
            }
            catch (Exception er)
            { }

            return val;
        }
    }
}