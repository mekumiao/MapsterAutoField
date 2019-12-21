using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapsterAutoField
{
    public partial class MapsterAuto : Form
    {
        private ConverCodeManger manger { get; set; }

        public MapsterAuto()
        {
            InitializeComponent();
            manger = new ConverCodeManger();
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            manger.SourceCode = this.richTextStr.Text;
            var code = manger.ConvertCode();
            if (!string.IsNullOrWhiteSpace(code))
            {
                this.richTextCode.Clear();
                this.richTextCode.AppendText(code);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            manger.SourceCode = this.richTextStr.Text;
            var names = manger.GetModelNames();
            var path = this.txtModelPath.Text;
            var mp = new ModelImport();
            var dict = mp.Test(path, names[1], names[0]);

            if (dict.Count > 0)
            {
                this.richTextCode.Clear();
                foreach (var item in dict)
                {
                    this.richTextStr.AppendText(string.Format("\n{0},\t\t\t{1}", item.Key, item.Value));
                }
            }
        }
    }
}
