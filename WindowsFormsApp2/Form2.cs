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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        bool dateSelect = false;
        string textPath = @"D:\work\my_TextBook\the_TextBook";
        Button btn_openTxt = new Button();
        Form1 txt;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showTxt();
            btn_openTxt.Visible = false;
            btn_openTxt.Text = "打开";
            btn_openTxt.Click += btn_openTxt_Click;
            listView1.Controls.Add(btn_openTxt);
        }

        private void 新建文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string create_textPath = textPath;
            create_textPath = create_textPath + "\\" + dateTimePicker1.Value.Year.ToString();
            create_textPath = create_textPath + "\\" + dateTimePicker1.Value.Month.ToString();
            create_textPath = create_textPath + "\\" + dateTimePicker1.Value.Day.ToString();

            txt = new Form1();
            txt.text_isNew = false;
            txt.textPath = create_textPath;
            txt.Show();
        }

        private void 开启日期筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateSelect = true;
            dateMenuItem1.Text = "开启日期筛选  √";
            dateMenuItem2.Text = "关闭日期筛选";
        }

        private void 关闭日期筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateSelect = false;
            dateMenuItem1.Text = "开启日期筛选";
            dateMenuItem2.Text = "关闭日期筛选  √";
        }

        private void showTxt()
        {
            int i, j, z, n;//用于遍历
            int list = 0;//用于listView
            DirectoryInfo root;
            DirectoryInfo[] year;
            DirectoryInfo[] month;
            DirectoryInfo[] day;
            FileInfo[] txt;
            string[] year_s;
            string[] month_s;
            string[] day_s;
            string create_time;
            //年份遍历
            root = new DirectoryInfo(textPath);
            year = root.GetDirectories();
            year_s = new string[year.Length];
            for (i = 0; i < year.Length; i++)
            {
                year_s[i] = year[i].Name;
                //月份遍历
                root = new DirectoryInfo(year[i].FullName);
                month = root.GetDirectories();
                month_s = new string[month.Length];
                for (j = 0; j < month.Length; j++)
                {
                    month_s[j] = month[j].Name;
                    //日期遍历
                    root = new DirectoryInfo(month[j].FullName);
                    day = root.GetDirectories();
                    day_s = new string[day.Length];
                    for (z = 0; z < day.Length; z++)
                    {
                        day_s[z] = day[z].Name;
                        //文档遍历
                        root = new DirectoryInfo(day[z].FullName);
                        txt = root.GetFiles();
                        for (n = 0; n < txt.Length; n++)
                        {
                            if (txt[n].Exists)
                            {
                                create_time = year_s[i] + "\\" + month_s[j] + "\\" + day_s[z];
                                listView1.Items.Add(txt[n].Name);
                                listView1.Items[list].SubItems.Add(create_time);
                                listView1.Items[list].SubItems.Add("");
                                listView1.Items[list].SubItems.Add("");
                                listView1.Items[list].SubItems.Add("");
                                list++;
                            }
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                btn_openTxt.Size = new Size(listView1.SelectedItems[0].SubItems[4].Bounds.Width, listView1.SelectedItems[0].SubItems[4].Bounds.Height);
                btn_openTxt.Location = new Point(listView1.SelectedItems[0].SubItems[4].Bounds.Left, listView1.SelectedItems[0].SubItems[4].Bounds.Top);
                btn_openTxt.Visible = true;
            }
        }

        private void btn_openTxt_Click(object sender, EventArgs e)
        {
            string openPath = textPath + "\\" + listView1.SelectedItems[0].SubItems[1].Text + "\\" + listView1.SelectedItems[0].SubItems[0].Text;
            txt = new Form1();
            txt.text_isNew = true;
            txt.openPath = openPath;
            txt.Show();
        }
    }
}
