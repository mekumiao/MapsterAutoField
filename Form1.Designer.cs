namespace MapsterAutoField
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextCode = new System.Windows.Forms.RichTextBox();
            this.richTextStr = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextCode);
            this.splitContainer1.Size = new System.Drawing.Size(1318, 723);
            this.splitContainer1.SplitterDistance = 591;
            this.splitContainer1.TabIndex = 3;
            // 
            // richTextCode
            // 
            this.richTextCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextCode.Location = new System.Drawing.Point(0, 0);
            this.richTextCode.Name = "richTextCode";
            this.richTextCode.Size = new System.Drawing.Size(723, 723);
            this.richTextCode.TabIndex = 11;
            this.richTextCode.Text = "";
            // 
            // richTextStr
            // 
            this.richTextStr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextStr.Location = new System.Drawing.Point(0, 0);
            this.richTextStr.Name = "richTextStr";
            this.richTextStr.Size = new System.Drawing.Size(591, 487);
            this.richTextStr.TabIndex = 0;
            this.richTextStr.Text = "[product_pt,crej_cj]\n\ncj_cmteid,pt_cmteid\ncj_ddtame,T\ncj_mqty,12\nflag,false\nremar" +
    "k,\"hahahaha\"";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextStr);
            this.splitContainer2.Size = new System.Drawing.Size(591, 723);
            this.splitContainer2.SplitterDistance = 232;
            this.splitContainer2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 196);
            this.label1.TabIndex = 2;
            this.label1.Text = "字段 < 字段\r\n字段 < 当前时间(T)\r\n字段 < 数字\r\n字段 < bool\r\n字段 < 字符串\r\n\r\n\r\n示例：\r\n[product_pt,crej_cj" +
    "]\r\n\r\ncj_cmteid,pt_cmteid\r\ncj_ddtame,T\r\ncj_mqty,12\r\nflag,false\r\nremark,\"hahahaha\"" +
    "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 723);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象映射器-配置生成";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextStr;
        private System.Windows.Forms.RichTextBox richTextCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
    }
}

