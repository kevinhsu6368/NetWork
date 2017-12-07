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
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(24, 35);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_sendMSG
            // 
            this.btn_sendMSG.Location = new System.Drawing.Point(24, 97);
            this.btn_sendMSG.Name = "btn_sendMSG";
            this.btn_sendMSG.Size = new System.Drawing.Size(75, 23);
            this.btn_sendMSG.TabIndex = 1;
            this.btn_sendMSG.Text = "Send MSG";
            this.btn_sendMSG.UseVisualStyleBackColor = true;
            this.btn_sendMSG.Click += new System.EventHandler(this.btn_sendMSG_Click);
            // 
            // btn_sendHex
            // 
            this.btn_sendHex.Location = new System.Drawing.Point(24, 143);
            this.btn_sendHex.Name = "btn_sendHex";
            this.btn_sendHex.Size = new System.Drawing.Size(75, 23);
            this.btn_sendHex.TabIndex = 1;
            this.btn_sendHex.Text = "Send HEX";
            this.btn_sendHex.UseVisualStyleBackColor = true;
            this.btn_sendHex.Click += new System.EventHandler(this.btn_sendHex_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(24, 198);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 1;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_sendHex);
            this.Controls.Add(this.btn_sendMSG);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_sendMSG;
        private System.Windows.Forms.Button btn_sendHex;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button button1;
    }
}

