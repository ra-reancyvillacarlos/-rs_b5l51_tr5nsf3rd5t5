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

namespace GSMModem
{
    public partial class EmailBlasting : Form
    {
        
        private bool portOpen;
      
        private DataTable date_to_send;
        private DataTable recipients;

        private DateTime date;
        thisDatabase db;
        GlobalMethod gm;
        public EmailBlasting()
        {
            this.db = new thisDatabase();
            gm = new GlobalMethod();
            InitializeComponent();
        }

        private void EmailBlasting_Load(object sender, EventArgs e)
        {
            sendWorker.RunWorkerAsync();


        }

        public void initiate_sending()
        {
            String query = "";
            String send_date = "";
            String send_time = "";
            do
            {
                try
                {
                    send_date = gm.toDateString(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd");
                    query = "SELECT tb_emailid,message,file_path,sender_email,sender_pass FROM rssys.tb_emailhdr WHERE send_date <= '" + db.get_systemdate("yyyy-MM-dd") + "' AND time_sent <= '" + DateTime.Now.ToString("hh:mm tt") + "'ORDER BY send_date DESC";
                    date_to_send = db.QueryBySQLCode(query);
                    if (date_to_send.Rows.Count > 0)
                    {
                        for (int i = 0; i < date_to_send.Rows.Count; i++)
                        {
                            send_email_blast(date_to_send.Rows[i]["tb_emailid"].ToString(), date_to_send.Rows[i]["message"].ToString(), date_to_send.Rows[i]["file_path"].ToString(), date_to_send.Rows[i]["sender_email"].ToString(), date_to_send.Rows[i]["sender_pass"].ToString());
                            lbl_status.Invoke(new Action(() =>
                            {
                                lbl_status.Text = "IDLE";
                            }));
                        }
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
                catch (Exception ex)
                {

                }
            } while (true);
        }

        private void send_email_blast(String tbid, String message,String file_path,String sender_email,String sender_pass)
        {
            String email = "";
            String col = "";
            String val = "",name="";
            
            String tableIn = "tb_email_recip";
            try
            {
                DataTable dt = db.QueryBySQLCode("SELECT a.*, b.d_name FROM rssys.tb_email_recip a LEFT JOIN rssys.m06 b ON b.d_code = a.d_code  WHERE a.tb_emailid = '" + tbid + "' AND a.sent_stat != 'Y' ORDER BY a.tb_emailid DESC");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        email = dt.Rows[i]["email"].ToString();
                        name = dt.Rows[i]["d_name"].ToString();
                        if (send(email, name, message,file_path,sender_email,sender_pass)) 
                        {
                            lbl_status.Invoke(new Action(() =>
                            {
                                lbl_status.Text = "Sending";
                            }));
                            col = "sent_stat='Y',date_sent='" + DateTime.Now.ToString("yyyy-MM-dd") +"',time_sent='"+DateTime.Now.ToString("hh:mm tt")+"'";
                            db.UpdateOnTable(tableIn, col, "tb_emailid='" + tbid + "'");
                        }
                        Thread.Sleep(3000);
                    }
                }
            }
            catch { }
           

                
        }
        private bool send(String email, String name, String message,String file_path, String sender_email, String sender_pass)
        {
            bool ok = false;
            try
            {

                string smtpAddress = "smtp.googlemail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = sender_email;
                string password = sender_pass;
                string emailTo = email;
                string subject = "KIA";
                string body = "";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = get_html(email, name, message);
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.  
                    mail.Attachments.Add(new Attachment(file_path));


                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        try
                        {
                            smtp.Send(mail);
                            ok = true;
                        }
                        catch (Exception ex)
                        {
                            ok = false;
                        }
                    }
                }
            }
            catch { }
       
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
            sb.Append("Dear  " + name + " ,");
            sb.Append("</p>");
            sb.Append("<p style='font-size:medium;'>");
            //sb.Append("<em>");
            sb.Append(message);
           // sb.Append("</em>");
            sb.Append("</p>");
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        private void EmailBlasting_MinimumSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
         
        }

        private void EmailBlasting_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
    }
}
