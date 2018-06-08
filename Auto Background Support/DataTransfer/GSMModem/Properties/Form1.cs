using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.Server;
using System.Globalization;

namespace GSMModem
{
    public partial class Form1 : Form
    {
        private GsmCommMain comm;
        private delegate void SetTextCallback(string text);
        private SmsServer smsServer;
        public Form1()
        {
            InitializeComponent();
        }
        TextBox txtMessage = new TextBox();
        TextBox txtDonorName = new TextBox();
        TextBox txtNumber = new TextBox();
        TextBox txtDonorId = new TextBox();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Operation code = new Operation();
            try
            {


                txtDonorId.Text = "0343";
                txtDonorName.Text = "Hello there";
                txtNumber.Text = "09226663075";
                Cursor.Current = Cursors.WaitCursor;
                txtMessage.Text = "Respected " + txtDonorName.Text + ", Welcome to Clapp Trust. Your donor ID is " + txtDonorId.Text + ". Our online system will send you SMS whenever your donation is received.";
                try
                {
                    SmsSubmitPdu pdu;
                    byte dcs = (byte)DataCodingScheme.GeneralCoding.Alpha7BitDefault;
                    pdu = new SmsSubmitPdu(txtMessage.Text, Convert.ToString(txtNumber.Text), dcs);
                    int times = 1;
                    for (int i = 0; i < times; i++)
                    {
                        comm.SendMessage(pdu);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Modem is not available");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception ex :" + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            cmbCOM.Items.Add("COM1");
            cmbCOM.Items.Add("COM2");
            cmbCOM.Items.Add("COM3");
            cmbCOM.Items.Add("COM4");
            cmbCOM.Items.Add("COM5");
            cmbCOM.Items.Add("COM6");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbCOM.Text == "")
            {
                MessageBox.Show("Invalid Port Name");
                return;
            }
            comm = new GsmCommMain(cmbCOM.Text , 9600, 150);
            Cursor.Current = Cursors.Default;
            bool retry;
            do
            {   retry = false;
                try
                {   Cursor.Current = Cursors.WaitCursor;
                    comm.Open();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Modem Connected Sucessfully");
                }
                catch (Exception)
                {   Cursor.Current = Cursors.Default;
                    if (MessageBox.Show(this, "GSM Modem is not available", "Check",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                        retry = true;
                    else
                   { return;}
               }
            }
            while (retry);

        }
            
        }
    }

