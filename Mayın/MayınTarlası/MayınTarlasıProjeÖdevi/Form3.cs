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

namespace MayınTarlasıProjeÖdevi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string NewRow;
            listBox1.Items.Clear();
            StreamReader ShowFile = File.OpenText("Skorlar.txt");
            NewRow = ShowFile.ReadLine();
            while (NewRow != null)
            {
                listBox1.Items.Add(NewRow);
                NewRow = ShowFile.ReadLine();
            }
            ShowFile.Close();
        }
    }
}
