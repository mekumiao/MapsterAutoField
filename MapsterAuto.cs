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
        public MapsterAuto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ConverCodeManger manger = new ConverCodeManger(this.richTextStr.Text);

            var code = manger.ConvertCode();
            if (!string.IsNullOrWhiteSpace(code))
            {
                this.richTextCode.Clear();
                this.richTextCode.AppendText(code);
            }
        }
    }
}
