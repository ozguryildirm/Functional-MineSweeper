using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayınTarlasıProjeÖdevi
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
        }       

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox2.Text) < 5 || Convert.ToInt32(textBox2.Text) > 10)
                {
                    MessageBox.Show("Sütun Değeri 5-10 arasında olacak denildi sana!!");
                    textBox2.Text = "";
                    textBox2.Focus();

                }
            }
            catch
            {

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox3.Text) < 5 || Convert.ToInt32(textBox3.Text) > 10)
                {
                    MessageBox.Show("Sütun Değeri 5-10 arasında olacak denildi sana!!");
                    textBox3.Text = "";
                    textBox3.Focus();

                }
            }
            catch
            {

            }

        }

        

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        public static int satir;
        public static int sutun;

        public static bool radioButton1Checked;
        public static bool radioButton2Checked;
        public static bool radioButton3Checked;

        public static string skorIsmi;

        private void button2_Click(object sender, EventArgs e)
        {
            skorIsmi = textBox1.Text;

            radioButton1Checked = radioButton1.Checked;
            radioButton2Checked = radioButton2.Checked;
            radioButton3Checked = radioButton3.Checked;


            if (textBox1.Text == "")
                MessageBox.Show("Adın yok mu la senin??");
            else if ((textBox2.Text == "" || textBox3.Text == ""))
                MessageBox.Show("Satır ve sütunsuz yuvarlayarak mı oynayacan mayın tarlasını!! ");
            else if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                satir = Convert.ToInt32(textBox2.Text);
                sutun = Convert.ToInt32(textBox3.Text);
                Form2 f = new Form2();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Çapını görebilmem için bi zorluk seç..");
            }

            
          
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 fs = new Form3();
            fs.Show();
        }
    }
}
