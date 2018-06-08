using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
namespace GSMModem
{
    public partial class EmailBlasting : Form
    {
        
        bool portOpen;
        DataTable recipients;
        DateTime date;
        thisDatabase db;
        thisDatabase2 db2;
        GlobalMethod gm;
        public EmailBlasting()
        {
            db = new thisDatabase();
            gm = new GlobalMethod();
            db2 = new thisDatabase2();
            InitializeComponent();
        }

        private void EmailBlasting_Load(object sender, EventArgs e)
        {
            sendWorker.RunWorkerAsync();
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
        public void initiate_sending()
        {
            String query = "";
            String table = "";
            String send_date = "";
            String send_time = "";
            String col = "", col2 = "", val = "", val2 = "";
            DataTable dt = null;
            String datavalue = "", cond="";
            String pk = "";
            String s = "";
            thisDatabase newdb = new thisDatabase();
            do
            {
                try
                {
                    query = "SELECT * FROM rssys.transferdata ORDER BY transfercode";
                    dt = newdb.QueryBySQLCode(query);
                  
                    if(dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            datavalue = "";

                          
                            lbl_status.Invoke(new Action(() =>
                            {
                                lbl_status.Text = "IDLE";
                            }));
                            
                           

                            if (dt.Rows[i]["action"].ToString() == "insert")
                            {
                               
                                try
                                {
                                    col = dt.Rows[i]["col"].ToString();
                                    val = EmailBlasting.Decrypt(dt.Rows[i]["val"].ToString(), "sblw-3hn8-sqoy19");
                                    table = dt.Rows[i]["tablename"].ToString();
                                    pk = dt.Rows[i]["transfercode"].ToString();
                                   
                                    if (db2.InsertOnTable(table, col, val))
                                    {
                                        try
                                        {
                                            if (newdb.DeleteOnTable("transferdata", "transfercode='" +pk + "'"))
                                            {
                                                
                                            }
                                        }
                                        catch (Exception er) { MessageBox.Show("Error:"+er.Message); }

                                    }
                                    else {
                                        
                                    }

                                }
                                catch (Exception er) { MessageBox.Show("Error:"+ er.Message); }


                            }
                            else if (dt.Rows[i]["action"].ToString() == "update")
                            {
                                try
                                {
                                    col = EmailBlasting.Decrypt(dt.Rows[i]["col"].ToString(), "sblw-3hn8-sqoy19");
                                    val = dt.Rows[i]["val"].ToString();
                                    cond = EmailBlasting.Decrypt(dt.Rows[i]["cond"].ToString(), "sblw-3hn8-sqoy19"); 
                                    table = dt.Rows[i]["tablename"].ToString();
                                    pk = dt.Rows[i]["transfercode"].ToString();
                                    if (db2.UpdateOnTable(table, cond,col ))
                                    {
                                        try
                                        {
                                            if (newdb.DeleteOnTable("transferdata", "transfercode='" + pk + "'"))
                                            {
                                               
                                            }
                                        }
                                        catch (Exception er) { MessageBox.Show(er.Message); }

                                    }
                                    else
                                    {
                                        //newdb.DeleteOnTable(table, "WHERE val='" + s + "'");
                                    }

                                }
                                catch (Exception er) { }
                            }
                            else if (dt.Rows[i]["action"].ToString() == "delete")
                            {
                                pk = dt.Rows[i]["transfercode"].ToString();

                                if (db2.DeleteOnTable(dt.Rows[i]["tablename"].ToString(), EmailBlasting.Decrypt(dt.Rows[i]["cond"].ToString(), "sblw-3hn8-sqoy19")))
                                {
                                    try
                                    {
                                        if (newdb.DeleteOnTable("transferdata", "transfercode='" + pk + "'"))
                                        {
                                            ///MessageBox.Show("Deleted");
                                        }
                                    }
                                    catch (Exception er) { MessageBox.Show(er.Message); }

                                }
                                else
                                {
                                    //newdb.DeleteOnTable(table, "WHERE val='" + s + "'");
                                }
                            }
                        }
                        lbl_status.Invoke(new Action(() =>
                        {
                            lbl_status.Text = "Records sent..";
                        }));
                    }
                    else
                    {
                        Thread.Sleep(6000);
                    }
                   // MessageBox.Show("Total Rows : "+dt.Rows.Count.ToString());
                }
                catch (Exception ex)
                {

                }
            } while (true);
        }

      
        private bool send(String email, String name, String message,String sender,String pass)
        {
            bool ok = false;
            

                string smtpAddress = "smtp.googlemail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = sender;
                string password = pass; 
                string emailTo = email;
                string subject = "FOR TESTING";
                string body = "";

               


       
            return ok;
        }

        private void sendWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            initiate_sending();
        }
        private string get_html(String email, String name, String message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head></head>");
            sb.Append("<body>");
            sb.Append("<div style='color:#e0e0d1;padding:30px;color:#000'>");
            sb.Append("<p>");
            sb.Append("Dear : <strong> " + name + "</strong>");
            sb.Append("</p>");
            sb.Append("<p style='font-size:meduim;'>");
            sb.Append("<em>");
            sb.Append(message);
            sb.Append("</em>");
            sb.Append("</p>");
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        private void EmailBlasting_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }  
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }
    }
}
