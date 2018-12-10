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
    public partial class newTextName : Form
    {
        public string textPath;
        public string textBox_Text;

        public newTextName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(textPath);
            textPath += "\\" + textBox1.Text + ".txt";
            StreamWriter sw = new StreamWriter(textPath, false);
            sw.Write(textBox_Text);
            sw.Close();
            this.Close();
        }
    }
}
