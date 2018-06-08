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
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.Server;
using System.Globalization;
using System.Threading;

namespace Auto_SentGenerate_Reports
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

        Boolean isNotCustom = true;
        Boolean isConnected = false;

        public SMS()
        {
            db = new thisDatabase();
            gm = new GlobalMethod();
            date = new DateTime();
            portOpen = false;
            InitializeComponent();
            //sendSingleSms("", "");
        }

        public void sendSingleSms(String _number, String _message)
        {
            int index = 0;
            Boolean enable = true;
            if (!isConnected)
            {
                isNotCustom = false;
                btn_refresh_Click(null, null);
                do
                {
                    try
                    {
                        cbo_port.SelectedIndex = index++;
                        btn_connect_Click(null, null);
                        if (btn_refresh.Enabled == false)
                        {
                            enable = false;
                            isConnected = true;
                        }
                    }
                    catch
                    {
                        enable = false;
                    }

                } while (enable);
            }

            if (isConnected)
            {
                send_message(_number, _message);
            }

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
                if (!comm.IsOpen())
                {
                    try
                    {
                        sendBgWorker.CancelAsync();
                    }
                    catch (Exception ex)
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
                if (isNotCustom)
                {
                    MessageBox.Show("No port selected \n" + "Message : " + ex.Message);
                }
                close = false;
            }
            return close;
        }


        public Boolean send_message(string number, string message)
        {
            Boolean ok = false;
            try
            {
                if (message.Length >= 145)
                {
                    send_message(number, message.Substring(145) + "..");
                    message = message.Substring(0, 145);
                }
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
                        if (isNotCustom)
                        {
                            MessageBox.Show("Modem Connected Sucessfully");
                        }

                        cbo_port.Enabled = false;
                        // btn_connect_dis.Text = "Disconnect";
                        portOpen = true;
                        if (comm.IsOpen())
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
                        if (isNotCustom)
                        {
                            if (MessageBox.Show(this, "GSM Modem is not available", "Check",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                                retry = true;
                            else
                            { return; }
                        }
                    }
                }
                while (retry);
            }
            else
            {
                if (closePort())
                {
                    portOpen = false;

                    cbo_port.Invoke(new Action(() =>
                    {
                        cbo_port.Enabled = true;    
                    }));
                    if (isNotCustom)
                    {
                        MessageBox.Show("Port closed.");
                    }
                }
            }
        }

        private void sendBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (isNotCustom)
            {
                initiate_sending();
            }
        }
        public void send_text_blast(String tbid)
        {
            String query = "";
            DataTable contacts = null;
            DataTable address_book = null;
            String number = "", message = "";
            int min_delay = 0;
            int day_delay = 0;
            String d_name = "", d_code = ""; ;


            Thread.Sleep(4000);
            try
            {
                // query = "SELECT d_cntc FROM rssys.tb_recip WHERE tbid='" + date_to_send.Rows[r]["tbid"].ToString() + "'";

                query = "select * from rssys.tb_recip r LEFT JOIN rssys.tb_hdr h ON r.tbid=h.tbid LEFT JOIN rssys.tb_category c on c.tb_cat_id=h.tbtemp_id WHERE r.send_stat = 'N' AND h.tbid ='" + tbid + "'";
                contacts = db.QueryBySQLCode(query);
                if (contacts.Rows.Count >= 0)
                {
                    for (int c = 0; c < contacts.Rows.Count; c++)
                    {
                        tbid = contacts.Rows[c]["tbid"].ToString();
                        number = contacts.Rows[c]["mobile1"].ToString();
                        //message = date_to_send.Rows[r]["message"].ToString();
                        message = contacts.Rows[c]["message"].ToString();
                        if (contacts.Rows[c]["cat_time_delay"].ToString() != "")
                            min_delay = Convert.ToInt32(contacts.Rows[c]["cat_time_delay"].ToString());
                        if (contacts.Rows[c]["cat_day_delay"].ToString() != "")
                            day_delay = Convert.ToInt32(contacts.Rows[c]["cat_day_delay"].ToString());
                        d_code = contacts.Rows[c]["d_code"].ToString();
                        address_book = db.QueryBySQLCode("SELECT firstname,lastname,mname  FROM rssys.address_book WHERE code='" + d_code + "'");
                        if (address_book.Rows.Count > 0)
                        {
                            d_name = address_book.Rows[0]["firstname"].ToString() + " " + address_book.Rows[0]["mname"].ToString() + " " + address_book.Rows[0]["lastname"].ToString();
                            message = "Dear " + d_name + " : " + message;
                        }

                        Thread.Sleep(min_delay * 60000);

                        if (send_message(number, message))
                        {
                            if (db.UpdateOnTable("tb_recip", "send_stat='Y'", "tbid='" + tbid + "' AND d_code='" + d_code + "'"))
                            {
                                lbl_status.Invoke(new Action(() =>
                                {
                                    lbl_status.Text = "Sending messages";
                                }));
                            }

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
