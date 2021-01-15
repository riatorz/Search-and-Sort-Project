using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARAMA_VE_SIRALAMA
{
    public partial class Arama : Form
    {
        private static int[] array;
        private static int aranan;
        private static int sayac;
        private static int index;
        static void RastgeleSayi(int[] sayilar,int min,int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < sayilar.Length; i++)
            {
                sayilar[i] = rnd.Next(min, max);
            }
        }
        public static void LineerSearch()
        {
            for (int i = 0; i < array.Length; i++)
            {
                sayac++;
                if (array[i] == aranan)
                {
                    index = i;
                    break;
                }
            }
        }
        public static int BinarySearch()
        {
            int baslangic = 0, orta = 0, bitis = array.Length - 1;
            while(baslangic <= bitis)
            {
                orta = (baslangic + bitis) / 2;
                if (aranan == array[orta])
                {
                    sayac++;
                    return orta;
                }
                else if (aranan < array[orta])
                {
                    sayac++;
                    bitis = orta - 1;
                }
                else
                {
                    sayac++;
                    baslangic = orta + 1;
                }
                    
            }
            return -1;
        }
        public Arama()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                button2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                button3.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                button2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) == 0)
            {
                MessageBox.Show("Tekrar deneyiniz.");
                button1.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(textBox5.Text) > Convert.ToInt32(textBox6.Text))
                {
                    MessageBox.Show("MIN sayı MAX sayıdan büyük olamaz. Tekrar yazınız.");
                    button1.Enabled = false;
                    textBox2.Enabled = false;
                    button3.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    textBox2.Enabled = true;
                    button3.Enabled = true;
                    listBox1.Items.Clear();
                    array = new int[Convert.ToInt32(textBox4.Text)];
                    RastgeleSayi(array, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
                    for (int i = 0; i < array.Length; i++)
                    {
                        listBox1.Items.Add(array[i]);
                    }
                }
                
            }
            
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text.Length == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           sayac = 0;
           aranan = Convert.ToInt32(textBox2.Text);
           var stopwatch = new System.Diagnostics.Stopwatch();
           if (comboBox1.SelectedIndex == 0)
           {
               stopwatch.Start();
               LineerSearch();
               stopwatch.Stop();
               if (sayac == array.Length)
               {
                   listBox1.Enabled = false;
                   MessageBox.Show("Aradığınız sayı bulunamadı","Arama sonucu");
                   listBox1.Enabled = true;
               }
               else
               {
                   listBox1.SelectedIndex = index;
                    MessageBox.Show($"Seçilen Algoritma: Lineer Arama\nKötü durum: O(n)\nEn iyi durum: O(1)\nOrtalama durum: O(n/2)\nAradığınız index seçilmiştir.\nIndex:{index}", "Algoritma bilgileri");
                }
               textBox1.Text = Convert.ToString(stopwatch.Elapsed.TotalMilliseconds) + " ms";
               textBox3.Text = Convert.ToString(sayac);
           }
           if (comboBox1.SelectedIndex == 1)
           {
               stopwatch.Start();
               index = BinarySearch();
               stopwatch.Stop();
               textBox1.Text = Convert.ToString(stopwatch.Elapsed.TotalMilliseconds) + " ms";
               textBox3.Text = Convert.ToString(sayac);
               if (index == -1)
               {
                   listBox1.Enabled = false;
                   MessageBox.Show("Aradığınız sayı bulunamadı", "Arama sonucu");
                   listBox1.Enabled = true;
               }
               else
               {
                    listBox1.SelectedIndex = index;
                    MessageBox.Show($"Seçilen Algoritma: İkili Arama(Binary Search)\nKötü durum: O(logn)\nEn iyi durum: O(1)\nOrtalama durum: O(logn)\nAradığınız index seçilmiştir.\nIndex:{index}", "Algoritma bilgileri");
               }
           }
        }

        private void Arama_Load(object sender, EventArgs e)
        {
            
            MessageBox.Show("Lütfen Algoritma seçimi yapınız.");
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-')
                e.Handled = true; 
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {

                e.Handled = true;
            }
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }


        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                
                e.Handled = true;
            }
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
            if(textBox5.Text != "")
            {
                string str = textBox5.Text;
                char[] strc = str.ToCharArray();
                if (str[0] == '-')
                    textBox5.MaxLength = 5;
                else
                    textBox5.MaxLength = 4;
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {

                e.Handled = true;
            }
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
            if (textBox5.Text != "")
            {
                string str = textBox5.Text;
                char[] strc = str.ToCharArray();
                if (str[0] == '-')
                    textBox5.MaxLength = 5;
                else
                    textBox5.MaxLength = 4;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] newarray = new int[array.Length];
            newarray = array;
            listBox1.Items.Clear();
            for (int i = 0; i < newarray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (newarray[j - 1] > newarray[j])
                    {
                        int temp = newarray[j - 1];
                        newarray[j - 1] = newarray[j];
                        newarray[j] = temp;
                    }
                }
            }
            for (int i = 0; i < newarray.Length; i++)
            {
                listBox1.Items.Add(newarray[i]);
            }
        }
    }
}
