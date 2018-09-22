namespace _1688
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGategory = new System.Windows.Forms.Button();
            this.btnAttributeInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutputMsg = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGategory
            // 
            this.btnGategory.Location = new System.Drawing.Point(6, 20);
            this.btnGategory.Name = "btnGategory";
            this.btnGategory.Size = new System.Drawing.Size(116, 36);
            this.btnGategory.TabIndex = 0;
            this.btnGategory.Text = "采集所有类目";
            this.btnGategory.UseVisualStyleBackColor = true;
            this.btnGategory.Click += new System.EventHandler(this.btnGategory_Click);
            // 
            // btnAttributeInfo
            // 
            this.btnAttributeInfo.Location = new System.Drawing.Point(178, 20);
            this.btnAttributeInfo.Name = "btnAttributeInfo";
            this.btnAttributeInfo.Size = new System.Drawing.Size(274, 36);
            this.btnAttributeInfo.TabIndex = 1;
            this.btnAttributeInfo.Text = "采集类目下面的属性和选项";
            this.btnAttributeInfo.UseVisualStyleBackColor = true;
            this.btnAttributeInfo.Click += new System.EventHandler(this.btnAttributeInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGategory);
            this.groupBox1.Controls.Add(this.btnAttributeInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具栏";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutputMsg);
            this.groupBox2.Controls.Add(this.vScrollBar1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 237);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据消息";
            // 
            // txtOutputMsg
            // 
            this.txtOutputMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutputMsg.Location = new System.Drawing.Point(3, 17);
            this.txtOutputMsg.Multiline = true;
            this.txtOutputMsg.Name = "txtOutputMsg";
            this.txtOutputMsg.ReadOnly = true;
            this.txtOutputMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputMsg.Size = new System.Drawing.Size(680, 217);
            this.txtOutputMsg.TabIndex = 2;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(368, 194);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "采集1688类目信息(调用接口)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGategory;
        private System.Windows.Forms.Button btnAttributeInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutputMsg;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

