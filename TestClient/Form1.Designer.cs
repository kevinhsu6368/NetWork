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
            this.btn_sendJSON = new System.Windows.Forms.Button();
            this.btn_sendHex = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
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
            this.gbx_login = new System.Windows.Forms.GroupBox();
            this.pic_avartar = new System.Windows.Forms.PictureBox();
            this.label_login_status = new System.Windows.Forms.Label();
            this.gbx_register = new System.Windows.Forms.GroupBox();
            this.rbn_sex_unknow = new System.Windows.Forms.RadioButton();
            this.rbn_sex_woman = new System.Windows.Forms.RadioButton();
            this.rbn_sex_man = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_nick_name = new System.Windows.Forms.TextBox();
            this.txt_last_name = new System.Windows.Forms.TextBox();
            this.txt_first_name = new System.Windows.Forms.TextBox();
            this.btn_regist = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_forget = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_forget_password = new System.Windows.Forms.TextBox();
            this.btn_forget = new System.Windows.Forms.Button();
            this.txt_json = new System.Windows.Forms.TextBox();
            this.label_s2c_error = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_register_status = new System.Windows.Forms.Label();
            this.gbx_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avartar)).BeginInit();
            this.gbx_register.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // btn_sendJSON
            // 
            this.btn_sendJSON.Location = new System.Drawing.Point(320, 306);
            this.btn_sendJSON.Name = "btn_sendJSON";
            this.btn_sendJSON.Size = new System.Drawing.Size(75, 23);
            this.btn_sendJSON.TabIndex = 1;
            this.btn_sendJSON.Text = "Send JSON";
            this.btn_sendJSON.UseVisualStyleBackColor = true;
            this.btn_sendJSON.Click += new System.EventHandler(this.btn_sendJSON_Click);
            // 
            // btn_sendHex
            // 
            this.btn_sendHex.Location = new System.Drawing.Point(11, 641);
            this.btn_sendHex.Name = "btn_sendHex";
            this.btn_sendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_sendHex.TabIndex = 1;
            this.btn_sendHex.Text = "Send HEX";
            this.btn_sendHex.UseVisualStyleBackColor = true;
            this.btn_sendHex.Click += new System.EventHandler(this.btn_sendHex_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(107, 68);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
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
            this.txt_Port.Text = "9091";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(24, 28);
            this.txt_IP.Multiline = true;
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(133, 25);
            this.txt_IP.TabIndex = 6;
            this.txt_IP.Text = "104.155.203.129";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Connect State :";
            // 
            // label_connect_status
            // 
            this.label_connect_status.AutoSize = true;
            this.label_connect_status.Location = new System.Drawing.Point(114, 104);
            this.label_connect_status.Name = "label_connect_status";
            this.label_connect_status.Size = new System.Drawing.Size(17, 12);
            this.label_connect_status.TabIndex = 10;
            this.label_connect_status.Text = "---";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(180, 32);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(84, 23);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_login_name
            // 
            this.txt_login_name.Location = new System.Drawing.Point(21, 34);
            this.txt_login_name.Multiline = true;
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.Size = new System.Drawing.Size(86, 25);
            this.txt_login_name.TabIndex = 6;
            this.txt_login_name.Text = "Kevin";
            // 
            // txt_login_pwd
            // 
            this.txt_login_pwd.Location = new System.Drawing.Point(113, 34);
            this.txt_login_pwd.Multiline = true;
            this.txt_login_pwd.Name = "txt_login_pwd";
            this.txt_login_pwd.Size = new System.Drawing.Size(61, 25);
            this.txt_login_pwd.TabIndex = 6;
            this.txt_login_pwd.Text = "123";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pwd:";
            // 
            // gbx_login
            // 
            this.gbx_login.Controls.Add(this.pic_avartar);
            this.gbx_login.Controls.Add(this.label5);
            this.gbx_login.Controls.Add(this.label_login_status);
            this.gbx_login.Controls.Add(this.label4);
            this.gbx_login.Controls.Add(this.txt_login_pwd);
            this.gbx_login.Controls.Add(this.txt_login_name);
            this.gbx_login.Controls.Add(this.btn_login);
            this.gbx_login.Location = new System.Drawing.Point(25, 137);
            this.gbx_login.Name = "gbx_login";
            this.gbx_login.Size = new System.Drawing.Size(281, 155);
            this.gbx_login.TabIndex = 11;
            this.gbx_login.TabStop = false;
            this.gbx_login.Text = "Login : ";
            // 
            // pic_avartar
            // 
            this.pic_avartar.Location = new System.Drawing.Point(115, 65);
            this.pic_avartar.Name = "pic_avartar";
            this.pic_avartar.Size = new System.Drawing.Size(93, 84);
            this.pic_avartar.TabIndex = 10;
            this.pic_avartar.TabStop = false;
            // 
            // label_login_status
            // 
            this.label_login_status.AutoSize = true;
            this.label_login_status.Location = new System.Drawing.Point(19, 75);
            this.label_login_status.Name = "label_login_status";
            this.label_login_status.Size = new System.Drawing.Size(14, 12);
            this.label_login_status.TabIndex = 9;
            this.label_login_status.Text = "...";
            // 
            // gbx_register
            // 
            this.gbx_register.Controls.Add(this.label_register_status);
            this.gbx_register.Controls.Add(this.rbn_sex_unknow);
            this.gbx_register.Controls.Add(this.rbn_sex_woman);
            this.gbx_register.Controls.Add(this.rbn_sex_man);
            this.gbx_register.Controls.Add(this.label10);
            this.gbx_register.Controls.Add(this.label_email);
            this.gbx_register.Controls.Add(this.label6);
            this.gbx_register.Controls.Add(this.label8);
            this.gbx_register.Controls.Add(this.label9);
            this.gbx_register.Controls.Add(this.label7);
            this.gbx_register.Controls.Add(this.txt_email);
            this.gbx_register.Controls.Add(this.txt_pwd);
            this.gbx_register.Controls.Add(this.txt_nick_name);
            this.gbx_register.Controls.Add(this.txt_last_name);
            this.gbx_register.Controls.Add(this.txt_first_name);
            this.gbx_register.Controls.Add(this.btn_regist);
            this.gbx_register.Location = new System.Drawing.Point(24, 298);
            this.gbx_register.Name = "gbx_register";
            this.gbx_register.Size = new System.Drawing.Size(282, 299);
            this.gbx_register.TabIndex = 11;
            this.gbx_register.TabStop = false;
            this.gbx_register.Text = "Regist : ";
            // 
            // rbn_sex_unknow
            // 
            this.rbn_sex_unknow.AutoSize = true;
            this.rbn_sex_unknow.Location = new System.Drawing.Point(134, 228);
            this.rbn_sex_unknow.Name = "rbn_sex_unknow";
            this.rbn_sex_unknow.Size = new System.Drawing.Size(63, 16);
            this.rbn_sex_unknow.TabIndex = 10;
            this.rbn_sex_unknow.Text = "Unknow";
            this.rbn_sex_unknow.UseVisualStyleBackColor = true;
            // 
            // rbn_sex_woman
            // 
            this.rbn_sex_woman.AutoSize = true;
            this.rbn_sex_woman.Location = new System.Drawing.Point(68, 228);
            this.rbn_sex_woman.Name = "rbn_sex_woman";
            this.rbn_sex_woman.Size = new System.Drawing.Size(60, 16);
            this.rbn_sex_woman.TabIndex = 10;
            this.rbn_sex_woman.Text = "Woman";
            this.rbn_sex_woman.UseVisualStyleBackColor = true;
            // 
            // rbn_sex_man
            // 
            this.rbn_sex_man.AutoSize = true;
            this.rbn_sex_man.Checked = true;
            this.rbn_sex_man.Location = new System.Drawing.Point(18, 228);
            this.rbn_sex_man.Name = "rbn_sex_man";
            this.rbn_sex_man.Size = new System.Drawing.Size(44, 16);
            this.rbn_sex_man.TabIndex = 10;
            this.rbn_sex_man.TabStop = true;
            this.rbn_sex_man.Text = "Man";
            this.rbn_sex_man.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "Sex :";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(18, 166);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(35, 12);
            this.label_email.TabIndex = 9;
            this.label_email.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pwd:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Last Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "Nick Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "First Name:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(20, 181);
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(189, 25);
            this.txt_email.TabIndex = 6;
            this.txt_email.Text = "snakehsu5253@gmail.com";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(21, 129);
            this.txt_pwd.Multiline = true;
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(86, 25);
            this.txt_pwd.TabIndex = 6;
            this.txt_pwd.Text = "123";
            // 
            // txt_nick_name
            // 
            this.txt_nick_name.Location = new System.Drawing.Point(21, 82);
            this.txt_nick_name.Multiline = true;
            this.txt_nick_name.Name = "txt_nick_name";
            this.txt_nick_name.Size = new System.Drawing.Size(86, 25);
            this.txt_nick_name.TabIndex = 6;
            this.txt_nick_name.Text = "清香白蓮";
            // 
            // txt_last_name
            // 
            this.txt_last_name.Location = new System.Drawing.Point(123, 34);
            this.txt_last_name.Multiline = true;
            this.txt_last_name.Name = "txt_last_name";
            this.txt_last_name.Size = new System.Drawing.Size(86, 25);
            this.txt_last_name.TabIndex = 6;
            this.txt_last_name.Text = "Hsu";
            // 
            // txt_first_name
            // 
            this.txt_first_name.Location = new System.Drawing.Point(21, 34);
            this.txt_first_name.Multiline = true;
            this.txt_first_name.Name = "txt_first_name";
            this.txt_first_name.Size = new System.Drawing.Size(86, 25);
            this.txt_first_name.TabIndex = 6;
            this.txt_first_name.Text = "Kevin";
            // 
            // btn_regist
            // 
            this.btn_regist.Location = new System.Drawing.Point(21, 260);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(75, 23);
            this.btn_regist.TabIndex = 1;
            this.btn_regist.Text = "Regist";
            this.btn_regist.UseVisualStyleBackColor = true;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_forget);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_forget_password);
            this.groupBox1.Controls.Add(this.btn_forget);
            this.groupBox1.Location = new System.Drawing.Point(320, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 112);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forget password: ";
            // 
            // label_forget
            // 
            this.label_forget.AutoSize = true;
            this.label_forget.Location = new System.Drawing.Point(111, 80);
            this.label_forget.Name = "label_forget";
            this.label_forget.Size = new System.Drawing.Size(14, 12);
            this.label_forget.TabIndex = 9;
            this.label_forget.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "Name:";
            // 
            // txt_forget_password
            // 
            this.txt_forget_password.Location = new System.Drawing.Point(21, 34);
            this.txt_forget_password.Multiline = true;
            this.txt_forget_password.Name = "txt_forget_password";
            this.txt_forget_password.Size = new System.Drawing.Size(143, 25);
            this.txt_forget_password.TabIndex = 6;
            this.txt_forget_password.Text = "Kevin";
            // 
            // btn_forget
            // 
            this.btn_forget.Location = new System.Drawing.Point(21, 75);
            this.btn_forget.Name = "btn_forget";
            this.btn_forget.Size = new System.Drawing.Size(84, 23);
            this.btn_forget.TabIndex = 1;
            this.btn_forget.Text = "Get";
            this.btn_forget.UseVisualStyleBackColor = true;
            this.btn_forget.Click += new System.EventHandler(this.btn_forget_Click);
            // 
            // txt_json
            // 
            this.txt_json.Location = new System.Drawing.Point(320, 332);
            this.txt_json.Multiline = true;
            this.txt_json.Name = "txt_json";
            this.txt_json.Size = new System.Drawing.Size(281, 120);
            this.txt_json.TabIndex = 6;
            this.txt_json.Text = "{\r\n    \"status\":0,\r\n    \"msg\":\"ok\",\r\n    \"data\":\r\n    {\r\n        \"friends\":\r\n    " +
    "    [\r\n            {\"id\":1, \"name\":\"night\"},\r\n            {\"id\":3, \"name\":\"tom\"}" +
    "\r\n        ]\r\n    }\r\n}";
            // 
            // label_s2c_error
            // 
            this.label_s2c_error.AutoSize = true;
            this.label_s2c_error.Location = new System.Drawing.Point(318, 31);
            this.label_s2c_error.Name = "label_s2c_error";
            this.label_s2c_error.Size = new System.Drawing.Size(17, 12);
            this.label_s2c_error.TabIndex = 10;
            this.label_s2c_error.Text = "---";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(314, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "S2C  error :";
            // 
            // label_register_status
            // 
            this.label_register_status.AutoSize = true;
            this.label_register_status.Location = new System.Drawing.Point(132, 85);
            this.label_register_status.Name = "label_register_status";
            this.label_register_status.Size = new System.Drawing.Size(14, 12);
            this.label_register_status.TabIndex = 11;
            this.label_register_status.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 676);
            this.Controls.Add(this.gbx_register);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbx_login);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_s2c_error);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_connect_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_sendHex);
            this.Controls.Add(this.txt_json);
            this.Controls.Add(this.btn_sendJSON);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbx_login.ResumeLayout(false);
            this.gbx_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avartar)).EndInit();
            this.gbx_register.ResumeLayout(false);
            this.gbx_register.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_sendJSON;
        private System.Windows.Forms.Button btn_sendHex;
        private System.Windows.Forms.Button btn_Stop;
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
        private System.Windows.Forms.GroupBox gbx_login;
        private System.Windows.Forms.GroupBox gbx_register;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_first_name;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_last_name;
        private System.Windows.Forms.RadioButton rbn_sex_unknow;
        private System.Windows.Forms.RadioButton rbn_sex_woman;
        private System.Windows.Forms.RadioButton rbn_sex_man;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nick_name;
        private System.Windows.Forms.Label label_login_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_forget;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_forget_password;
        private System.Windows.Forms.Button btn_forget;
        private System.Windows.Forms.TextBox txt_json;
        private System.Windows.Forms.PictureBox pic_avartar;
        private System.Windows.Forms.Label label_s2c_error;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_register_status;
    }
}

