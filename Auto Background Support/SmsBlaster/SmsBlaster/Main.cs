using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Globalization;
using System.Threading;

//using Excel = Microsoft.Office.Interop.Excel;


namespace SmsBlaster
{
    public partial class Main : Form
    {
        thisDatabase db;
        GlobalMethod gm;
        private DataTable date_to_send;
        private int cntROW = 0, rCnt = 1;
        private bool isPause = false;
        private bool isStop = false;
        private bool isSingleMsg = false;
        int fail = 0;
        int success = 0;
        private String IMEInumber = "353143039398459"; //861737006416809
        private String message_for_all = "";
        delegate void SetListViewItemCallBack(ListViewItem Item);

        public Main()
        {
            InitializeComponent();

            db = new thisDatabase();
            gm = new GlobalMethod();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            //ProgressBar.Hide();
            foreach (string port in ports)
            {
                cbo_port.Items.Add(port);
            }
            btn_send.Enabled = false;
            btn_cancelsend.Enabled = false;
            rtxt_msg.Enabled = false;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try{ serialPort1.Close(); }
            catch (Exception){ }
        }

        private Boolean sendMessage(String smsnumber, String msg)
        {
            String result = "";
            Boolean flag = false;
            cntROW++;

            try
            {
                if (isSingleMsg)
                {
                    msg = rtxt_msg.Text;
                    isSingleMsg = false;
                }

                serialPort1.Write("AT+CMGF=1\r");

                Thread.Sleep(1000);

                result = serialPort1.ReadExisting();

                serialPort1.Write("AT+CMGS="); serialPort1.Write(new byte[] { 34, 0xE2, 0xFF }, 0, 1);
                serialPort1.Write(smsnumber); serialPort1.Write(new byte[] { 34, 0xE2, 0xFF }, 0, 1);
                serialPort1.Write(new byte[] { 13, 0xE2, 0xFF }, 0, 1);

                Thread.Sleep(1000);

                result = serialPort1.ReadExisting();

                serialPort1.Write(msg);

                serialPort1.Write(new byte[] { 26, 0xE2, 0xFF }, 0, 1);

                Thread.Sleep(2000);

                result = serialPort1.ReadExisting();
                
                if (!result.Contains("ERROR") || result.Trim().Length != 0)
                {
                    flag = true;
                }
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void msg_sendAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            int lenght = rtxt_msg.Text.Length;

            if (lenght == 0)
                lenght = 1;
            else
                lenght += 1;            

            cntChar1.Text = "" + lenght;
        }
        
        private void bwAsync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void bwAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            if (e.Cancelled)
            {
                //lbl_status.Text = "Cancelled...";
                lbl_status.Invoke(new Action(() => { lbl_status.Text = "Cancelled."; }));
            }
            else
            {
                if (btn_connect.Text == "Connect and SMS Blast")
                {
                    //lbl_status.Text = "Unable to Send. Port disconnected.";
                    lbl_status.Invoke(new Action(() => { lbl_status.Text = "Unable to Send. Port disconnected."; }));
                }
                else
                {
                    //lbl_status.Text = "Completed...";
                    lbl_status.Invoke(new Action(() => { lbl_status.Text = "Completed."; }));
                }
            }
        }

        private void bwAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwAsync = sender as BackgroundWorker;
            
            string number = "", lname = "";
            string msg = message_for_all, send_date = "", send_time = "";
            
            int cCnt = 0;

            do
            {
                try
                {

                    cCnt = 1;
                    send_date = db.get_systemdate("yyyy-MM-dd");//gm.toDateString(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd");
                    send_time = db.get_systemtime();
                    date_to_send = db.QueryBySQLCode("SELECT h.* FROM rssys.tb_hdr h LEFT JOIN rssys.tb_recip r ON h.tbid=r.tbid WHERE send_date <= '"+send_date+"' AND send_time <= '"+send_time+"' AND r.send_stat='N' ORDER BY send_date DESC, send_time DESC");

                    for (int i = 0; i < date_to_send.Rows.Count; i++)
                    {
                        send_text_blast(date_to_send.Rows[i]["tbid"].ToString(), e);

                        Thread.Sleep(100);

                        if (m_AsyncWorker.CancellationPending)
                        {
                            Thread.Sleep(1200);
                            e.Cancel = true;
                            return;
                        }
                    }

                }
                catch { }
            }
            while (true);

            cntROW = 0;
                           
            bwAsync.ReportProgress(100);

            result_lbl.Invoke(new Action(() =>
            {
                result_lbl.Text = "Sent : " + success + "  Failed : " + fail;
            }
            ));
        }

        private void send_text_blast(String tbid, DoWorkEventArgs e)
        {
            String query = "";
            DataTable contacts = null;
            DataTable dt_m06 = null;
            String number = "", message = "";
            int min_delay = 0;
            int day_delay = 0;
            String d_name = "", d_code = "", lname="";

            try
            {
                contacts = db.QueryBySQLCode("SELECT r.tbid, h.message, r.d_code, r.d_cntc AS mobile1, m6.d_name, c.* FROM rssys.tb_recip r LEFT JOIN rssys.tb_hdr h ON r.tbid=h.tbid LEFT JOIN rssys.tb_category c ON c.tb_cat_id=h.tbtemp_id LEFT  JOIN rssys.m06 m6 ON m6.d_code=r.d_code WHERE r.send_stat = 'N' AND h.tbid ='" + tbid + "'");

                if (contacts.Rows.Count >= 0)
                {
                    for (int c = 0; c < contacts.Rows.Count; c++)
                    {
                        tbid = contacts.Rows[c]["tbid"].ToString();
                        number = contacts.Rows[c]["mobile1"].ToString();
                        lname = contacts.Rows[c]["d_name"].ToString();
                        message = contacts.Rows[c]["message"].ToString();

                        if (String.IsNullOrEmpty(number) == false)
                        {
                            ListViewItem lvi = new ListViewItem((rCnt++).ToString());
                            lvi.SubItems.Add(number);
                            lvi.SubItems.Add(lname);
                            
                            if (contacts.Rows[c]["cat_time_delay"].ToString() != "")
                                min_delay = Convert.ToInt32(contacts.Rows[c]["cat_time_delay"].ToString());

                            if (contacts.Rows[c]["cat_day_delay"].ToString() != "")
                                day_delay = Convert.ToInt32(contacts.Rows[c]["cat_day_delay"].ToString());

                            d_code = contacts.Rows[c]["d_code"].ToString();

                            Thread.Sleep(min_delay * 50000);

                            if (sendMessage(number, message))
                            {
                                if (db.UpdateOnTable("tb_recip", "send_stat='Y'", "tbid='" + tbid + "' AND d_code='" + d_code + "'"))
                                {
                                    lvi.SubItems.Add("Success");
                                    success++;
                                    result_lbl.Invoke(new Action(() => { result_lbl.Text = "Sent : " + success + "  Failed : " + fail; }));
                                    lbl_status.Invoke(new Action(() => { lbl_status.Text = "Sending messages"; }));
                                }
                            }
                            else
                            {
                                fail++;
                                lvi.SubItems.Add("Fail");
                                result_lbl.Invoke(new Action(() => { result_lbl.Text = "Sent : " + success + "  Failed : " + fail; }));

                                //lbl_status.Text = "Message not sent";
                                lbl_status.Invoke(new Action(() => { lbl_status.Text = "Send_text_blast => Message not sent";  }));
                            }
                            
                            AddListViewItem(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result_lbl.Invoke(new Action(() => { result_lbl.Text = "Sent : " + success + "  Failed : " + fail; }   ));
                //lbl_status.Text = ex.Message;
                lbl_status.Invoke(new Action(() => { lbl_status.Text = ex.Message;   }));
            }
        }
        
        private void AddListViewItem(ListViewItem Item)
        {
            if (this.listView1.InvokeRequired)
            {
                SetListViewItemCallBack d = new SetListViewItemCallBack(AddListViewItem);

                this.Invoke(d, new object[] { Item });
            }
            else
            {
                this.listView1.Items.Add(Item);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            
            if (m_AsyncWorker.IsBusy)
            {
                btn_send.Enabled = false;
                //Stop.Enabled = false;
                //lbl_status.Text = "Canceling...";
                lbl_status.Invoke(new Action(() => { lbl_status.Text = "Cancelling..."; }));

                m_AsyncWorker.CancelAsync();
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            
            foreach (string port in ports)
            {
                cbo_port.Items.Add(port);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            String pName = "";
            String localIMEInumber = "";
            try
            {
                if (String.IsNullOrEmpty(cbo_port.Text))
                {
                    MessageBox.Show("Pls select a Com Port.");
                }
                else
                {
                    pName = cbo_port.Text;
                    txt_imei.Text = "";
                    lbl_date_conn.Text = "";

                    if (btn_connect.Text == "Connect and SMS Blast")
                    {
                        serialPort1.PortName = pName;
                        serialPort1.Open();

                        serialPort1.Write("AT+CMGF=1\r");
                        Thread.Sleep(1000);

                        serialPort1.Write("AT+CGSN\r");
                        Thread.Sleep(1000);

                        localIMEInumber = serialPort1.ReadExisting();


                        if (localIMEInumber.Contains("Error") || String.IsNullOrEmpty(localIMEInumber))
                        {
                            try
                            {
                                serialPort1.Close();
                                MessageBox.Show("Invalid Port. Pls try another port.");
                                lbl_status.Text = "Port Not Connected.";
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else// if (localIMEInumber.Contains(IMEInumber))
                        {
                            txt_imei.Text = localIMEInumber;
                            lbl_date_conn.Text = DateTime.Now.ToString();
                            cbo_port.Enabled = false;
                            btn_connect.Text = "Disconnect and Stop SMS Blast";

                            btn_send.Enabled = true;
                            btn_cancelsend.Enabled = true;
                            rtxt_msg.Enabled = true;
                            lbl_status.Text = "Port connected successfully.";

                            start_sending();
                        }
                    }
                    else if (btn_connect.Text == "Disconnect and Stop SMS Blast")
                    {
                        serialPort1.Close();
                        cbo_port.Enabled = true;
                        btn_connect.Text = "Connect and SMS Blast";
                        btn_send.Enabled = false;

                        rtxt_msg.Enabled = false;

                        //smsnumber2.Enabled = false;
                        // msg2.Enabled = false;
                        lbl_status.Text = "Port disconnected.";
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            message_for_all = rtxt_msg.Text;
            start_sending();            
        }

        private void start_sending()
        {
            lbl_status.Text = "Sending...";

            btn_send.Enabled = false;
            btn_cancelsend.Enabled = false;
            rtxt_msg.ReadOnly = true;

            //listView1.Items.Clear();

            result_lbl.Text = "Sent : 0  Failed : 0";

            m_AsyncWorker.RunWorkerAsync();
            btn_send.Enabled = true;
            btn_cancelsend.Enabled = true;
            rtxt_msg.ReadOnly = false;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ntf_sms.Visible = true;
                //ntf_sms.ShowBalloonTip(500);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                ntf_sms.Visible = false;
            }
        }

        private void ntf_sms_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}