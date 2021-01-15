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
    public partial class Siralama : Form
    {
        private static int[] array;
        private static int[] tmp;
        private static int sayac;
        public static string ms;
        public static string str;
        static void RastgeleSayi(int[] sayilar,int min,int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < sayilar.Length; i++)
            {
                sayilar[i] = rnd.Next(min, max);
            }
            tmp = sayilar;
        }
        //#region
        
        
        public Siralama()
        {
            InitializeComponent();
        }
        #region INSERTION
        public static void Insertion()
        {
            sayac = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        sayac++;
                    }
                    sayac++;
                }
            }
        }
        #endregion
        #region SELECTION
        public static void Selection()
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                        sayac++;
                    }
                    sayac++;
                }
            }
        }
        #endregion
        #region MERGE
        public static void Merge(int l,int m,int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
            {
                sayac++;
                L[i] = array[l + i];
            }
            for (j = 0; j < n2; ++j)
            {
                sayac++;
                R[j] = array[m + 1 + j];
            }
            i = 0;
            j = 0;
            int k = l;
            while(i<n1 && j<n2)
            {
                if(L[i] <=R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
                sayac++;
            }
            while(i<n1)
            {
                array[k] = L[i];
                k++;
                i++;
                sayac++;
            }
            while(j < n2)
            {
                array[k] = R[j];
                k++;
                j++;
                sayac++;
            }
        }
        static void MergeSort(int l,int r)
        {
            if(l<r)
            {
                sayac++;
                int m = (l + r) / 2;
                MergeSort(l, m);
                MergeSort(m + 1, r);
                Merge(l, m, r);

            }
        }
        #endregion
        #region QUICK
        static int Bolme(int left, int right)
        {
            int selected = array[left];
            for (; ; )
            {
                while (array[left] < selected)
                    left++;
                while (array[right] > selected)
                    right--;
                if (left < right)
                {
                    if (array[left] == array[right])
                        return right;
                    int tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;
                    sayac++;
                }
                else
                    return right;
            }
        }
        static void Quick_Sort(int left, int right)
        {
            if (left < right)
            {
                int selected = Bolme(left, right);
                if (selected > 1)
                {
                    Quick_Sort(left, selected - 1);
                    sayac++;
                }
                if (selected + 1 < right)
                {
                    Quick_Sort(selected + 1, right);
                    sayac++;
                }
                    
            }
        }
        #endregion
        #region HEAP
        static void Heapify(int[] arr,int n,int i)
        {
            int gg = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] >  arr[gg])
            {
                gg = left;
                sayac++;
            }
            if (right < n && arr[right] > arr[gg])
            {
                gg = right;
                sayac++;
            }
            if(gg != i)
            {
                int swap = arr[i];
                arr[i] = arr[gg];
                arr[gg] = swap;
                sayac++;
                Heapify(arr,n, gg);
            }
        }
        static void HeapSort(int[] arr)
        {
            for (int i = arr.Length/2 -1;i>=0;i--)
            {
                sayac++;
                Heapify(arr,arr.Length, i);
            }
            for (int i = arr.Length - 1;i>0;i--)
            {
                sayac++;
                int tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;
                Heapify(arr,i, 0);
            }
        }
        #endregion
        #region COUNTING
        static int[] CountingSort(int[] arr)
        {
            int[] sArray = new int[arr.Length];
            int minv = arr[0];
            int maxv = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                sayac++;
                if (arr[i] < minv)
                    minv = arr[i];
                else if (arr[i] > maxv)
                    maxv = arr[i];

            }
            int[] counts = new int[maxv - minv + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                sayac++;
                counts[arr[i] - minv]++;
            }
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                sayac++;
                counts[i] = counts[i] + counts[i - 1];
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sayac++;
                sArray[counts[arr[i] - minv]--] = arr[i];
            }
            return sArray;
        }
        #endregion
        #region RADIX
        public static int Maxx(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }
        public static void countSort(int[] arr, int n, int xx)
        {
            int[] sOrt = new int[n]; 
            int i;
            int[] cnt = new int[10];
            for (i = 0; i < 10; i++)
            {
                cnt[i] = 0;
                sayac++;
            }
            for (i = 0; i < n; i++)
            {
                cnt[(arr[i] / xx) % 10]++;
                sayac++;
            }
            for (i = 1; i < 10; i++)
            {
                cnt[i] += cnt[i - 1];
                sayac++;
            }
            for (i = n - 1; i >= 0; i--)
            {
                sOrt[cnt[(arr[i] / xx) % 10] - 1] = arr[i];
                cnt[(arr[i] / xx) % 10]--;
                sayac++;
            }
            for (i = 0; i < n; i++)
            {
                arr[i] = sOrt[i];
                sayac++;
            }
                
        }
        
        public static void radixsort(int[] arr, int n)
        {
            int m = Maxx(arr, n);

            for (int xx = 1; m / xx > 0; xx *= 10)
            {
                countSort(arr, n, xx);
                sayac++;
            }
                
        }
        #endregion
        #region BUCKET
        public static void BucketSort(ref int[] data)
        {
            int minValue = data[0];
            int maxValue = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
                sayac++;
            }
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
                sayac++;
            }
            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
                sayac++;
            }
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                        sayac++;
                    }
                }
            }
        }
        #endregion
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-')
                e.Handled = true;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Siralama_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen önce sayı üretin.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            var stopwatch = new System.Diagnostics.Stopwatch();
            sayac = 0;
            if (comboBox1.SelectedIndex == 0)//Selection Sort
            {
                stopwatch.Start();
                Selection();
                stopwatch.Stop();
                str = "Worst-case: n²\nBest-case: n²\nAverage-case: n²\n";
            }
            else if (comboBox1.SelectedIndex == 1)//Insertion
            {
                stopwatch.Start();
                Insertion();
                stopwatch.Stop();
                str = "Worst-case: n²\nBest-case: n\nAverage-case: n²\n";
            }
            else if (comboBox1.SelectedIndex == 2)//Merge
            {
                stopwatch.Start();
                MergeSort(0, array.Length - 1);
                stopwatch.Stop();
                str = "Worst-case: nlogn\nBest-case: nlogn\nAverage-case: nlogn\n";
            }
            else if (comboBox1.SelectedIndex == 3)//Quick
            {
                stopwatch.Start();
                Quick_Sort(0, array.Length - 1);
                stopwatch.Stop();
                str = "Worst-case: n²\nBest-case: nlogn or n\nAverage-case: nlogn\n";
            }
            else if (comboBox1.SelectedIndex == 4)//Heap
            {
                stopwatch.Start();
                HeapSort(array);
                stopwatch.Stop();
                str = "Worst-case: nlogn\nBest-case: nlogn\nAverage-case: nlogn";
            }
            else if (comboBox1.SelectedIndex == 5)//Counting
            {
                stopwatch.Start();
                int[] sArray = CountingSort(array);
                array = sArray;
                stopwatch.Stop();
                str = "Worst-case: n\nBest-case: n\nAverage-case: n";
            }
            else if (comboBox1.SelectedIndex == 6)//Radix
            {
                stopwatch.Start();
                radixsort(array, array.Length);
                stopwatch.Stop();
                str = "Worst-case: n\nBest-case: n\nAverage-case: n";
            }
            else if (comboBox1.SelectedIndex == 7)//Bucket
            {
                stopwatch.Start();
                BucketSort(ref array);
                stopwatch.Stop();
                str = "Worst-case: n²\nBest-case: n+k\nAverage-case: n+k";
            }
            
            ms = stopwatch.Elapsed.TotalMilliseconds + "ms";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            
            for (int i = 0; i < array.Length; i++)
            {
                listBox2.Items.Add(array[i]);
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = Convert.ToInt32(listBox1.Items[i]);
            }
            MessageBox.Show($"Seçtiğiniz: {comboBox1.SelectedItem}\n{str}","Algoritma Bilgileri");
            textBox2.Text = Convert.ToString(sayac);
            textBox1.Text = Convert.ToString(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) == 0)
            {
                comboBox1.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox5.Text))
                {
                    MessageBox.Show("MIN sayı MAX sayıdan büyük olamaz. Tekrar yazınız.");
                }
                else
                {
                    comboBox1.Enabled = true;
                    listBox1.Items.Clear();
                    array = new int[Convert.ToInt32(textBox3.Text)];
                    RastgeleSayi(array, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                    for (int i = 0; i < array.Length; i++)
                    {
                        listBox1.Items.Add(array[i]);
                    }
                }
            }
            //listBox1.Items.Clear();
            //array = new int[Convert.ToInt32(textBox3.Text)];
            //tmp = new int[Convert.ToInt32(textBox3.Text)];
            //RastgeleSayi(array,Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox5.Text));
            //for (int i = 0; i < tmp.Length; i++)
            //{
            //    listBox1.Items.Add(tmp[i]);
            //}
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if(!(textBox4.Text == ""))
            {
                string str = textBox4.Text;
                char[] strc = str.ToCharArray();
                if (strc[0] == '-')
                {
                    textBox4.MaxLength = 5;
                }
                else
                {
                    textBox4.MaxLength = 4;
                }
            }
            

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
