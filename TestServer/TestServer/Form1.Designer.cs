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
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(40, 30);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(136, 30);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_SendMSG
            // 
            this.btn_SendMSG.Location = new System.Drawing.Point(282, 171);
            this.btn_SendMSG.Name = "btn_SendMSG";
            this.btn_SendMSG.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMSG.TabIndex = 2;
            this.btn_SendMSG.Text = "Send MSG";
            this.btn_SendMSG.UseVisualStyleBackColor = true;
            this.btn_SendMSG.Click += new System.EventHandler(this.btn_SendMSG_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(282, 84);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(171, 81);
            this.txt_send.TabIndex = 3;
            this.txt_send.Text = "這個是 Test !!!";
            // 
            // txt_recv
            // 
            this.txt_recv.Location = new System.Drawing.Point(40, 84);
            this.txt_recv.Multiline = true;
            this.txt_recv.Name = "txt_recv";
            this.txt_recv.Size = new System.Drawing.Size(220, 244);
            this.txt_recv.TabIndex = 3;
            // 
            // label_recv
            // 
            this.label_recv.AutoSize = true;
            this.label_recv.Location = new System.Drawing.Point(38, 69);
            this.label_recv.Name = "label_recv";
            this.label_recv.Size = new System.Drawing.Size(35, 12);
            this.label_recv.TabIndex = 4;
            this.label_recv.Text = "Recv :";
            // 
            // btn_SendHex
            // 
            this.btn_SendHex.Location = new System.Drawing.Point(282, 305);
            this.btn_SendHex.Name = "btn_SendHex";
            this.btn_SendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_SendHex.TabIndex = 2;
            this.btn_SendHex.Text = "Send HEX";
            this.btn_SendHex.UseVisualStyleBackColor = true;
            this.btn_SendHex.Click += new System.EventHandler(this.btn_SendHex_Click);
            // 
            // txt_sendHex
            // 
            this.txt_sendHex.Location = new System.Drawing.Point(282, 218);
            this.txt_sendHex.Multiline = true;
            this.txt_sendHex.Name = "txt_sendHex";
            this.txt_sendHex.Size = new System.Drawing.Size(171, 81);
            this.txt_sendHex.TabIndex = 3;
            this.txt_sendHex.Text = "1234567890ABCD";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 373);
            this.Controls.Add(this.label_recv);
            this.Controls.Add(this.txt_recv);
            this.Controls.Add(this.txt_sendHex);
            this.Controls.Add(this.txt_send);
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
    }
}

