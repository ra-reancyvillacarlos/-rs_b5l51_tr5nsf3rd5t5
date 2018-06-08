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
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.Server;
using System.Globalization;
using System.Threading;
namespace GSMModem
{
    public partial class SMS : Form
    {
        private GsmCommMain comm;
        private bool portOpen;
        private SmsServer smsServer;
        private DataTable date_to_send;
        private DataTable recipients;
     
        private DateTime date;
        thisDatabase db;
        GlobalMethod gm;
        public SMS()
        {
            db = new thisDatabase();
            gm = new GlobalMethod();
            date = new DateTime();
            portOpen = false;
            InitializeComponent();
           
        }

       

    
        private void SMS_Load(object sender, EventArgs e)
        {
         
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cbo_port.Items.Add(p);
            }
        }
     
        public Boolean closePort()
        {
            bool close = false;
            try
            {
                comm.Close();
                if(! comm.IsOpen())
                {
                    try
                    {
                        sendBgWorker.CancelAsync();
                    } catch(Exception ex)
                    {

                    }

                    close = true;
                    portOpen = false;
                    btn_connect.Text = "Connect";
                    btn_connect.BackColor = Color.DodgerBlue;
                    btn_refresh.Enabled = true;
                    cbo_port.SelectedIndex = -1;
                    cbo_port.Enabled = true;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("No port selected \n" + "Message : " + ex.Message);
                close = false;
            }
            return close;
        }
      
     
        public Boolean send_message(string number, string message)
        {
            Boolean ok = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    SmsSubmitPdu pdu;
                    byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                    pdu = new SmsSubmitPdu(message, Convert.ToString(number), dcs);
                   
                    Thread.Sleep(3000);
                    comm.SendMessage(pdu);
                    ok = true;
                }
                catch (Exception ex)
                {
                    lbl_status.Invoke(new Action(() =>
                    {
                        lbl_status.Text = "Func :send_message [2nd level]" + ex.Message;
                    }));
                }
            }
            catch (Exception ex)
            {
                lbl_status.Invoke(new Action(() =>
                {
                    lbl_status.Text = "Func :send_message [1st level]" + ex.Message;
                }));
            }
            return ok;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            cbo_port.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                cbo_port.Items.Add(p);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string pname = "";
            if (cbo_port.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a port");
                return;
            }
            if (!portOpen)
            {
                pname = cbo_port.Text;
                comm = new GsmCommMain(pname, 9600, 150);
                Cursor.Current = Cursors.Default;
                bool retry;
                do
                {
                    retry = false;
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        comm.Open();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Modem Connected Sucessfully");
                        cbo_port.Enabled = false;
                        // btn_connect_dis.Text = "Disconnect";
                        portOpen = true;
                        if(comm.IsOpen())
                        {
                            btn_connect.BackColor = Color.Red;
                            btn_connect.ForeColor = Color.White;
                            btn_connect.Text = "Disconnect";
                            btn_refresh.Enabled = false;
                            sendBgWorker.RunWorkerAsync();
                        }
                       
                    }
                    catch (Exception)
                    {
                        Cursor.Current = Cursors.Default;
                        if (MessageBox.Show(this, "GSM Modem is not available", "Check",
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                            retry = true;
                        else
                        { return; }
                    }
                }
                while (retry);
            }
            else
            {
                if (closePort())
                {
                    portOpen = false;
                    cbo_port.Enabled = true;
                    MessageBox.Show("Port closed.");
                }
            }
        }

        private void sendBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            initiate_sending();
        }
        public void send_text_blast(String tbid)
        {
            String query = "";
            DataTable contacts = null;
            DataTable m06_code = null;
            String number = "", message = "";
            int min_delay = 0;
            int day_delay = 0;
            String d_name = "", d_code = ""; ;
           
          
            Thread.Sleep(4000);
            try
            {
                // query = "SELECT d_cntc FROM rssys.tb_recip WHERE tbid='" + date_to_send.Rows[r]["tbid"].ToString() + "'";

                query = "select * from rssys.tb_recip r LEFT JOIN rssys.tb_hdr h ON r.tbid=h.tbid LEFT JOIN rssys.tb_category c on c.tb_cat_id=h.tbtemp_id WHERE h.tbid ='" + tbid + "'";
                contacts = db.QueryBySQLCode(query);
                if (contacts.Rows.Count >= 0)
                {
                    for (int c = 0; c < contacts.Rows.Count; c++)
                    {
                        number = contacts.Rows[c]["d_cntc"].ToString();
                        //message = date_to_send.Rows[r]["message"].ToString();
                        message = contacts.Rows[c]["message"].ToString();
                        if (contacts.Rows[c]["cat_time_delay"].ToString() != "")
                            min_delay = Convert.ToInt32(contacts.Rows[c]["cat_time_delay"].ToString());
                        if (contacts.Rows[c]["cat_day_delay"].ToString() != "")
                            day_delay = Convert.ToInt32(contacts.Rows[c]["cat_day_delay"].ToString());
                        d_code = contacts.Rows[c]["d_code"].ToString();
                        m06_code = db.QueryBySQLCode("SELECT d_name FROM rssys.m06 WHERE d_code='" + d_code + "'");
                        if(m06_code.Rows.Count >0)
                        {
                            d_name = m06_code.Rows[0]["d_name"].ToString();
                            message = "Dear " + d_name + " : " + message;
                        }
                        Thread.Sleep(min_delay * 60000);
                   
                        if (send_message(number, message))
                        {
                            lbl_status.Invoke(new Action(() =>
                            {
                                lbl_status.Text = "Sending messages";
                            }));
                        }
                        else
                        {
                            lbl_status.Invoke(new Action(() =>
                            {
                                lbl_status.Text = "Func :send_text_blast => Message not sent"; 
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_status.Invoke(new Action(() =>
                {
                    lbl_status.Text = "Func :send_text_blast => " + ex.Message;
                }));
            }
            
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
                    query = "SELECT tbid FROM rssys.tb_hdr WHERE send_date = '" + send_date + "' ORDER BY send_date DESC";
                    date_to_send = db.QueryBySQLCode(query);
                    if (date_to_send.Rows.Count > 0)
                    {
                        for (int i = 0; i < date_to_send.Rows.Count; i++)
                        {
                            send_text_blast(date_to_send.Rows[i]["tbid"].ToString());
                        }
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                }
                catch (Exception ex)
                {

                }
            } while (true);


        }
    }
}
