﻿namespace TestServer
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
            this.lv_clients = new System.Windows.Forms.ListView();
            this.columnHeader_NO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ConnectID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_max_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(40, 70);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(144, 70);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_SendMSG
            // 
            this.btn_SendMSG.Location = new System.Drawing.Point(259, 268);
            this.btn_SendMSG.Name = "btn_SendMSG";
            this.btn_SendMSG.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMSG.TabIndex = 2;
            this.btn_SendMSG.Text = "Send MSG";
            this.btn_SendMSG.UseVisualStyleBackColor = true;
            this.btn_SendMSG.Click += new System.EventHandler(this.btn_SendMSG_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(259, 132);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_send.Size = new System.Drawing.Size(300, 130);
            this.txt_send.TabIndex = 3;
            this.txt_send.Text = "{\r\n    \"methodName\":\"0S2C_Login\",\r\n    \"paramObject\":\r\n     {\r\n       \"rs\":0,\r\n  " +
    "     \"ErrorCode\":\"00000000\"\r\n     }\r\n}";
            // 
            // txt_recv
            // 
            this.txt_recv.Location = new System.Drawing.Point(565, 352);
            this.txt_recv.Multiline = true;
            this.txt_recv.Name = "txt_recv";
            this.txt_recv.Size = new System.Drawing.Size(390, 55);
            this.txt_recv.TabIndex = 3;
            // 
            // label_recv
            // 
            this.label_recv.AutoSize = true;
            this.label_recv.Location = new System.Drawing.Point(563, 337);
            this.label_recv.Name = "label_recv";
            this.label_recv.Size = new System.Drawing.Size(35, 12);
            this.label_recv.TabIndex = 4;
            this.label_recv.Text = "Recv :";
            // 
            // btn_SendHex
            // 
            this.btn_SendHex.Location = new System.Drawing.Point(259, 384);
            this.btn_SendHex.Name = "btn_SendHex";
            this.btn_SendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_SendHex.TabIndex = 2;
            this.btn_SendHex.Text = "Send HEX";
            this.btn_SendHex.UseVisualStyleBackColor = true;
            this.btn_SendHex.Click += new System.EventHandler(this.btn_SendHex_Click);
            // 
            // txt_sendHex
            // 
            this.txt_sendHex.Location = new System.Drawing.Point(259, 297);
            this.txt_sendHex.Multiline = true;
            this.txt_sendHex.Name = "txt_sendHex";
            this.txt_sendHex.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_sendHex.Size = new System.Drawing.Size(300, 81);
            this.txt_sendHex.TabIndex = 3;
            this.txt_sendHex.Text = "1234567890ABCD";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lv_clients
            // 
            this.lv_clients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_NO,
            this.columnHeader_IP,
            this.columnHeader_ConnectID});
            this.lv_clients.FullRowSelect = true;
            this.lv_clients.GridLines = true;
            this.lv_clients.Location = new System.Drawing.Point(40, 132);
            this.lv_clients.Name = "lv_clients";
            this.lv_clients.Size = new System.Drawing.Size(213, 275);
            this.lv_clients.TabIndex = 5;
            this.lv_clients.UseCompatibleStateImageBehavior = false;
            this.lv_clients.View = System.Windows.Forms.View.Details;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port :";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(144, 27);
            this.txt_Port.Multiline = true;
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(81, 25);
            this.txt_Port.TabIndex = 8;
            this.txt_Port.Text = "8889";
            // 
            // txt_max_count
            // 
            this.txt_max_count.Location = new System.Drawing.Point(40, 29);
            this.txt_max_count.Multiline = true;
            this.txt_max_count.Name = "txt_max_count";
            this.txt_max_count.Size = new System.Drawing.Size(81, 25);
            this.txt_max_count.TabIndex = 8;
            this.txt_max_count.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Max Counts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Clients:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Recv Msg:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(565, 132);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(390, 192);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 41;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Connect ID";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "MSG";
            this.columnHeader4.Width = 127;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "other";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Send :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 430);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_max_count);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lv_clients);
            this.Controls.Add(this.label_recv);
            this.Controls.Add(this.txt_recv);
            this.Controls.Add(this.txt_sendHex);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.btn_SendHex);
            this.Controls.Add(this.btn_SendMSG);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_Stop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
        private System.Windows.Forms.ListView lv_clients;
        private System.Windows.Forms.ColumnHeader columnHeader_NO;
        private System.Windows.Forms.ColumnHeader columnHeader_IP;
        private System.Windows.Forms.ColumnHeader columnHeader_ConnectID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox txt_max_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label5;
    }
}

