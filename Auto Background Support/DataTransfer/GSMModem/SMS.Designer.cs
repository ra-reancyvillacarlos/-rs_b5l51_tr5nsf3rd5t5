namespace GSMModem
{
    partial class SMS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvl_row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvl_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvl_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvl_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.cbo_port = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendBgWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 87);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 452);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text Blast Recipients";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_status);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 421);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(819, 28);
            this.panel3.TabIndex = 2;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(5, 8);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(51, 13);
            this.lbl_status.TabIndex = 0;
            this.lbl_status.Text = "Status :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvl_row,
            this.dgvl_name,
            this.dgvl_number,
            this.dgvl_status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(819, 383);
            this.dataGridView1.TabIndex = 1;
            // 
            // dgvl_row
            // 
            this.dgvl_row.HeaderText = "ROW";
            this.dgvl_row.Name = "dgvl_row";
            this.dgvl_row.ReadOnly = true;
            this.dgvl_row.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvl_name
            // 
            this.dgvl_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvl_name.HeaderText = "NAME";
            this.dgvl_name.Name = "dgvl_name";
            this.dgvl_name.ReadOnly = true;
            this.dgvl_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvl_number
            // 
            this.dgvl_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvl_number.HeaderText = "NUMBER";
            this.dgvl_number.Name = "dgvl_number";
            this.dgvl_number.ReadOnly = true;
            this.dgvl_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvl_status
            // 
            this.dgvl_status.HeaderText = "STATUS";
            this.dgvl_status.Name = "dgvl_status";
            this.dgvl_status.ReadOnly = true;
            this.dgvl_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_refresh);
            this.panel2.Controls.Add(this.btn_connect);
            this.panel2.Controls.Add(this.cbo_port);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 50);
            this.panel2.TabIndex = 0;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.SlateGray;
            this.btn_refresh.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_refresh.Location = new System.Drawing.Point(284, 11);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(87, 27);
            this.btn_refresh.TabIndex = 56;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_connect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_connect.Location = new System.Drawing.Point(191, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(87, 27);
            this.btn_connect.TabIndex = 54;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // cbo_port
            // 
            this.cbo_port.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbo_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_port.FormattingEnabled = true;
            this.cbo_port.Location = new System.Drawing.Point(70, 14);
            this.cbo_port.Name = "cbo_port";
            this.cbo_port.Size = new System.Drawing.Size(115, 21);
            this.cbo_port.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Port";
            // 
            // sendBgWorker
            // 
            this.sendBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendBgWorker_DoWork);
            // 
            // SMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(825, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS TextBlasts";
            this.Load += new System.EventHandler(this.SMS_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ComboBox cbo_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvl_row;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvl_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvl_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvl_status;
        private System.ComponentModel.BackgroundWorker sendBgWorker;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_status;

    }
}