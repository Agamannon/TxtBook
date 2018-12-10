using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string textPath;
        public string openPath;
        public bool text_isNew;
        //string textPath = @"D:\file\C#\TextBox_Test.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(openPath);
            textBox.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(text_isNew)
            {
                StreamWriter sw = new StreamWriter(openPath);
                sw.Write(textBox.Text);
                sw.Close();
            }
            else
            {
                newTextName ntn = new newTextName();
                ntn.textPath = textPath;
                ntn.textBox_Text = textBox.Text;
                ntn.Show();
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                textBox.Font = fd.Font;
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                textBox.ForeColor = cd.Color;
            }
        }
    }
}
