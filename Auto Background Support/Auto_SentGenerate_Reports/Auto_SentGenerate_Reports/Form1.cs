using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32;
using System.Net.Mime;

namespace Auto_SentGenerate_Reports
{
    public partial class Form1 : Form
    {

        String time_genrt = "";
        String date_today = "";
        String current_time = "";
        String export_filename = "";
        Boolean isnew = true;
        Boolean seltbp = true;
        thisDatabase db;
        String freq_type;

        

        ReportDocument myReportDocument;
        ParameterFieldDefinition crParameterFieldDefinition;
        ParameterValues crParameterValues;
        ParameterDiscreteValue crParameterDiscreteValue;
        ParameterFieldDefinitions crParameterFieldDefinitions;



        public string username1 = "", password1 = "", recipient = "", smtp = "", provider = "";
        public int port = 0;

        String comp_name, comp_addr;
        Timer _interval = new Timer();
        Boolean isBusy = false, isReset = true;
        String g_time, g_date, g_code,g_number;

        public List<Attachment> manyAttachments = new List<Attachment>();

        public Form1()
        {
            InitializeComponent();
            db = new thisDatabase();
            disp_list();
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            crParameterValues = new ParameterValues();
            crParameterDiscreteValue = new ParameterDiscreteValue();
            // 
            g_time = db.get_m99time();
            //MaximizeBox = true;
            MinimizeBox = true;
           // g_number = db.get_m99smsrecipient();
            comp_name = db.get_m99comp_name();
            comp_addr = db.get_m99comp_addr();
            bgWorker.RunWorkerAsync();
           
        }

        public void generateReports(String code)
        {
            try
            {

                label6.Text = "Generating Report ..." + code;

                //time_genrt = cbo_hour.Text + ":" + cbo_mins.Text + " " + cbo_ampm.Text;
                date_today = DateTime.Today.ToString("MM-dd-yyyy");
                current_time = DateTime.Now.ToString("h:mm tt");
                //time_genrt = txt_time.Text;

                txt_currenttime.Text = current_time;

                pg_loading.Value = 1;

                

                bgWorker.RunWorkerAsync();
                //MessageBox.Show(current_time);
                pg_loading.Value = 100;

                current_time = DateTime.Now.ToString("h:mm tt");
                pg_loading.PerformStep();

            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        void sendEmail1(string mailtype)
        {
            bool ok = false;
            String sender_email = "", sender_pass = "" , receiver_email="";
            DataTable dt,dt1 = new DataTable();
            label6.Invoke(new Action(() =>
            {
                label6.Text = "Sending reports..";
            }));
            try
            {
                inc_pbar(10);

                if (mailtype == "g")
                {
                    dt = db.QueryBySQLCode("SELECT email_sender,e_sender_password FROM rssys.m99");
                    dt1 = db.QueryBySQLCode("SELECT * FROM rssys.auto_email");
                    if (dt.Rows.Count > 0)
                    {
                        sender_email = dt.Rows[0]["email_sender"].ToString();
                        sender_pass = dt.Rows[0]["e_sender_password"].ToString();

                        if (dt1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                receiver_email = dt1.Rows[i]["email"].ToString();
                                //lbl_notif.Text = "";
                                lbl_notif.Invoke(new Action(() =>
                                {
                                    lbl_notif.Text = "Sending Reports to : " + receiver_email;
                                }));
                                send(sender_email, sender_pass, receiver_email);
                                lbl_notif.Invoke(new Action(() =>
                                {
                                    lbl_notif.Text = "";
                                    disp_list();
                                }));
                                
                                
                            }
                        }
                    }
                }
                else if (mailtype == "y")
                {
                    inc_pbar(10);
                    MailMessage mail = new MailMessage();
                    Attachment attch = new Attachment("d:/SalesOrder_01-26-2017_1_28_PM.pdf");

                    mail.From = new MailAddress("kervin.natural17@gmail.com");
                    mail.To.Add("idolanimuoi@gmail.com");
                    mail.Subject = "Daily Report";
                    mail.Body = "Ga himu ko c# app nga maka email. awa na dawat nimu sa?";
                    mail.Attachments.Add(attch);

                    
                    inc_pbar(10);
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("idolanimuoi@gmail.com", "14mp455w0rd");
                        smtp.EnableSsl = true;
                        try
                        {
                            smtp.Send(mail);
                            ok = true;
                        }
                        catch (Exception ex)
                        {
                            ok = false;
                            MessageBox.Show(ex.Message);
                        }
                    }

                    inc_pbar(10);
                    MessageBox.Show("Sent");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            label6.Invoke(new Action(() =>
            {
                label6.Text = "done..";
            }));
            inc_pbar(40);
            nextTimeToGenerate();
            reset_pbar();
        }

        public void send(String sender_email,String sender_pass, String receiver_email)
        {
             
            bool ok = false;
            String col = "", val="";
            DataTable dt = new DataTable();
            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(sender_email); /// sender of email report
            mail.To.Add(receiver_email); /// receiver of the email report
            mail.Subject = "Daily Report";
            mail.Body = "Here is your Sales report of this day " + date_today;

            //https://myaccount.google.com/lesssecureapps?pli=1

            mail.Attachments.Add(new Attachment("\\\\RIGHTAPPS\\RightApps\\BALAI\\101B_cashier_" + export_filename + ".pdf"));

            inc_pbar(10);
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                 
                 
                  
                    smtp.Credentials = new NetworkCredential(sender_email, sender_pass); // sender email and password
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                        ok = true;
                    }
                    catch (Exception ex)
                    {
                        ok = false;
                        MessageBox.Show(ex.Message);
                    }
                
            }
            inc_pbar(10);
            String details = " Email Sent to: " + receiver_email + "Time: " + DateTime.Now.ToString("h:mm tt") +" Date: "+DateTime.Now.ToString("yyyy-MM-dd");
            col = "identity,details";
            val = "'" + receiver_email + "','" + details + "'";
            
            
            db.InsertOnTable("auto_log",col,val);
             

        }
        private void button1_Click(object sender, EventArgs e)
        {
            pg_loading.Minimum = 0;
            try
            {
                String code = dgv_list["d_code", dgv_list.CurrentRow.Index].Value.ToString();
                generateReports(code);
            }
            catch {
                MessageBox.Show("No selected item.");
            }
        }
        private void add_fieldparam(String col, String val)
        {
            try
            {
                crParameterDiscreteValue.Value = val;
                crParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions[col];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                clr_param();

            }
            catch (Exception error) { MessageBox.Show(error.Message); }
        }
        private void clr_param()
        {
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String dnow = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            txt_dispnext.Invoke(new Action(() =>
            {
                txt_dispnext.Text = db.get_m99time();
            }));

            
            if (txt_dispnext.Text == DateTime.Now.ToString("hh:mm tt") || txt_dispnext.Text == DateTime.Now.ToString("h:mm tt"))
            {
                inc_pbar(10);
            generatedCashierReport(dnow, dnow);
           
            if (dnow == lastDayOfMonth.ToString("yyyy-MM-dd"))
            {
                inc_pbar(10);
                generatedCashierReport(firstDayOfMonth.ToString("yyyy-MM-dd"), lastDayOfMonth.ToString("yyyy-MM-dd"));
            }
            }
        }

        public void generatedCashierReport(String dt_frm, String dt_to)
        {
            export_filename = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt").Replace("-", "_").Replace(":", "_").Replace(" ", "_");
            String expath = "";
            //Cashier Report
            try
            {
                ReportDocument report = new ReportDocument();
                ExportFormatType efileType = new ExportFormatType();
                efileType = ExportFormatType.PortableDocFormat;

                try
                {
                    inc_pbar(10);
                    cashierReportBySendingSMS(dt_frm, dt_to);  // ahak ani
                }
                catch { MessageBox.Show("Sending Failed: Characters is out of range(160 max)."); }
                inc_pbar(10);

                //String dnow = DateTime.Now.ToString("yyyy-MM-dd");

                String outlet = "All";
                String WHERE = "";

                inc_pbar(10);

                //myReportDocument.Load("../..\\Reports/101B_cashier.rpt");
                myReportDocument.Load("\\\\RIGHTAPPS\\RightApps\\BALAI\\Auto_SendGenerate_Reports\\Reports\\101B_cashier.rpt");
                
                DataTable dt = db.QueryBySQLCode("SELECT o.ord_code, o.out_code, to_char(o.ord_date, 'MM/dd/yyyy') AS ord_date, o.customer, o.reference, CASE WHEN ol.pay_code='101' THEN (-1 * ol.ln_amnt) ELSE 0.00 END AS cash, CASE WHEN ol.pay_code='102' THEN (-1 * ol.ln_amnt) ELSE 0.00 END AS dcard, CASE WHEN ol.pay_code='103' THEN (-1 * ol.ln_amnt) ELSE 0.00 END AS card, CASE WHEN ol.pay_code='114' THEN (-1 * ol.ln_amnt) ELSE 0.00 END AS check, CASE WHEN ol.pay_code NOT IN('101','102','103','114') THEN (-1 * ol.ln_amnt) ELSE 0.00 END AS other FROM rssys.orhdr o LEFT JOIN rssys.orlne ol ON o.ord_code=ol.ord_code WHERE " + WHERE + " o.ord_date BETWEEN '" + dt_frm + "' AND '" + dt_to + "' AND COALESCE(ol.item_code,'')='' AND COALESCE(ol.ln_amnt,0.00)<0 ORDER BY ord_date");

                myReportDocument.Database.Tables[0].SetDataSource(dt);
                inc_pbar(10);

                add_fieldparam("comp_name", comp_name);
                add_fieldparam("comp_addr", comp_addr);
                add_fieldparam("userid", (GlobalClass.username ?? ""));
                add_fieldparam("t_date", (dt_frm == dt_to ? dt_to + " DAILY" : dt_frm +" - "+dt_to+" MONTHLY"));
                add_fieldparam("outlet", outlet);

                expath = "\\\\RIGHTAPPS\\RightApps\\BALAI\\101B_cashier_" + export_filename + ".pdf";
                myReportDocument.ExportToDisk(efileType, "\\\\RIGHTAPPS\\RightApps\\BALAI\\101B_cashier_" + export_filename + ".pdf");

                inc_pbar(10);


                sendEmail1("g");

            }
            catch (Exception er) { MessageBox.Show(er.Message + "\ngeneratedCashierReport_Error" +"\n"+expath); }

        }


        public void cashierReportBySendingSMS(String dt_frm, String dt_to)
        {

            String outlet = "All";
            String WHERE = "";

            DataTable dt = db.QueryBySQLCode("SELECT SUM(CASE WHEN ol.pay_code='101' AND COALESCE(ol.item_code,'')='' THEN (-1 * ol.ln_amnt) ELSE 0.00 END) AS cash, SUM(CASE WHEN ol.pay_code='102' AND COALESCE(ol.item_code,'')='' THEN (-1 * ol.ln_amnt) ELSE 0.00 END) AS dcard, SUM(CASE WHEN ol.pay_code='103' AND COALESCE(ol.item_code,'')='' THEN (-1 * ol.ln_amnt) ELSE 0.00 END) AS card, SUM(CASE WHEN ol.pay_code='114' AND COALESCE(ol.item_code,'')='' THEN (-1 * ol.ln_amnt) ELSE 0.00 END) AS check, SUM(CASE WHEN ol.pay_code NOT IN('101','102','103','114') THEN (-1 * ol.ln_amnt) ELSE 0.00 END) AS other, SUM(CASE WHEN COALESCE(ol.item_code,'')<>'' THEN ol.ln_amnt ELSE 0.00 END) AS sales, SUM(CASE WHEN COALESCE(ol.item_code,'')<>'' THEN ol.ln_tax ELSE 0.00 END) AS tax_amnt, SUM(CASE WHEN COALESCE(ol.item_code,'')<>'' THEN ol.disc_amt ELSE 0.00 END) AS disc_amnt FROM rssys.orhdr o LEFT JOIN rssys.orlne ol ON o.ord_code=ol.ord_code WHERE " + WHERE  + " (o.ord_date BETWEEN '" + dt_frm + "' AND '" + dt_to + "') ");

            if (dt != null)
            {   //keys : cash dcard card price other sales tax_amnt disc_amnt
                if (dt.Rows.Count == 1)
                {
                    String grand_cash = dt.Rows[0]["cash"].ToString();
                    String grand_debit_card = dt.Rows[0]["dcard"].ToString();
                    String grand_credit_card = dt.Rows[0]["cash"].ToString();
                    String grand_check = dt.Rows[0]["check"].ToString();
                    String grand_other = dt.Rows[0]["other"].ToString();
                    String grand_sales = dt.Rows[0]["sales"].ToString();
                    String grand_tax_amnt = dt.Rows[0]["tax_amnt"].ToString();
                    String grand_disc_amnt = dt.Rows[0]["disc_amnt"].ToString();

                    String message = "Good day! " + comp_name + " " + db.get_branchname(db.get_m99branch()) + " " + (dt_frm == dt_to ? "Daily" : "Monthly") + " Sales Report this day " + DateTime.Now.ToString("MM-dd-yyyy") + "\n *Cash = " + grand_cash + "\n *Credit Card = " + grand_credit_card + "\n *Check = " + grand_check + "\n *Other Charges = " + grand_other + "\n\n- This message is auto-generated by Right Apps System.\nThank you.";
                    
                    SMS sms = new SMS();
                    DataTable dt1 = new DataTable();
                    dt1 = db.QueryBySQLCode("SELECT * FROM rssys.auto_sms");
                    if(dt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++ )
                        {
                            g_number = dt1.Rows[i]["contact_no"].ToString();
                            sms.sendSingleSms(g_number, message);
                        }
                       
                    }
                   

                }
            }
            /*
             Good day! <m99.CompanyName> <BranchName> Daily Sales Report this day <date>
             Cash = 1,000,000,000.00
             Credit Card = 1,000,000,000.00
             Check = 1,000,000,000.00
             Other Charges = 1,000,000,000.00
             - This message is auto-generated by Right Apps System.
             Thank you.
             */
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            GSMModem.EmailBlasting ebm = new GSMModem.EmailBlasting();
            ebm.Show();

            date_today = DateTime.Today.ToString("MM-dd-yyyy");
            current_time = DateTime.Now.ToString("h:mm:ss tt");
            //txt_time.Text = time_genrt;
            txt_currenttime.Text = current_time;

            load_current_datetime();
            txt_dispnext.Text = db.get_m99time();
            nextTimeToGenerate();
        }



        private void load_current_datetime()
        {
            _interval.Stop();
            _interval.Tick += new EventHandler(delegate(object sender, EventArgs e)
            {
                DateTime now = DateTime.Now;
                current_time = now.ToString("hh:mm:ss tt");
                txt_currenttime.Text = current_time;
                if (!isBusy)
                {
                    isBusy = true;
                    { // if call back, well not called

                        String dnow = DateTime.Now.ToString("yyyy-MM-dd"); // for DAILY ONLY
                        DateTime setTimefrm = DateTime.Parse(dnow + " " + g_time);// start
                        DateTime setTimeto = setTimefrm.AddMinutes(5);// 5 in minute// 
                        try { setTimeto = dt_time.Value; }
                        catch { dt_time.Value = setTimeto; }

                        if (setTimefrm <= now && now <= setTimeto && isReset)
                        {
                            isReset = false;
                            generateReports(g_code);

                        }
                        else if (setTimeto < now)
                        {
                            isReset = true;
                        }
                    }isBusy = false;//
                }
            });
            _interval.Interval = 100;
            _interval.Start();
        }

        private void nextTimeToGenerate(){
            txt_dispnext.Invoke(new Action(() =>
            {
                DataTable dt = db.QueryBySQLCode("SELECT *, to_char(to_timestamp(schedtime,'hh:mi AM'),'hh:mi AM') as t_time FROM rssys.autoemail WHERE to_timestamp(schedtime,'hh:mi AM') > to_timestamp('" + DateTime.Now.ToString("hh:mm tt") + "','hh:mi AM') ORDER BY t_time ASC LIMIT 1");

                if (dt.Rows.Count >= 1)
                {

                    //g_time = dt.Rows[0]["t_time"].ToString();
                    //g_time = db.get_m99time();
                    g_date = dt.Rows[0]["scheddate"].ToString();
                    g_code = "";

                    txt_dispnext.Text = DateTime.Parse(g_time).ToString("hh:mm tt") + " / code#" + g_code;

                    dt_time.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + g_time).AddMinutes(5);
                    label6.Text = "Ready to generate...";
                }
                else
                {
                    label6.Text = "No records to be generated at this time, maybe tommorow.";
                }
            }));
        }



        private void frm_reset()
        {

        }

       

        private void clear_dgv()
        {
            try
            {
                dgv_list.Rows.Clear();
            }
            catch (Exception)
            { }
        }

        private void disp_list()
        {
            DataTable dt = db.QueryBySQLCode("SELECT * FROM rssys.auto_log");

            

            try
            {
                for (int r = 0; dt.Rows.Count > r; r++)
                {
                    int i = dgv_list.Rows.Add();
                    DataGridViewRow row = dgv_list.Rows[i];

                    row.Cells["dgv_email"].Value = dt.Rows[r]["identity"].ToString();
                    row.Cells["dgv_details"].Value = dt.Rows[r]["details"].ToString();
                   
                }
                nextTimeToGenerate();
            }
            catch (Exception) { }
        }

         

        

        

        //private void btn_delitem_Click(object sender, EventArgs e)
        //{
        //   // thisDatabase db = new thisDatabase();
        //    int r;

        //    if (dgv_list.Rows.Count > 1)
        //    {
        //        r = dgv_list.CurrentRow.Index;

        //        if (db.UpdateOnTable("brand", "cancel='Y'", "brd_code='" + dgv_list["ID", r].Value.ToString() + "'"))
        //        {
        //            disp_list();
        //            goto_tbcntrl_list();
        //            tpg_info_enable(false);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed on deleting.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No rows selected.");
        //    }
        //}

        private void btn_print_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently Disabled");

        }

        private void btn_search_Click(object sender, EventArgs e)
        {

        }

        

        
        private void tbcntrl_option_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (seltbp == false)
                e.Cancel = true;
        }

        private void tbcntrl_main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (seltbp == false)
                e.Cancel = true;
        }

        private void btn_delitem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently Disabled");
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_dispnext.Invoke(new Action(() =>
            {
                txt_dispnext.Text = db.get_m99time();
            }));
            txt_currenttime.Text = DateTime.Now.ToString("HH:mm:ss");
            String current = DateTime.Now.ToString("hh:mm tt");
            if (txt_dispnext.Text == current)
            {
                bgWorker.RunWorkerAsync();
            }
        }

        private void inc_pbar(int i)
        {
            pg_loading.Invoke(new Action(() =>
            {
                try
                {
                    pg_loading.Value += i;
                }
                catch (Exception) { reset_pbar(); }
            }));
        }
        private void reset_pbar()
        {
            pg_loading.Invoke(new Action(() =>
            {
                try { pg_loading.Value = 0; }
                catch { }
            }));
        }

        private void dgv_list_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.CellStyle.SelectionForeColor = Color.Brown;
            e.CellStyle.SelectionBackColor = Color.GreenYellow;

            if (e.RowIndex == -1)
            {
                SolidBrush br = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(br, e.CellBounds);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
            else
            {
                if (e.RowIndex % 2 == 0)
                {
                    SolidBrush br = new SolidBrush(Color.Gainsboro);

                    e.Graphics.FillRectangle(br, e.CellBounds);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }
                else
                {
                    SolidBrush br = new SolidBrush(Color.White);
                    e.Graphics.FillRectangle(br, e.CellBounds);
                    e.PaintContent(e.ClipBounds);
                    e.Handled = true;
                }
            }
        }

        private void txt_currenttime_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
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
