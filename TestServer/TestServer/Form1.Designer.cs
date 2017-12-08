namespace TestServer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_SendMSG = new System.Windows.Forms.Button();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.txt_recv = new System.Windows.Forms.TextBox();
            this.label_recv = new System.Windows.Forms.Label();
            this.btn_SendHex = new System.Windows.Forms.Button();
            this.txt_sendHex = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_NO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ConnectID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_responseLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(40, 60);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(132, 60);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_SendMSG
            // 
            this.btn_SendMSG.Location = new System.Drawing.Point(281, 147);
            this.btn_SendMSG.Name = "btn_SendMSG";
            this.btn_SendMSG.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMSG.TabIndex = 2;
            this.btn_SendMSG.Text = "Send MSG";
            this.btn_SendMSG.UseVisualStyleBackColor = true;
            this.btn_SendMSG.Click += new System.EventHandler(this.btn_SendMSG_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(281, 60);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(171, 81);
            this.txt_send.TabIndex = 3;
            this.txt_send.Text = "這個是 Test !!!";
            // 
            // txt_recv
            // 
            this.txt_recv.Location = new System.Drawing.Point(40, 144);
            this.txt_recv.Multiline = true;
            this.txt_recv.Name = "txt_recv";
            this.txt_recv.Size = new System.Drawing.Size(220, 184);
            this.txt_recv.TabIndex = 3;
            // 
            // label_recv
            // 
            this.label_recv.AutoSize = true;
            this.label_recv.Location = new System.Drawing.Point(38, 129);
            this.label_recv.Name = "label_recv";
            this.label_recv.Size = new System.Drawing.Size(35, 12);
            this.label_recv.TabIndex = 4;
            this.label_recv.Text = "Recv :";
            // 
            // btn_SendHex
            // 
            this.btn_SendHex.Location = new System.Drawing.Point(281, 281);
            this.btn_SendHex.Name = "btn_SendHex";
            this.btn_SendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_SendHex.TabIndex = 2;
            this.btn_SendHex.Text = "Send HEX";
            this.btn_SendHex.UseVisualStyleBackColor = true;
            this.btn_SendHex.Click += new System.EventHandler(this.btn_SendHex_Click);
            // 
            // txt_sendHex
            // 
            this.txt_sendHex.Location = new System.Drawing.Point(281, 194);
            this.txt_sendHex.Multiline = true;
            this.txt_sendHex.Name = "txt_sendHex";
            this.txt_sendHex.Size = new System.Drawing.Size(171, 81);
            this.txt_sendHex.TabIndex = 3;
            this.txt_sendHex.Text = "1234567890ABCD";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_NO,
            this.columnHeader_IP,
            this.columnHeader_ConnectID});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(480, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(320, 206);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_NO
            // 
            this.columnHeader_NO.Text = "NO";
            this.columnHeader_NO.Width = 56;
            // 
            // columnHeader_IP
            // 
            this.columnHeader_IP.Text = "IP";
            this.columnHeader_IP.Width = 96;
            // 
            // columnHeader_ConnectID
            // 
            this.columnHeader_ConnectID.Text = "Connect ID";
            this.columnHeader_ConnectID.Width = 85;
            // 
            // btn_responseLogin
            // 
            this.btn_responseLogin.Location = new System.Drawing.Point(362, 147);
            this.btn_responseLogin.Name = "btn_responseLogin";
            this.btn_responseLogin.Size = new System.Drawing.Size(90, 23);
            this.btn_responseLogin.TabIndex = 2;
            this.btn_responseLogin.Text = "Response Login";
            this.btn_responseLogin.UseVisualStyleBackColor = true;
            this.btn_responseLogin.Click += new System.EventHandler(this.btn_responseLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 503);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_recv);
            this.Controls.Add(this.txt_recv);
            this.Controls.Add(this.txt_sendHex);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.btn_responseLogin);
            this.Controls.Add(this.btn_SendHex);
            this.Controls.Add(this.btn_SendMSG);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_SendMSG;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.TextBox txt_recv;
        private System.Windows.Forms.Label label_recv;
        private System.Windows.Forms.Button btn_SendHex;
        private System.Windows.Forms.TextBox txt_sendHex;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_NO;
        private System.Windows.Forms.ColumnHeader columnHeader_IP;
        private System.Windows.Forms.ColumnHeader columnHeader_ConnectID;
        private System.Windows.Forms.Button btn_responseLogin;
    }
}

