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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.portGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.ComboBox();
            this.result_lbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.smsrow = new System.Windows.Forms.ColumnHeader();
            this.smsnumber = new System.Windows.Forms.ColumnHeader();
            this.smsname = new System.Windows.Forms.ColumnHeader();
            this.smsstatus = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.cntChar1 = new System.Windows.Forms.Label();
            this.Browse = new System.Windows.Forms.PictureBox();
            this.msg_sendAll = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SendAll = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.portGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Browse)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 17);
            this.StatusLabel.Text = "Ready";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(349, 300);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(304, 24);
            this.ProgressBar.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(195, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(279, 31);
            this.label11.TabIndex = 21;
            this.label11.Text = "AMHM MARKETING";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(237, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 29);
            this.label12.TabIndex = 22;
            this.label12.Text = "SMS BLASTING";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.portGroupBox);
            this.panel1.Controls.Add(this.result_lbl);
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cntChar1);
            this.panel1.Controls.Add(this.Browse);
            this.panel1.Controls.Add(this.msg_sendAll);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtBrowse);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SendAll);
            this.panel1.Location = new System.Drawing.Point(-2, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 361);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Image = global::SmsBlaster.Properties.Resources.play;
            this.button2.Location = new System.Drawing.Point(137, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 55);
            this.button2.TabIndex = 38;
            this.button2.Text = "Cancel";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // portGroupBox
            // 
            this.portGroupBox.Controls.Add(this.button1);
            this.portGroupBox.Controls.Add(this.btnConnect);
            this.portGroupBox.Controls.Add(this.label3);
            this.portGroupBox.Controls.Add(this.portBox);
            this.portGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portGroupBox.Location = new System.Drawing.Point(351, 8);
            this.portGroupBox.Name = "portGroupBox";
            this.portGroupBox.Size = new System.Drawing.Size(303, 91);
            this.portGroupBox.TabIndex = 37;
            this.portGroupBox.TabStop = false;
            this.portGroupBox.Text = "Port Config";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(198, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 27;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnect.Location = new System.Drawing.Point(198, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 30);
            this.btnConnect.TabIndex = 25;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Port";
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portBox.FormattingEnabled = true;
            this.portBox.Location = new System.Drawing.Point(53, 19);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(139, 24);
            this.portBox.TabIndex = 24;
            // 
            // result_lbl
            // 
            this.result_lbl.AutoSize = true;
            this.result_lbl.BackColor = System.Drawing.Color.Transparent;
            this.result_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_lbl.Location = new System.Drawing.Point(494, 124);
            this.result_lbl.Name = "result_lbl";
            this.result_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.result_lbl.Size = new System.Drawing.Size(163, 20);
            this.result_lbl.TabIndex = 36;
            this.result_lbl.Text = "Success : 0  Failed : 0";
            this.result_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(347, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 20);
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
            this.listView1.Location = new System.Drawing.Point(350, 146);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(304, 148);
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
            this.smsname.Width = 105;
            // 
            // smsstatus
            // 
            this.smsstatus.Text = "Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(241, 327);
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
            this.cntChar1.Location = new System.Drawing.Point(220, 327);
            this.cntChar1.Name = "cntChar1";
            this.cntChar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cntChar1.Size = new System.Drawing.Size(15, 16);
            this.cntChar1.TabIndex = 31;
            this.cntChar1.Text = "1";
            // 
            // Browse
            // 
            this.Browse.BackColor = System.Drawing.Color.Transparent;
            this.Browse.Image = global::SmsBlaster.Properties.Resources.browse;
            this.Browse.Location = new System.Drawing.Point(103, 8);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(70, 27);
            this.Browse.TabIndex = 30;
            this.Browse.TabStop = false;
            this.Browse.Click += new System.EventHandler(this.Browse_Click_1);
            // 
            // msg_sendAll
            // 
            this.msg_sendAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_sendAll.Location = new System.Drawing.Point(15, 146);
            this.msg_sendAll.Name = "msg_sendAll";
            this.msg_sendAll.Size = new System.Drawing.Size(304, 178);
            this.msg_sendAll.TabIndex = 27;
            this.msg_sendAll.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Select File";
            // 
            // txtBrowse
            // 
            this.txtBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowse.Location = new System.Drawing.Point(18, 41);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(301, 26);
            this.txtBrowse.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Message Body";
            // 
            // SendAll
            // 
            this.SendAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SendAll.Image = global::SmsBlaster.Properties.Resources.play;
            this.SendAll.Location = new System.Drawing.Point(231, 85);
            this.SendAll.Name = "SendAll";
            this.SendAll.Size = new System.Drawing.Size(88, 55);
            this.SendAll.TabIndex = 24;
            this.SendAll.Text = "Send";
            this.SendAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SendAll.UseCompatibleTextRendering = true;
            this.SendAll.UseVisualStyleBackColor = true;
            this.SendAll.Click += new System.EventHandler(this.SendAll_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 481);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sms Blaster";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.portGroupBox.ResumeLayout(false);
            this.portGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Browse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
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
        private System.Windows.Forms.PictureBox Browse;
        private System.Windows.Forms.RichTextBox msg_sendAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SendAll;
        private System.Windows.Forms.GroupBox portGroupBox;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;


    }
}

