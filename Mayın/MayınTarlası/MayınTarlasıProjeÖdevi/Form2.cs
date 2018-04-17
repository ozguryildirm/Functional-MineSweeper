using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

namespace MayınTarlasıProjeÖdevi
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        int kalanSure = 0;

        void MayinDoldur(int mayin, int satir1, int sutun1)
        {
            this.BackColor = SystemColors.Control;
            flowLayoutPanel1.Width = Form1.sutun * 50;
            flowLayoutPanel1.Height = Form1.satir * 50;
            timer1.Enabled = true;
            int[] mayinlar = new int[mayin];

            Random rnd = new Random();

            if (Form1.radioButton1Checked == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    lblSure.Text = 60.ToString();
                    int secilen = rnd.Next(0, Form1.satir * Form1.sutun);
                    if (mayinlar.Contains(secilen))
                    {
                        i--;
                        continue;
                    }
                    mayinlar[i] = secilen;
                }
            }

            else if (Form1.radioButton2Checked == true)
            {
                for (int i = 0; i < 12; i++)
                {
                    lblSure.Text = 45.ToString();
                    int secilen = rnd.Next(0, Form1.satir * Form1.sutun);
                    if (mayinlar.Contains(secilen))
                    {
                        i--;
                        continue;
                    }
                    mayinlar[i] = secilen;
                }
            }


            else if (Form1.radioButton3Checked == true)
            {
                
                for (int i = 0; i < 15; i++)
                {
                    lblSure.Text = 30.ToString();
                    int secilen = rnd.Next(0, Form1.satir * Form1.sutun);
                    if (mayinlar.Contains(secilen))
                    {
                        i--;
                        continue;
                    }
                    mayinlar[i] = secilen;
                }
            }

            for (int i = 0; i < satir1 * sutun1; i++)
            {
                Button btn = new Button();
                btn.Width = 50;
                btn.Height = 50;
                btn.Margin = new Padding(0);
                btn.Tag = mayinlar.Contains(i);
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
                btn.TabStop = false;
            }
        }

        int skor = 0;
        int sayac = 0;
        bool durum;
        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            Random rnd = new Random();
             durum = (bool)tiklanan.Tag;
            if (durum == true)
            {
                timer2.Enabled = true;
                timer1.Enabled = false;
                
                OyunBitir();
            
            }
            else
            {
                tiklanan.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                if (Form1.radioButton1Checked == true)
                    skor += 5;
                else if (Form1.radioButton2Checked == true)
                    skor += 10;
                else if (Form1.radioButton3Checked == true)
                    skor += 15;
                tiklanan.Enabled = false;
                label1.Text = "Skorunuz :" + skor;
            }
        }

        DialogResult dr;
        void OyunBitir()
        {
            if (dr == DialogResult.Yes || dr == DialogResult.No)
            {
                string folderUrl = Application.StartupPath + "\\Skorlar.txt";
                StreamWriter swYazici = new StreamWriter(folderUrl, true, Encoding.UTF8);
                DateTime exceptionTime = DateTime.Now;
                string text2 = skor.ToString();
                string text = Form1.skorIsmi;
                StringBuilder sb = new StringBuilder();
                sb.Append(text);
                sb.Append(" --> ");
                sb.Append(text2);
                sb.Append(" | ");
                sb.Append(exceptionTime);
                swYazici.WriteLine(sb.ToString());
                swYazici.Close();
                //string[] lines = { Form1.skorIsmi+"  "+ skor.ToString() };
                //System.IO.File.WriteAllLines("\r\nWriteLines.txt", lines);
            }

            foreach (Button item in flowLayoutPanel1.Controls)
            {
                bool durum = (bool)item.Tag;
                if (durum)
                {
                    timer1.Enabled = false;
                    SoundPlayer player = new SoundPlayer();
                    item.BackColor = Color.Red;
                    string path = "mayinses.wav";
                    player.SoundLocation = path;
                    player.Play();
                    item.BackgroundImage = Image.FromFile("mayin.jpg");
                }
            }
            

            dr = MessageBox.Show("Oyun sona erdi.\n" + label1.Text + "\nYeniden oynamak ister misiniz?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                flowLayoutPanel1.Controls.Clear();
                timer2.Enabled = false;
                sayac = 0;
                label1.Text = "Skorunuz : 0".ToString();


                if (Form1.radioButton1Checked == true)
                {
                    
                    MayinDoldur(5, Form1.satir, Form1.sutun);
                    skor = 0;
                    kalanSure = 60;
                    SoundPlayer player = new SoundPlayer();
                    string path = "ps.wav";
                    player.SoundLocation = path;
                    player.Play();
                }
                else if (Form1.radioButton2Checked == true)
                {
                    
                    MayinDoldur(12, Form1.satir, Form1.sutun);
                    skor = 0;
                    kalanSure = 45;
                    SoundPlayer player = new SoundPlayer();
                    string path = "ps.wav";
                    player.SoundLocation = path;
                    player.Play();
                }
                else if (Form1.radioButton3Checked == true)
                {
                    
                    MayinDoldur(15, Form1.satir, Form1.sutun);
                    skor = 0;
                    kalanSure = 30;
                    SoundPlayer player = new SoundPlayer();
                    string path = "ps.wav";
                    player.SoundLocation = path;
                    player.Play();
                }

                //Form1 f1 = new Form1();
                //f1.Show();
                //this.Hide();
            }
            else if (dr == DialogResult.No)
                Application.Exit();

            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timerAcilis.Enabled = true;
            
            if (Form1.radioButton1Checked == true)
            {
                kalanSure = 60;               
                timer1.Enabled = true;             
                MayinDoldur(5, Form1.satir, Form1.sutun);
                SoundPlayer player = new SoundPlayer();
                string path = "ps.wav";
                player.SoundLocation = path;
                player.Play();
            }
            else if (Form1.radioButton2Checked == true)
            {
                kalanSure = 45;
                timer1.Enabled = true;
                MayinDoldur(12, Form1.satir, Form1.sutun);
                SoundPlayer player = new SoundPlayer();
                string path = "ps.wav";
                player.SoundLocation = path;
                player.Play();
            }
            else if (Form1.radioButton3Checked == true)
            {
                kalanSure = 30;
                timer1.Enabled = true;
                MayinDoldur(15, Form1.satir, Form1.sutun);
                SoundPlayer player = new SoundPlayer();
                string path = "ps.wav";
                player.SoundLocation = path;
                player.Play();
            }
        }



        private void Button_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (Form1.radioButton1Checked == true)
            {

                if (kalanSure != 0)
                {
                    kalanSure--;
                }
                else
                    OyunBitir();           
            }
            else if (Form1.radioButton2Checked == true)
            {
                if (kalanSure != 0)
                {
                    kalanSure--;
                }
                else
                    OyunBitir();

            }
            else if (Form1.radioButton3Checked == true)
            {
                if (kalanSure != 0)
                {
                    kalanSure--;
                }
                else
                    OyunBitir();
            }
            lblSure.Text = kalanSure.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random renk = new Random();
            sayac++;
            if (sayac == 30 && durum == true)
            {
                this.BackColor = Color.FromArgb(renk.Next(0, 255), renk.Next(0, 255), renk.Next(0, 255));
               
            }        
        }
    
        private void timerAcilis_Tick(object sender, EventArgs e)
        {
            this.Width++;
            if (this.Width >= Form1.sutun * 50)
            {
                this.Height++;
                this.Width = Form1.sutun * 50;
                if (this.Height >= Form1.sutun * 50)
                {
                    this.Height = (Form1.satir * 50)-1;
                    this.Width = (Form1.sutun * 50) - 1;
                    timerAcilis.Enabled = false;
                }
            }
            
        }            //flowLayoutPanel1.Width = Form1.sutun* 50;  --> yukarıda olan ve forumu flowlayout a sabitleyen kod.
                     //flowLayoutPanel1.Height = Form1.satir* 50;
    }
}
