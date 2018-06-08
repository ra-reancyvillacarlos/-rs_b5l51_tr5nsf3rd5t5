namespace SmsBlaster
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_sms_no = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxt_msg = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cntChar1 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_cancelsend = new System.Windows.Forms.Button();
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.lbl_date_conn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_imei = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_port = new System.Windows.Forms.ComboBox();
            this.result_lbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.smsrow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.smsnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.smsname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.smsstatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_AsyncWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ntf_sms = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_status = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.portGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar.Location = new System.Drawing.Point(0, 350);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(615, 24);
            this.ProgressBar.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_sms_no);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 374);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 65;
            this.label4.Text = "SMS Number";
            // 
            // txt_sms_no
            // 
            this.txt_sms_no.Location = new System.Drawing.Point(106, 13);
            this.txt_sms_no.Name = "txt_sms_no";
            this.txt_sms_no.Size = new System.Drawing.Size(205, 20);
            this.txt_sms_no.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxt_msg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 282);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Body Message";
            // 
            // rtxt_msg
            // 
            this.rtxt_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_msg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_msg.Location = new System.Drawing.Point(3, 17);
            this.rtxt_msg.Name = "rtxt_msg";
            this.rtxt_msg.Size = new System.Drawing.Size(308, 262);
            this.rtxt_msg.TabIndex = 27;
            this.rtxt_msg.Text = "";
            this.rtxt_msg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msg_sendAll_KeyPress);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cntChar1);
            this.panel4.Controls.Add(this.btn_send);
            this.panel4.Controls.Add(this.btn_cancelsend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 53);
            this.panel4.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Character(s)";
            // 
            // cntChar1
            // 
            this.cntChar1.AutoSize = true;
            this.cntChar1.BackColor = System.Drawing.Color.Transparent;
            this.cntChar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntChar1.Location = new System.Drawing.Point(11, 6);
            this.cntChar1.Name = "cntChar1";
            this.cntChar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cntChar1.Size = new System.Drawing.Size(15, 16);
            this.cntChar1.TabIndex = 31;
            this.cntChar1.Text = "1";
            // 
            // btn_send
            // 
            this.btn_send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_send.Image = global::SmsBlaster.Properties.Resources.play;
            this.btn_send.Location = new System.Drawing.Point(220, 6);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(88, 41);
            this.btn_send.TabIndex = 24;
            this.btn_send.Text = "Send";
            this.btn_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_send.UseCompatibleTextRendering = true;
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_cancelsend
            // 
            this.btn_cancelsend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cancelsend.Image = global::SmsBlaster.Properties.Resources.media_pause;
            this.btn_cancelsend.Location = new System.Drawing.Point(129, 6);
            this.btn_cancelsend.Name = "btn_cancelsend";
            this.btn_cancelsend.Size = new System.Drawing.Size(88, 41);
            this.btn_cancelsend.TabIndex = 38;
            this.btn_cancelsend.Text = "Stop";
            this.btn_cancelsend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancelsend.UseCompatibleTextRendering = true;
            this.btn_cancelsend.UseVisualStyleBackColor = true;
            this.btn_cancelsend.Click += new System.EventHandler(this.Stop_Click);
            // 
            // portGroupBox
            // 
            this.portGroupBox.Controls.Add(this.lbl_date_conn);
            this.portGroupBox.Controls.Add(this.label1);
            this.portGroupBox.Controls.Add(this.txt_imei);
            this.portGroupBox.Controls.Add(this.label2);
            this.portGroupBox.Controls.Add(this.btn_refresh);
            this.portGroupBox.Controls.Add(this.btn_connect);
            this.portGroupBox.Controls.Add(this.label3);
            this.portGroupBox.Controls.Add(this.cbo_port);
            this.portGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.portGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portGroupBox.Location = new System.Drawing.Point(0, 24);
            this.portGroupBox.Name = "portGroupBox";
            this.portGroupBox.Size = new System.Drawing.Size(929, 61);
            this.portGroupBox.TabIndex = 37;
            this.portGroupBox.TabStop = false;
            this.portGroupBox.Text = "Port Config";
            // 
            // lbl_date_conn
            // 
            this.lbl_date_conn.AutoSize = true;
            this.lbl_date_conn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date_conn.Location = new System.Drawing.Point(773, 27);
            this.lbl_date_conn.Name = "lbl_date_conn";
            this.lbl_date_conn.Size = new System.Drawing.Size(0, 13);
            this.lbl_date_conn.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(685, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Connected On :";
            // 
            // txt_imei
            // 
            this.txt_imei.BackColor = System.Drawing.SystemColors.Info;
            this.txt_imei.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_imei.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_imei.Location = new System.Drawing.Point(479, 26);
            this.txt_imei.Name = "txt_imei";
            this.txt_imei.ReadOnly = true;
            this.txt_imei.Size = new System.Drawing.Size(200, 14);
            this.txt_imei.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "IMEI:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.AutoSize = true;
            this.btn_refresh.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_refresh.Location = new System.Drawing.Point(375, 19);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(60, 30);
            this.btn_refresh.TabIndex = 27;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.AutoSize = true;
            this.btn_connect.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_connect.Location = new System.Drawing.Point(168, 19);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(201, 30);
            this.btn_connect.TabIndex = 25;
            this.btn_connect.Text = "Connect and SMS Blast";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Port";
            // 
            // cbo_port
            // 
            this.cbo_port.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbo_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_port.FormattingEnabled = true;
            this.cbo_port.Location = new System.Drawing.Point(50, 24);
            this.cbo_port.Name = "cbo_port";
            this.cbo_port.Size = new System.Drawing.Size(109, 23);
            this.cbo_port.TabIndex = 24;
            // 
            // result_lbl
            // 
            this.result_lbl.AutoSize = true;
            this.result_lbl.BackColor = System.Drawing.Color.Transparent;
            this.result_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_lbl.Location = new System.Drawing.Point(154, 8);
            this.result_lbl.Name = "result_lbl";
            this.result_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.result_lbl.Size = new System.Drawing.Size(136, 16);
            this.result_lbl.TabIndex = 36;
            this.result_lbl.Text = "Success : 0  Failed : 0";
            this.result_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Status Result";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.smsrow,
            this.smsnumber,
            this.smsname,
            this.smsstatus});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(615, 321);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // smsrow
            // 
            this.smsrow.Text = "Row#";
            this.smsrow.Width = 50;
            // 
            // smsnumber
            // 
            this.smsnumber.Text = "Number";
            this.smsnumber.Width = 84;
            // 
            // smsname
            // 
            this.smsname.Text = "Name";
            this.smsname.Width = 347;
            // 
            // smsstatus
            // 
            this.smsstatus.Text = "Status";
            this.smsstatus.Width = 115;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMSToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inboxToolStripMenuItem,
            this.outboxToolStripMenuItem,
            this.sentItemsToolStripMenuItem,
            this.statusToolStripMenuItem});
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.sMSToolStripMenuItem.Text = "SMS";
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.inboxToolStripMenuItem.Text = "Inbox";
            // 
            // outboxToolStripMenuItem
            // 
            this.outboxToolStripMenuItem.Name = "outboxToolStripMenuItem";
            this.outboxToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.outboxToolStripMenuItem.Text = "Outbox";
            // 
            // sentItemsToolStripMenuItem
            // 
            this.sentItemsToolStripMenuItem.Name = "sentItemsToolStripMenuItem";
            this.sentItemsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.sentItemsToolStripMenuItem.Text = "Sent Items";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.statusToolStripMenuItem.Text = "SMS Status";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.ProgressBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(314, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 374);
            this.panel2.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.result_lbl);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 29);
            this.panel3.TabIndex = 0;
            // 
            // m_AsyncWorker
            // 
            this.m_AsyncWorker.WorkerReportsProgress = true;
            this.m_AsyncWorker.WorkerSupportsCancellation = true;
            this.m_AsyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAsync_DoWork);
            this.m_AsyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwAsync_ProgressChanged);
            this.m_AsyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAsync_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(929, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ntf_sms
            // 
            this.ntf_sms.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntf_sms.Icon = ((System.Drawing.Icon)(resources.GetObject("ntf_sms.Icon")));
            this.ntf_sms.Text = "Right Apps - SMS Blast";
            this.ntf_sms.Visible = true;
            this.ntf_sms.DoubleClick += new System.EventHandler(this.ntf_sms_DoubleClick);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(7, 464);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(41, 13);
            this.lbl_status.TabIndex = 39;
            this.lbl_status.Text = "Ready.";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(929, 481);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.portGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Right  Apps - SMS System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.portGroupBox.ResumeLayout(false);
            this.portGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label result_lbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader smsrow;
        private System.Windows.Forms.ColumnHeader smsnumber;
        private System.Windows.Forms.ColumnHeader smsname;
        private System.Windows.Forms.ColumnHeader smsstatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label cntChar1;
        private System.Windows.Forms.RichTextBox rtxt_msg;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_port;
        private System.Windows.Forms.Button btn_cancelsend;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lbl_date_conn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_imei;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sentItemsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_sms_no;
        private System.ComponentModel.BackgroundWorker m_AsyncWorker;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NotifyIcon ntf_sms;
        private System.Windows.Forms.Label lbl_status;


    }
}

