namespace _1688
{
    partial class testForm
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
            this.btn查询类目 = new System.Windows.Forms.Button();
            this.btn获取类目属性 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn查询类目
            // 
            this.btn查询类目.Location = new System.Drawing.Point(12, 12);
            this.btn查询类目.Name = "btn查询类目";
            this.btn查询类目.Size = new System.Drawing.Size(103, 34);
            this.btn查询类目.TabIndex = 0;
            this.btn查询类目.Text = "获取分类";
            this.btn查询类目.UseVisualStyleBackColor = true;
            this.btn查询类目.Click += new System.EventHandler(this.btn查询类目_Click);
            // 
            // btn获取类目属性
            // 
            this.btn获取类目属性.Location = new System.Drawing.Point(12, 65);
            this.btn获取类目属性.Name = "btn获取类目属性";
            this.btn获取类目属性.Size = new System.Drawing.Size(103, 32);
            this.btn获取类目属性.TabIndex = 1;
            this.btn获取类目属性.Text = "获取类目属性";
            this.btn获取类目属性.UseVisualStyleBackColor = true;
            this.btn获取类目属性.Click += new System.EventHandler(this.btn获取类目属性_Click);
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 421);
            this.Controls.Add(this.btn获取类目属性);
            this.Controls.Add(this.btn查询类目);
            this.Name = "testForm";
            this.Text = "testForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn查询类目;
        private System.Windows.Forms.Button btn获取类目属性;
    }
}