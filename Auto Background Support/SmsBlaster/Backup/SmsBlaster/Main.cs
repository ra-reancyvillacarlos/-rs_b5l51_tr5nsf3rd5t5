using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;


namespace SmsBlaster
{
    public partial class Main : Form
    {
        private int cntROW = 0;
        private bool isPause = false;
        private bool isStop = false;
        private bool isSingleMsg = false;
        private String IMEInumber = "353143039398459"; //861737006416809

        private BackgroundWorker m_AsyncWorker = new BackgroundWorker();
        private String message_for_all = "";
        delegate void SetListViewItemCallBack(ListViewItem Item);

        public Main()
        {
            InitializeComponent();

            // Create a background worker thread that ReportsProgress & SupportsCancellation
            // Hook up the appropriate events.
            m_AsyncWorker.WorkerReportsProgress = true;
            m_AsyncWorker.WorkerSupportsCancellation = true;
            m_AsyncWorker.ProgressChanged += new ProgressChangedEventHandler(bwAsync_ProgressChanged);
            m_AsyncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwAsync_RunWorkerCompleted);
            m_AsyncWorker.DoWork += new DoWorkEventHandler(bwAsync_DoWork);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            //ProgressBar.Hide();
            foreach (string port in ports)
            {
                portBox.Items.Add(port);
            }
            //SendAll.Enabled = false;
            //Stop.Enabled = false;
            //Send.Enabled = false;

            //msg_sendAll.Enabled = false;
            //Browse.Enabled = false;
            //smsnumber2.Enabled = false;
            //msg2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //message_for_all = msg_sendAll.Text;

            //StatusLabel.Text = "Sending...";
            
            //SendAll.Enabled = false;
            //Stop.Enabled = true;
            //msg_sendAll.ReadOnly = true;
            //Send.Enabled = false;

            //listView1.Items.Clear();
            
            //result_lbl.Text = "Sent : 0  Failed : 0";

            //m_AsyncWorker.RunWorkerAsync();
        }

        private Boolean sendMessage(String smsnumber, String msg)
        {
            //String result = "";
            //cntROW++;
            Boolean flag = false;
            //if (isSingleMsg)
            //{
            //    msg = msg2.Text;
            //    isSingleMsg = false;
            //}

            //try
            //{                
            //    serialPort1.Write("AT+CMGF=1\r");
                
            //    Thread.Sleep(1000);
                
            //    result = serialPort1.ReadExisting();

            //    serialPort1.Write("AT+CMGS="); serialPort1.Write(new byte[] { 34, 0xE2, 0xFF }, 0, 1);
            //    serialPort1.Write(smsnumber); serialPort1.Write(new byte[] { 34, 0xE2, 0xFF }, 0, 1);
            //    serialPort1.Write(new byte[] { 13, 0xE2, 0xFF }, 0, 1);

            //    Thread.Sleep(1000);
                
            //    result = serialPort1.ReadExisting();

            //    serialPort1.Write(msg);

            //    serialPort1.Write(new byte[] { 26, 0xE2, 0xFF }, 0, 1);
                
            //    Thread.Sleep(2000);
                
            //    result = serialPort1.ReadExisting();
                
            //    if (!result.Contains("ERROR") && result.Contains("OK") && result.Trim().Length != 0)
            //    {
            //        flag = true;
            //    }
            //}
            //catch (Exception)
            //{
            //    flag = false;
            //}

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

        private void Browse_Click(object sender, EventArgs e)
        {
            
        }

        private void Send_Click(object sender, EventArgs e)
        {
            //String str = smsnumber2.Text;
            //String msg = msg2.Text;
            //ProgressBar.Minimum = 1;
            //ProgressBar.Maximum = 100;
            //ProgressBar.Step = 50;
            //ProgressBar.PerformStep();
            //isSingleMsg = true;

            //if (sendMessage(str, msg))
            //{
            //    ProgressBar.Step = 50;
            //    ProgressBar.PerformStep();
            //    StatusLabel.Text = "Message sent successfully.";
            //    MessageBox.Show("Message sent successfully.");
            //}
            //else
            //{

            //    ProgressBar.Step = 50;
            //    ProgressBar.PerformStep();
            //    StatusLabel.Text = "Message failed to send.";
            //    MessageBox.Show("Message failed to send.");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String pName = "";
            //String localIMEInumber = "";
            //try
            //{
            //    if (String.IsNullOrEmpty(portBox.Text))
            //    {
            //        MessageBox.Show("Pls select a Com Port.");
            //    }
            //    else
            //    {
            //        pName = portBox.Text;

            //        if (btnConnect.Text == "Connect")
            //        {
            //            serialPort1.PortName = pName;
            //            serialPort1.Open();
                        
            //            serialPort1.Write("AT+CMGF=1\r");
            //            Thread.Sleep(1000);

            //            serialPort1.Write("AT+CGSN\r");
            //            Thread.Sleep(1000);

            //            localIMEInumber = serialPort1.ReadExisting();
                        
            //            if (localIMEInumber.Contains("Error"))
            //            {
            //                try
            //                {
            //                    serialPort1.Close();
            //                    MessageBox.Show("Invalid Port. Pls try another port.");
            //                    StatusLabel.Text = "Port Not Connected.";
            //                }
            //                catch (Exception)
            //                {

            //                }
            //            }
            //            else if (localIMEInumber.Contains(IMEInumber))
            //            {
            //                portBox.Enabled = false;
            //                btnConnect.Text = "Disconnect";

            //                Browse.Enabled = true;
            //                Send.Enabled = true;
            //                msg_sendAll.Enabled = true;
            //                smsnumber2.Enabled = true;
            //                msg2.Enabled = true;
            //                StatusLabel.Text = "Port connected successfully.";
            //            }
            //            else
            //            {
            //                try
            //                {
            //                    serialPort1.Close();
            //                    MessageBox.Show("Device/Port cannot be recognized. Pls try another port.");
            //                    StatusLabel.Text = "Port Not Connected.";
            //                }
            //                catch (Exception)
            //                {

            //                }
            //            }     
            //        }
            //        else if (btnConnect.Text == "Disconnect")
            //        {
            //            serialPort1.Close();
            //            portBox.Enabled = true;
            //            btnConnect.Text = "Connect";
            //            Browse.Enabled = false;
            //            Send.Enabled = false;

            //            msg_sendAll.Enabled = false;

            //            smsnumber2.Enabled = false;
            //            msg2.Enabled = false;
            //            StatusLabel.Text = "Port disconnected.";
            //        }
            //    }
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show(er.Message);
            //}
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (isPause == false)
            {
                isPause = true;
            }
            else
            {
                isPause = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Worksheets|*.xlsx";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) 
            {
                string file = openFileDialog1.FileName;

                try
                {
                    txtBrowse.Text = openFileDialog1.FileName;

                    if (txtBrowse.Text != null)
                    {
                        SendAll.Enabled = true;
                    }
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
            }
        }

        private void msg_sendAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            int lenght = msg_sendAll.Text.Length;

            if (lenght == 0)
                lenght = 1;
            else
                lenght += 1;            

            cntChar1.Text = "" + lenght;

            
        }

        private void msg2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int lenght = msg2.Text.Length;

            //if (lenght == 0)
            //    lenght = 1;
            //else
            //    lenght += 1;

            //cntChar2.Text = "" + lenght;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch(Exception)
            {

            }
        }

        private void bwAsync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void bwAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //SendAll.Enabled = true;
            //Stop.Enabled = true;
            //Send.Enabled = true;
            
            //if (e.Error != null)
            //{
            //    MessageBox.Show(e.Error.Message);
            //    return;
            //}

            //if (e.Cancelled)
            //{
            //    StatusLabel.Text = "Cancelled...";
            //}
            //else
            //{
            //    if (btnConnect.Text == "Connect")
            //    {
            //        StatusLabel.Text = "Unable to Send. Port disconnected.";
            //    }
            //    else
            //    {
            //        StatusLabel.Text = "Completed...";
            //    }
            //}
        }

        private void bwAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwAsync = sender as BackgroundWorker;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string number, lname;
            string fileLocation = txtBrowse.Text;
            string msg = message_for_all;
            int rCnt = 0;
            int cCnt = 0;
            int fail = 0;
            int success = 0;
            
            xlApp = new Excel.ApplicationClass();

            xlWorkBook = xlApp.Workbooks.Open(fileLocation, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           
            try
            {
                range = xlWorkSheet.UsedRange;
                cCnt = 1;
                
                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    number = "0" + (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
                    lname = (string)(range.Cells[rCnt, cCnt + 1] as Excel.Range).Value2;
                    
                    ListViewItem lvi = new ListViewItem(rCnt-1 + "");
                    lvi.SubItems.Add(number);
                    lvi.SubItems.Add(lname);
                    
                    if (sendMessage(number, msg))
                    {
                        lvi.SubItems.Add("Success");
                        success++;
                        result_lbl.Invoke(new Action(() =>
                        {
                            result_lbl.Text = "Sent : " + success + "  Failed : " + fail;
                        }
                        ));

                     }
                     else
                     {
                         fail++;

                         (range.Cells[rCnt, cCnt + 3] as Excel.Range).set_Item(1, 0, "Failed");

                         lvi.SubItems.Add("Fail");

                         result_lbl.Invoke(new Action(() =>
                         {
                             result_lbl.Text = "Sent : " + success + "  Failed : " + fail;
                         }
                         ));
                      }

                      AddListViewItem(lvi);

                      Thread.Sleep(100);

                      bwAsync.ReportProgress(Convert.ToInt32((rCnt - 1) * (100.0 / range.Rows.Count)));
                     
                    if (bwAsync.CancellationPending)
                    {
                        Thread.Sleep(1200);
                        e.Cancel = true;
                        return;
                     }
                }
                                    
                try{ xlWorkBook.Close(true, fileLocation.Remove(fileLocation.Length - 5) + "-failed.xlsx", null); }
                catch (Exception){}

                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception er)
            {
                try
                {
                    xlWorkBook.Close(true, null, null); 
                    
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception) { }

                MessageBox.Show(er.Message);
            }

            cntROW = 0;
                           
            bwAsync.ReportProgress(100);

            result_lbl.Invoke(new Action(() =>
            {
                result_lbl.Text = "Sent : " + success + "  Failed : " + fail;
            }
            ));
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
                SendAll.Enabled = false;
                //Stop.Enabled = false;
                StatusLabel.Text = "Canceling...";

                m_AsyncWorker.CancelAsync();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Browse_Click_1(object sender, EventArgs e)
        {

        }

        private void SendAll_Click(object sender, EventArgs e)
        {

        }
    }
}