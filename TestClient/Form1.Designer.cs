namespace TestClient
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
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_sendMSG = new System.Windows.Forms.Button();
            this.btn_sendHex = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_connect_status = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.txt_login_name = new System.Windows.Forms.TextBox();
            this.txt_login_pwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(24, 68);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_sendMSG
            // 
            this.btn_sendMSG.Location = new System.Drawing.Point(24, 298);
            this.btn_sendMSG.Name = "btn_sendMSG";
            this.btn_sendMSG.Size = new System.Drawing.Size(75, 23);
            this.btn_sendMSG.TabIndex = 1;
            this.btn_sendMSG.Text = "Send MSG";
            this.btn_sendMSG.UseVisualStyleBackColor = true;
            this.btn_sendMSG.Click += new System.EventHandler(this.btn_sendMSG_Click);
            // 
            // btn_sendHex
            // 
            this.btn_sendHex.Location = new System.Drawing.Point(24, 344);
            this.btn_sendHex.Name = "btn_sendHex";
            this.btn_sendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_sendHex.TabIndex = 1;
            this.btn_sendHex.Text = "Send HEX";
            this.btn_sendHex.UseVisualStyleBackColor = true;
            this.btn_sendHex.Click += new System.EventHandler(this.btn_sendHex_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(116, 68);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP :";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(163, 28);
            this.txt_Port.Multiline = true;
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(81, 25);
            this.txt_Port.TabIndex = 5;
            this.txt_Port.Text = "8888";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(24, 28);
            this.txt_IP.Multiline = true;
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(133, 25);
            this.txt_IP.TabIndex = 6;
            this.txt_IP.Text = "192.168.0.120";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Connect State :";
            // 
            // label_connect_status
            // 
            this.label_connect_status.AutoSize = true;
            this.label_connect_status.Location = new System.Drawing.Point(116, 105);
            this.label_connect_status.Name = "label_connect_status";
            this.label_connect_status.Size = new System.Drawing.Size(17, 12);
            this.label_connect_status.TabIndex = 10;
            this.label_connect_status.Text = "---";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(183, 175);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_login_name
            // 
            this.txt_login_name.Location = new System.Drawing.Point(24, 173);
            this.txt_login_name.Multiline = true;
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.Size = new System.Drawing.Size(86, 25);
            this.txt_login_name.TabIndex = 6;
            this.txt_login_name.Text = "Kevin";
            // 
            // txt_login_pwd
            // 
            this.txt_login_pwd.Location = new System.Drawing.Point(116, 173);
            this.txt_login_pwd.Multiline = true;
            this.txt_login_pwd.Name = "txt_login_pwd";
            this.txt_login_pwd.Size = new System.Drawing.Size(61, 25);
            this.txt_login_pwd.TabIndex = 6;
            this.txt_login_pwd.Text = "123";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pwd:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 388);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_connect_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_login_pwd);
            this.Controls.Add(this.txt_login_name);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_sendHex);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_sendMSG);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_sendMSG;
        private System.Windows.Forms.Button btn_sendHex;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_connect_status;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_login_name;
        private System.Windows.Forms.TextBox txt_login_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

