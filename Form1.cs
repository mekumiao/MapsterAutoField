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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ListViewItem ConvertItem(string dest, string src, string type)
        {
            var item = new ListViewItem();

            item.Text = dest;
            item.SubItems.Add(src);
            item.SubItems.Add(type == "1" ? "1" : "2");
            return item;
        }

        private void ItemRemove()
        {
            var chked = this.listView1.SelectedItems;
            if (chked != null && chked.Count > 0)
            {
                foreach (ListViewItem item in chked)
                {
                    this.listView1.Items.Remove(item);
                }

            }
            var count = this.listView1.Items.Count;
            if (count > 0)
            {
                this.listView1.Items[count - 1].Selected = true;
            }
        }

        private string ConvertCode()
        {
            var builder = new StringBuilder(string.Format("Config.ForType<{0}, {1}>()", this.txtSrcType.Text, this.txtDestType.Text));
            var temp1 = "\n\t\t\t\t.Map(dest => dest.{0}, src => src.{1})";
            var temp2 = "\n\t\t\t\t.Map(dest => dest.{0}, src => {1})";
            foreach (ListViewItem item in this.listView1.Items)
            {
                var temp = temp1;
                if (item.SubItems[2].Text == "2") temp = temp2;
                builder.Append(string.Format(temp, item.SubItems[0].Text, item.SubItems[1].Text));
            }
            builder.Append(";");
            return builder.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }

        /// <summary>
        /// 目标字段回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtSrc.Focus();
            }
        }

        /// <summary>
        /// 源字段回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtType.Focus();
            }
        }

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ItemRemove();
            }
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            this.richTextBox1.AppendText(ConvertCode());
        }

        /// <summary>
        /// 类型文本框 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var view = ConvertItem(this.txtDest.Text, this.txtSrc.Text, this.txtType.Text);
                this.listView1.Items.Add(view);

                this.txtDest.Clear();
                this.txtSrc.Clear();
                this.txtType.Text = "1";
                this.txtDest.Focus();
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (this.open.ShowDialog() == DialogResult.OK)
            {
                var exName = Path.GetExtension(this.open.FileName);
                if (exName == ".txt")
                {
                    using (StreamReader reader = new StreamReader(this.open.FileName))
                    {
                        string text = reader.ReadToEnd();
                        var list = text.Split('\n').ToList();
                        var tb1 = list.Select(x => x.Split(',').ToList()).ToList();

                        if (tb1.Any() && tb1.First().Any())
                        {
                            var array = new List<ListViewItem>();
                            tb1.ForEach(item =>
                            {
                                if (item.Count >= 3)
                                {
                                    var view = ConvertItem(item[0].Trim(), item[1].Trim(), item[2].Trim());
                                    array.Add(view);
                                }
                            });
                            this.listView1.Items.AddRange(array.ToArray());
                        }
                    }
                }
            }
        }
    }
}
