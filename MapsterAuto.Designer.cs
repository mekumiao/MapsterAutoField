namespace MapsterAutoField
{
    partial class MapsterAuto
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextStr = new System.Windows.Forms.RichTextBox();
            this.richTextCode = new System.Windows.Forms.RichTextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtModelPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtModelPath);
            this.splitContainer2.Panel1.Controls.Add(this.btnImport);
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
            // richTextStr
            // 
            this.richTextStr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextStr.Location = new System.Drawing.Point(0, 0);
            this.richTextStr.Name = "richTextStr";
            this.richTextStr.Size = new System.Drawing.Size(591, 487);
            this.richTextStr.TabIndex = 0;
            this.richTextStr.Text = "[product_pt,stockc_skc]\n\ncj_cmteid,pt_cmteid\ncj_ddtame,T\ncj_mqty,12\nflag,false\nre" +
    "mark,\"hahahaha\"";
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(336, 53);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导入实体";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtModelPath
            // 
            this.txtModelPath.Location = new System.Drawing.Point(336, 26);
            this.txtModelPath.Name = "txtModelPath";
            this.txtModelPath.Size = new System.Drawing.Size(232, 21);
            this.txtModelPath.TabIndex = 4;
            this.txtModelPath.Text = "C:\\Users\\Administrator\\Desktop\\项目源码\\ZxSoftERP_SC\\ZxModel\\Model.Basic\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "实体文件夹";
            // 
            // MapsterAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 723);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MapsterAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "对象映射器-配置生成";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModelPath;
    }
}

