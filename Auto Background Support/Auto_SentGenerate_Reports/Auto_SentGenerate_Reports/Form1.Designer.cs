namespace Auto_SentGenerate_Reports
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tpg_list = new System.Windows.Forms.TabPage();
            this.lbl_notif = new System.Windows.Forms.Label();
            this.dt_time = new System.Windows.Forms.DateTimePicker();
            this.txt_dispnext = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pg_loading = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_currenttime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_list = new System.Windows.Forms.DataGridView();
            this.dgv_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcntrl_main = new System.Windows.Forms.TabControl();
            this.tpg_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list)).BeginInit();
            this.tbcntrl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Right Apps Auto Email";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tpg_list
            // 
            this.tpg_list.Controls.Add(this.lbl_notif);
            this.tpg_list.Controls.Add(this.dt_time);
            this.tpg_list.Controls.Add(this.txt_dispnext);
            this.tpg_list.Controls.Add(this.label12);
            this.tpg_list.Controls.Add(this.pg_loading);
            this.tpg_list.Controls.Add(this.label6);
            this.tpg_list.Controls.Add(this.label5);
            this.tpg_list.Controls.Add(this.button1);
            this.tpg_list.Controls.Add(this.txt_currenttime);
            this.tpg_list.Controls.Add(this.label4);
            this.tpg_list.Controls.Add(this.dgv_list);
            this.tpg_list.Location = new System.Drawing.Point(4, 22);
            this.tpg_list.Name = "tpg_list";
            this.tpg_list.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_list.Size = new System.Drawing.Size(655, 462);
            this.tpg_list.TabIndex = 1;
            this.tpg_list.Text = "Auto Email List";
            this.tpg_list.UseVisualStyleBackColor = true;
            // 
            // lbl_notif
            // 
            this.lbl_notif.AutoSize = true;
            this.lbl_notif.Location = new System.Drawing.Point(177, 388);
            this.lbl_notif.Name = "lbl_notif";
            this.lbl_notif.Size = new System.Drawing.Size(10, 13);
            this.lbl_notif.TabIndex = 28;
            this.lbl_notif.Text = ".";
            // 
            // dt_time
            // 
            this.dt_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_time.Location = new System.Drawing.Point(150, 314);
            this.dt_time.Name = "dt_time";
            this.dt_time.Size = new System.Drawing.Size(129, 20);
            this.dt_time.TabIndex = 27;
            // 
            // txt_dispnext
            // 
            this.txt_dispnext.Location = new System.Drawing.Point(150, 288);
            this.txt_dispnext.Name = "txt_dispnext";
            this.txt_dispnext.ReadOnly = true;
            this.txt_dispnext.Size = new System.Drawing.Size(129, 20);
            this.txt_dispnext.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Next time to generate :";
            // 
            // pg_loading
            // 
            this.pg_loading.Location = new System.Drawing.Point(11, 437);
            this.pg_loading.Name = "pg_loading";
            this.pg_loading.Size = new System.Drawing.Size(415, 18);
            this.pg_loading.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Loading";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Current Time : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Generate Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_currenttime
            // 
            this.txt_currenttime.AutoSize = true;
            this.txt_currenttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currenttime.Location = new System.Drawing.Point(147, 347);
            this.txt_currenttime.Name = "txt_currenttime";
            this.txt_currenttime.Size = new System.Drawing.Size(40, 15);
            this.txt_currenttime.TabIndex = 21;
            this.txt_currenttime.Text = "timer";
            this.txt_currenttime.Click += new System.EventHandler(this.txt_currenttime_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Max time range generated :";
            // 
            // dgv_list
            // 
            this.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_email,
            this.dgv_details});
            this.dgv_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_list.Location = new System.Drawing.Point(3, 3);
            this.dgv_list.Name = "dgv_list";
            this.dgv_list.ReadOnly = true;
            this.dgv_list.RowHeadersWidth = 25;
            this.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_list.Size = new System.Drawing.Size(649, 279);
            this.dgv_list.TabIndex = 1;
            this.dgv_list.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_list_CellPainting);
            // 
            // dgv_email
            // 
            this.dgv_email.HeaderText = "EMAIL";
            this.dgv_email.Name = "dgv_email";
            this.dgv_email.ReadOnly = true;
            // 
            // dgv_details
            // 
            this.dgv_details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_details.HeaderText = "DETAILS";
            this.dgv_details.Name = "dgv_details";
            this.dgv_details.ReadOnly = true;
            // 
            // tbcntrl_main
            // 
            this.tbcntrl_main.Controls.Add(this.tpg_list);
            this.tbcntrl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcntrl_main.Location = new System.Drawing.Point(0, 0);
            this.tbcntrl_main.Name = "tbcntrl_main";
            this.tbcntrl_main.SelectedIndex = 0;
            this.tbcntrl_main.Size = new System.Drawing.Size(663, 488);
            this.tbcntrl_main.TabIndex = 13;
            this.tbcntrl_main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcntrl_main_Selecting);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 488);
            this.Controls.Add(this.tbcntrl_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoSentEmail";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tpg_list.ResumeLayout(false);
            this.tpg_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list)).EndInit();
            this.tbcntrl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tpg_list;
        private System.Windows.Forms.DateTimePicker dt_time;
        private System.Windows.Forms.TextBox txt_dispnext;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pg_loading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txt_currenttime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_list;
        private System.Windows.Forms.TabControl tbcntrl_main;
        private System.Windows.Forms.Label lbl_notif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_details;
    }
}

