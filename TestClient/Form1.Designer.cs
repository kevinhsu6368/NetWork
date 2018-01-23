﻿namespace TestClient
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
            this.label_login_status = new System.Windows.Forms.Label();
            this.pic_avartar = new System.Windows.Forms.PictureBox();
            this.gbx_register = new System.Windows.Forms.GroupBox();
            this.label_register_status = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_photo_index = new System.Windows.Forms.NumericUpDown();
            this.btn_get_user_photo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btn_upload_photo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_partner_add = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_partner_email = new System.Windows.Forms.TextBox();
            this.btn_Partner_response_agree = new System.Windows.Forms.Button();
            this.txtPartnerInviterUID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPartnerInviterName = new System.Windows.Forms.TextBox();
            this.btn_Partner_response_deny = new System.Windows.Forms.Button();
            this.gbx_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_avartar)).BeginInit();
            this.gbx_register.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_photo_index)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(32, 74);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 29);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_sendJSON
            // 
            this.btn_sendJSON.Location = new System.Drawing.Point(453, 521);
            this.btn_sendJSON.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_sendJSON.Name = "btn_sendJSON";
            this.btn_sendJSON.Size = new System.Drawing.Size(100, 29);
            this.btn_sendJSON.TabIndex = 1;
            this.btn_sendJSON.Text = "Send JSON";
            this.btn_sendJSON.UseVisualStyleBackColor = true;
            this.btn_sendJSON.Click += new System.EventHandler(this.btn_sendJSON_Click);
            // 
            // btn_sendHex
            // 
            this.btn_sendHex.Location = new System.Drawing.Point(733, 521);
            this.btn_sendHex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_sendHex.Name = "btn_sendHex";
            this.btn_sendHex.Size = new System.Drawing.Size(100, 29);
            this.btn_sendHex.TabIndex = 1;
            this.btn_sendHex.Text = "Send HEX";
            this.btn_sendHex.UseVisualStyleBackColor = true;
            this.btn_sendHex.Click += new System.EventHandler(this.btn_sendHex_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(140, 74);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(69, 29);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP :";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(217, 35);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Port.Multiline = true;
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(73, 30);
            this.txt_Port.TabIndex = 5;
            this.txt_Port.Text = "9091";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(32, 35);
            this.txt_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_IP.Multiline = true;
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(176, 30);
            this.txt_IP.TabIndex = 6;
            this.txt_IP.Text = "104.155.203.129";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Connect State :";
            // 
            // label_connect_status
            // 
            this.label_connect_status.AutoSize = true;
            this.label_connect_status.Location = new System.Drawing.Point(149, 124);
            this.label_connect_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_connect_status.Name = "label_connect_status";
            this.label_connect_status.Size = new System.Drawing.Size(22, 15);
            this.label_connect_status.TabIndex = 10;
            this.label_connect_status.Text = "---";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(240, 40);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(112, 29);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_login_name
            // 
            this.txt_login_name.Location = new System.Drawing.Point(28, 42);
            this.txt_login_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_login_name.Multiline = true;
            this.txt_login_name.Name = "txt_login_name";
            this.txt_login_name.Size = new System.Drawing.Size(113, 30);
            this.txt_login_name.TabIndex = 6;
            this.txt_login_name.Text = "www@gmail.com";
            // 
            // txt_login_pwd
            // 
            this.txt_login_pwd.Location = new System.Drawing.Point(151, 42);
            this.txt_login_pwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_login_pwd.Multiline = true;
            this.txt_login_pwd.Name = "txt_login_pwd";
            this.txt_login_pwd.Size = new System.Drawing.Size(80, 30);
            this.txt_login_pwd.TabIndex = 6;
            this.txt_login_pwd.Text = "www";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pwd:";
            // 
            // gbx_login
            // 
            this.gbx_login.Controls.Add(this.label5);
            this.gbx_login.Controls.Add(this.label_login_status);
            this.gbx_login.Controls.Add(this.label4);
            this.gbx_login.Controls.Add(this.txt_login_pwd);
            this.gbx_login.Controls.Add(this.txt_login_name);
            this.gbx_login.Controls.Add(this.btn_login);
            this.gbx_login.Location = new System.Drawing.Point(8, 8);
            this.gbx_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_login.Name = "gbx_login";
            this.gbx_login.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_login.Size = new System.Drawing.Size(375, 122);
            this.gbx_login.TabIndex = 11;
            this.gbx_login.TabStop = false;
            this.gbx_login.Text = "Login : ";
            // 
            // label_login_status
            // 
            this.label_login_status.AutoSize = true;
            this.label_login_status.Location = new System.Drawing.Point(25, 94);
            this.label_login_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_login_status.Name = "label_login_status";
            this.label_login_status.Size = new System.Drawing.Size(19, 15);
            this.label_login_status.TabIndex = 9;
            this.label_login_status.Text = "...";
            // 
            // pic_avartar
            // 
            this.pic_avartar.Location = new System.Drawing.Point(321, 36);
            this.pic_avartar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pic_avartar.Name = "pic_avartar";
            this.pic_avartar.Size = new System.Drawing.Size(124, 105);
            this.pic_avartar.TabIndex = 10;
            this.pic_avartar.TabStop = false;
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
            this.gbx_register.Location = new System.Drawing.Point(8, 138);
            this.gbx_register.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_register.Name = "gbx_register";
            this.gbx_register.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_register.Size = new System.Drawing.Size(376, 374);
            this.gbx_register.TabIndex = 11;
            this.gbx_register.TabStop = false;
            this.gbx_register.Text = "Regist : ";
            // 
            // label_register_status
            // 
            this.label_register_status.AutoSize = true;
            this.label_register_status.Location = new System.Drawing.Point(176, 106);
            this.label_register_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_register_status.Name = "label_register_status";
            this.label_register_status.Size = new System.Drawing.Size(19, 15);
            this.label_register_status.TabIndex = 11;
            this.label_register_status.Text = "...";
            // 
            // rbn_sex_unknow
            // 
            this.rbn_sex_unknow.AutoSize = true;
            this.rbn_sex_unknow.Location = new System.Drawing.Point(179, 285);
            this.rbn_sex_unknow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbn_sex_unknow.Name = "rbn_sex_unknow";
            this.rbn_sex_unknow.Size = new System.Drawing.Size(76, 19);
            this.rbn_sex_unknow.TabIndex = 10;
            this.rbn_sex_unknow.Text = "Unknow";
            this.rbn_sex_unknow.UseVisualStyleBackColor = true;
            // 
            // rbn_sex_woman
            // 
            this.rbn_sex_woman.AutoSize = true;
            this.rbn_sex_woman.Location = new System.Drawing.Point(91, 285);
            this.rbn_sex_woman.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbn_sex_woman.Name = "rbn_sex_woman";
            this.rbn_sex_woman.Size = new System.Drawing.Size(72, 19);
            this.rbn_sex_woman.TabIndex = 10;
            this.rbn_sex_woman.Text = "Woman";
            this.rbn_sex_woman.UseVisualStyleBackColor = true;
            // 
            // rbn_sex_man
            // 
            this.rbn_sex_man.AutoSize = true;
            this.rbn_sex_man.Checked = true;
            this.rbn_sex_man.Location = new System.Drawing.Point(24, 285);
            this.rbn_sex_man.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbn_sex_man.Name = "rbn_sex_man";
            this.rbn_sex_man.Size = new System.Drawing.Size(54, 19);
            this.rbn_sex_man.TabIndex = 10;
            this.rbn_sex_man.TabStop = true;
            this.rbn_sex_man.Text = "Man";
            this.rbn_sex_man.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 266);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Sex :";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(24, 208);
            this.label_email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(45, 15);
            this.label_email.TabIndex = 9;
            this.label_email.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Pwd:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Last Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Nick Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "First Name:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(27, 226);
            this.txt_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(191, 30);
            this.txt_email.TabIndex = 6;
            this.txt_email.Text = "snakehsu5253@gmail.com";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(28, 161);
            this.txt_pwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pwd.Multiline = true;
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(113, 30);
            this.txt_pwd.TabIndex = 6;
            this.txt_pwd.Text = "123";
            // 
            // txt_nick_name
            // 
            this.txt_nick_name.Location = new System.Drawing.Point(28, 102);
            this.txt_nick_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_nick_name.Multiline = true;
            this.txt_nick_name.Name = "txt_nick_name";
            this.txt_nick_name.Size = new System.Drawing.Size(113, 30);
            this.txt_nick_name.TabIndex = 6;
            this.txt_nick_name.Text = "清香白蓮";
            // 
            // txt_last_name
            // 
            this.txt_last_name.Location = new System.Drawing.Point(164, 42);
            this.txt_last_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_last_name.Multiline = true;
            this.txt_last_name.Name = "txt_last_name";
            this.txt_last_name.Size = new System.Drawing.Size(113, 30);
            this.txt_last_name.TabIndex = 6;
            this.txt_last_name.Text = "Hsu";
            // 
            // txt_first_name
            // 
            this.txt_first_name.Location = new System.Drawing.Point(28, 42);
            this.txt_first_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_first_name.Multiline = true;
            this.txt_first_name.Name = "txt_first_name";
            this.txt_first_name.Size = new System.Drawing.Size(113, 30);
            this.txt_first_name.TabIndex = 6;
            this.txt_first_name.Text = "Kevin";
            // 
            // btn_regist
            // 
            this.btn_regist.Location = new System.Drawing.Point(28, 325);
            this.btn_regist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(100, 29);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 522);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(375, 140);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forget password: ";
            // 
            // label_forget
            // 
            this.label_forget.AutoSize = true;
            this.label_forget.Location = new System.Drawing.Point(148, 100);
            this.label_forget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_forget.Name = "label_forget";
            this.label_forget.Size = new System.Drawing.Size(19, 15);
            this.label_forget.TabIndex = 9;
            this.label_forget.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "Name:";
            // 
            // txt_forget_password
            // 
            this.txt_forget_password.Location = new System.Drawing.Point(28, 42);
            this.txt_forget_password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_forget_password.Multiline = true;
            this.txt_forget_password.Name = "txt_forget_password";
            this.txt_forget_password.Size = new System.Drawing.Size(189, 30);
            this.txt_forget_password.TabIndex = 6;
            this.txt_forget_password.Text = "Kevin";
            // 
            // btn_forget
            // 
            this.btn_forget.Location = new System.Drawing.Point(28, 94);
            this.btn_forget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_forget.Name = "btn_forget";
            this.btn_forget.Size = new System.Drawing.Size(112, 29);
            this.btn_forget.TabIndex = 1;
            this.btn_forget.Text = "Get";
            this.btn_forget.UseVisualStyleBackColor = true;
            this.btn_forget.Click += new System.EventHandler(this.btn_forget_Click);
            // 
            // txt_json
            // 
            this.txt_json.Location = new System.Drawing.Point(459, 176);
            this.txt_json.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_json.Multiline = true;
            this.txt_json.Name = "txt_json";
            this.txt_json.Size = new System.Drawing.Size(373, 336);
            this.txt_json.TabIndex = 6;
            this.txt_json.Text = "{\r\n    \"status\":0,\r\n    \"msg\":\"ok\",\r\n    \"data\":\r\n    {\r\n        \"friends\":\r\n    " +
    "    [\r\n            {\"id\":1, \"name\":\"night\"},\r\n            {\"id\":3, \"name\":\"tom\"}" +
    "\r\n        ]\r\n    }\r\n}";
            // 
            // label_s2c_error
            // 
            this.label_s2c_error.AutoSize = true;
            this.label_s2c_error.Location = new System.Drawing.Point(491, 59);
            this.label_s2c_error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_s2c_error.Name = "label_s2c_error";
            this.label_s2c_error.Size = new System.Drawing.Size(22, 15);
            this.label_s2c_error.TabIndex = 10;
            this.label_s2c_error.Text = "---";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(485, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "S2C  error :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown_photo_index);
            this.groupBox2.Controls.Add(this.btn_get_user_photo);
            this.groupBox2.Location = new System.Drawing.Point(8, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(376, 95);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "取得照片";
            // 
            // numericUpDown_photo_index
            // 
            this.numericUpDown_photo_index.Location = new System.Drawing.Point(28, 42);
            this.numericUpDown_photo_index.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_photo_index.Name = "numericUpDown_photo_index";
            this.numericUpDown_photo_index.Size = new System.Drawing.Size(160, 25);
            this.numericUpDown_photo_index.TabIndex = 0;
            // 
            // btn_get_user_photo
            // 
            this.btn_get_user_photo.Location = new System.Drawing.Point(219, 39);
            this.btn_get_user_photo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_get_user_photo.Name = "btn_get_user_photo";
            this.btn_get_user_photo.Size = new System.Drawing.Size(116, 29);
            this.btn_get_user_photo.TabIndex = 1;
            this.btn_get_user_photo.Text = "Get Photo";
            this.btn_get_user_photo.UseVisualStyleBackColor = true;
            this.btn_get_user_photo.Click += new System.EventHandler(this.btn_get_user_photo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.btn_upload_photo);
            this.groupBox3.Location = new System.Drawing.Point(8, 128);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(376, 95);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "上傳照片";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(28, 42);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(160, 25);
            this.numericUpDown1.TabIndex = 0;
            // 
            // btn_upload_photo
            // 
            this.btn_upload_photo.Location = new System.Drawing.Point(219, 39);
            this.btn_upload_photo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_upload_photo.Name = "btn_upload_photo";
            this.btn_upload_photo.Size = new System.Drawing.Size(116, 29);
            this.btn_upload_photo.TabIndex = 1;
            this.btn_upload_photo.Text = "upload Photo";
            this.btn_upload_photo.UseVisualStyleBackColor = true;
            this.btn_upload_photo.Click += new System.EventHandler(this.btn_upload_photo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 149);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(435, 695);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbx_login);
            this.tabPage1.Controls.Add(this.gbx_register);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(427, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(427, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Photo...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDown3);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(8, 371);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(376, 95);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "使用照片";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(28, 42);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(160, 25);
            this.numericUpDown3.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(219, 39);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Use Photo";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(8, 242);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(376, 95);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "變更照片";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(28, 42);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(160, 25);
            this.numericUpDown2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 39);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Change Photo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.txtPartnerInviterName);
            this.tabPage3.Controls.Add(this.txtPartnerInviterUID);
            this.tabPage3.Controls.Add(this.txt_partner_email);
            this.tabPage3.Controls.Add(this.btn_Partner_response_deny);
            this.tabPage3.Controls.Add(this.btn_Partner_response_agree);
            this.tabPage3.Controls.Add(this.btn_partner_add);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(427, 666);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "夥伴";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_partner_add
            // 
            this.btn_partner_add.Location = new System.Drawing.Point(15, 75);
            this.btn_partner_add.Name = "btn_partner_add";
            this.btn_partner_add.Size = new System.Drawing.Size(75, 23);
            this.btn_partner_add.TabIndex = 0;
            this.btn_partner_add.Text = "Add";
            this.btn_partner_add.UseVisualStyleBackColor = true;
            this.btn_partner_add.Click += new System.EventHandler(this.btn_partner_add_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Email :";
            // 
            // txt_partner_email
            // 
            this.txt_partner_email.Location = new System.Drawing.Point(15, 38);
            this.txt_partner_email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_partner_email.Multiline = true;
            this.txt_partner_email.Name = "txt_partner_email";
            this.txt_partner_email.Size = new System.Drawing.Size(145, 30);
            this.txt_partner_email.TabIndex = 10;
            this.txt_partner_email.Text = "www@gmail.com";
            // 
            // btn_Partner_response_agree
            // 
            this.btn_Partner_response_agree.Location = new System.Drawing.Point(15, 175);
            this.btn_Partner_response_agree.Name = "btn_Partner_response_agree";
            this.btn_Partner_response_agree.Size = new System.Drawing.Size(75, 23);
            this.btn_Partner_response_agree.TabIndex = 0;
            this.btn_Partner_response_agree.Text = "Agree";
            this.btn_Partner_response_agree.UseVisualStyleBackColor = true;
            this.btn_Partner_response_agree.Click += new System.EventHandler(this.btn_Partner_response_agree_Click);
            // 
            // txtPartnerInviterUID
            // 
            this.txtPartnerInviterUID.Location = new System.Drawing.Point(15, 138);
            this.txtPartnerInviterUID.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartnerInviterUID.Multiline = true;
            this.txtPartnerInviterUID.Name = "txtPartnerInviterUID";
            this.txtPartnerInviterUID.Size = new System.Drawing.Size(75, 30);
            this.txtPartnerInviterUID.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 120);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "inviter :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(117, 120);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "inviter Name :";
            // 
            // txtPartnerInviterName
            // 
            this.txtPartnerInviterName.Location = new System.Drawing.Point(120, 138);
            this.txtPartnerInviterName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartnerInviterName.Multiline = true;
            this.txtPartnerInviterName.Name = "txtPartnerInviterName";
            this.txtPartnerInviterName.Size = new System.Drawing.Size(145, 30);
            this.txtPartnerInviterName.TabIndex = 10;
            // 
            // btn_Partner_response_deny
            // 
            this.btn_Partner_response_deny.Location = new System.Drawing.Point(113, 175);
            this.btn_Partner_response_deny.Name = "btn_Partner_response_deny";
            this.btn_Partner_response_deny.Size = new System.Drawing.Size(75, 23);
            this.btn_Partner_response_deny.TabIndex = 0;
            this.btn_Partner_response_deny.Text = "Deny";
            this.btn_Partner_response_deny.UseVisualStyleBackColor = true;
            this.btn_Partner_response_deny.Click += new System.EventHandler(this.btn_Partner_response_deny_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 872);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pic_avartar);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_photo_index)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown_photo_index;
        private System.Windows.Forms.Button btn_get_user_photo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btn_upload_photo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_partner_email;
        private System.Windows.Forms.Button btn_partner_add;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPartnerInviterName;
        private System.Windows.Forms.TextBox txtPartnerInviterUID;
        private System.Windows.Forms.Button btn_Partner_response_deny;
        private System.Windows.Forms.Button btn_Partner_response_agree;
    }
}

