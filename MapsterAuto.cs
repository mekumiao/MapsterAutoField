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

        /// <summary>
        /// 导入实体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            manger.SourceCode = this.richTextStr.Text;
            var names = manger.GetModelNames();
            var dir = this.txtModelPath.Text;
            var mp = new ModelImport();
            //var dict = mp.Build(dir, names[1], names[0]);
            var field = mp.GetFields(dir, names[1], names[0]);

            //if (dict.Count > 0)
            //{
            //    this.richTextCode.Clear();
            //    foreach (var item in dict)
            //    {
            //        this.richTextStr.AppendText(string.Format("\n{0},\t\t\t{1}", item.Key, item.Value));
            //    }
            //}
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
                    ListViewItem.ListViewSubItemCollection subitem;
                    foreach (ListViewItem item in lstViewColl)
                    {
                        subitem = new ListViewItem.ListViewSubItemCollection(listItem);
                        subitem[2].Text = item.SubItems[0].Text;
                        subitem[3].Text = item.SubItems[1].Text;
                        item.Remove();
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
            var listitem = new ListViewItem();
            listitem.Text = item.SubItems[2].Text;
            listitem.SubItems.Add(item.SubItems[3].Text);
            this.listView2.Items.Add(listitem);
            item.SubItems[2].Text = "";
            item.SubItems[3].Text = "";
        }
    }
}
