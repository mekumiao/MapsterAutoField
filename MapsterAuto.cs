using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            var dir = GetAppsetting("modelDir");
            if (!string.IsNullOrWhiteSpace(dir)) this.txtModelPath.Text = dir;
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                manger.SourceCode = this.richTextStr.Text;
                var code = manger.ConvertCode();
                if (!string.IsNullOrWhiteSpace(code))
                {
                    this.richTextCode.Clear();
                    this.richTextCode.AppendText(code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 导入实体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                manger.SourceCode = this.richTextStr.Text;
                var names = manger.GetModelNames();
                if (names.Length != 2) throw new Exception("实体名称格式错误");

                listView1.Tag = names;
                var dir = this.txtModelPath.Text;
                var mp = new ModelImport();
                var field = mp.GetFields(dir, names[1], names[0]);

                if (field.Item1.Count > 0)
                {
                    listView1.Items.Clear();
                    field.Item1.ForEach(x =>
                    {
                        var listitem = new ListViewItem();
                        listitem.Text = x.Field;
                        listitem.SubItems.Add(x.Dest);
                        listitem.SubItems.Add("");
                        listitem.SubItems.Add("");
                        listView1.Items.Add(listitem);
                    });
                }
                if (field.Item2.Count > 0)
                {
                    listView2.Items.Clear();
                    field.Item2.ForEach(x =>
                    {
                        var listitem = new ListViewItem();
                        listitem.Text = x.Field;
                        listitem.SubItems.Add(x.Dest);
                        listView2.Items.Add(listitem);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView2.DoDragDrop(listView2.SelectedItems, DragDropEffects.Move);
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
                {
                    var listview = (ListView)sender;
                    var cp = listView1.PointToClient(new Point(e.X, e.Y));
                    var listItem = listView1.GetItemAt(cp.X, cp.Y);
                    if (listItem == null) return;

                    var lstViewColl = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                    if (lstViewColl.Count <= 0) return;

                    var subitem = new ListViewItem.ListViewSubItemCollection(listItem);
                    var item = lstViewColl[0];

                    if (lstViewColl[0].ListView.Name == "listView2")
                    {
                        if (string.IsNullOrWhiteSpace(subitem[2].Text))
                        {
                            subitem[2].Text = item.SubItems[0].Text;
                            subitem[3].Text = item.SubItems[1].Text;
                            item.Remove();
                        }
                        else
                        {
                            var listitem = new ListViewItem();
                            listitem.Text = subitem[2].Text;
                            listitem.SubItems.Add(subitem[3].Text);

                            listView2.Items.Add(listitem);
                            subitem[2].Text = item.SubItems[0].Text;
                            subitem[3].Text = item.SubItems[1].Text;
                            item.Remove();
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
                        {
                            var str1 = subitem[2].Text;
                            var str2 = subitem[3].Text;
                            subitem[2].Text = item.SubItems[2].Text;
                            subitem[3].Text = item.SubItems[3].Text;
                            item.SubItems[2].Text = str1;
                            item.SubItems[3].Text = str2;
                        }
                    }

                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            if (this.listView1.SelectedItems.Count <= 0) return;
            var item = this.listView1.SelectedItems[0];
            if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
            {
                var listitem = new ListViewItem();
                listitem.Text = item.SubItems[2].Text;
                listitem.SubItems.Add(item.SubItems[3].Text);
                this.listView2.Items.Add(listitem);
            }
            item.Remove();
        }

        private void 生成脚本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.richTextStr.Text = CreateScript();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateScript()
        {
            var names = listView1.Tag as string[];
            if (names == null || names.Length != 2) throw new Exception("请导入实体后，再自行操作");
            var builder = new StringBuilder();
            builder.AppendFormat("[{0},{1}]\n", names[0], names[1]);
            builder.AppendLine();
            foreach (ListViewItem item in listView1.Items)
            {
                builder.AppendFormat("{0},{1}\n", item.Text, item.SubItems[2].Text);
            }
            return builder.ToString();
        }

        private void 生成代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                manger.SourceCode = CreateScript();
                var code = manger.ConvertCode();
                if (!string.IsNullOrWhiteSpace(code))
                {
                    this.richTextCode.Clear();
                    this.richTextCode.AppendText(code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
                {
                    var lstViewColl = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                    if (lstViewColl.Count <= 0 || lstViewColl[0].ListView.Name == "listView2") return;

                    var item = lstViewColl[0];
                    if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
                    {
                        var listitem = new ListViewItem();
                        listitem.Text = item.SubItems[2].Text;
                        listitem.SubItems.Add(item.SubItems[3].Text);
                        this.listView2.Items.Add(listitem);
                        item.SubItems[2].Text = "";
                        item.SubItems[3].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var search = this.textBox1.Text;
            foreach (ListViewItem item in this.listView2.Items)
            {
                if (!string.IsNullOrWhiteSpace(search) && (item.Text.Contains(search) || item.SubItems[1].Text.Contains(search)))
                {
                    item.BackColor = SystemColors.GrayText;
                }
                else
                {
                    item.BackColor = SystemColors.ScrollBar;
                }
            }
        }

        #region "配置文件修改读取"
        private string GetAppsetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private void SetAppsetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);//保存到磁盘
            ConfigurationManager.RefreshSection("appSettings");//刷新节点
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            var result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtModelPath.Text = this.folderBrowserDialog1.SelectedPath;
                SetAppsetting("modelDir", this.txtModelPath.Text);
            }
        }
    }
}
