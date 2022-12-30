using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<ZnakJson> wspolrzedneObiektu = new List<ZnakJson>();
        private List<ZnakJson> znaki;

        const string FILE_NAME = "Test.txt";
        
        private Bitmap _bitmapa;
        public Form1()
        {
            InitializeComponent();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _bitmapa = new Bitmap(openFileDialog.FileName);
                    this.pictureBox2.Image = _bitmapa;
                }
            }
        }
        private void skalaSzarościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmapaWynikowa = Edycja.GrayChange(_bitmapa);
            this.pictureBox2.Image = bitmapaWynikowa;
        }
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmapaWynikowa = Edycja.GrayChange(_bitmapa);
            this.pictureBox2.Image = bitmapaWynikowa;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "BMP(*.BMP) | *.bmp";
            if (save.ShowDialog() == DialogResult.OK)
                bitmapaWynikowa.Save(save.FileName);
        }
        private void progowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmapaCzarnoBiala = Edycja.GrayChange(_bitmapa);
            Bitmap bitmapaWynikowa = Edycja.Progowanie(bitmapaCzarnoBiala, 50);
            this.pictureBox2.Image = bitmapaWynikowa;
        }
        private void projekcjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmapaSzkielet = Edycja.Szkielet(_bitmapa);
            List<int> resultx = new List<int>();
            resultx = Edycja.ProjekcjaX(bitmapaSzkielet);
            Console.WriteLine("Po x: ");
            foreach (int i in resultx)
                Console.WriteLine(i);

            List<int> resulty = new List<int>();
            resulty = Edycja.ProjekcjaY(bitmapaSzkielet);
            Console.WriteLine("Po y: ");
            foreach (int i in resulty)
                Console.WriteLine(i);
        }
        private void szkieletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmapaWynikowa = Edycja.Szkielet(_bitmapa);
            this.pictureBox2.Image = bitmapaWynikowa;
        }
        private void projekcjaLiteryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Bitmap> wszystkieZnaki = new List<Bitmap>();

            List<Bitmap> linie = Edycja.WykryjLinie(_bitmapa);

            foreach (var linia in linie)
            {
                List<Bitmap> znaki = Edycja.WykryjZnaki(linia);
                wszystkieZnaki.AddRange(znaki);
            }

            foreach (var znak in wszystkieZnaki)
            {
                Bitmap bitmapaSzkielet = Edycja.Szkielet(znak);
                var resultx = Edycja.ProjekcjaX(bitmapaSzkielet);
                var resulty = Edycja.ProjekcjaY(bitmapaSzkielet);
                ZnakJson rezultaty = new ZnakJson(' ', resultx, resulty);
                wspolrzedneObiektu.Add(rezultaty);
            }
            Console.WriteLine("wykonanano");
        }
        private void zapisDoPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        List<Bitmap> wszystkieZnaki = new List<Bitmap>();

            List<Bitmap> linie = Edycja.WykryjLinie(_bitmapa);

            foreach (var linia in linie)
            {
                List<Bitmap> znaki = Edycja.WykryjZnaki(linia);
                wszystkieZnaki.AddRange(znaki);
            }

            StreamWriter sw;
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine($"{FILE_NAME} exists"); 
                sw = File.CreateText(FILE_NAME);
            }
            else
            {
                sw = new StreamWriter(FILE_NAME,true);
                Console.WriteLine("Plik otwarty");
            }
            Console.WriteLine("Dane zapisane");

            List<ZnakJson> znakiJson = new List<ZnakJson>();

            foreach (var znak in wszystkieZnaki)
            {
                Bitmap bitmapaSzkielet = Edycja.Szkielet(znak);
                var resultx = Edycja.ProjekcjaX(bitmapaSzkielet);
                var resulty = Edycja.ProjekcjaY(bitmapaSzkielet);
                ZnakJson zJson = new ZnakJson(' ', resultx, resulty);
                znakiJson.Add(zJson);

            }
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(znakiJson);
            sw.WriteLine(jsonString);           
            sw.Close();
        }
        private void odczytZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json;
            string title = "Odczyt";
            string zmienna = "Odczytano z pliku";
            MessageBox.Show(zmienna, title);
            using (var sr = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
            {
                using (var srx = new StreamReader(sr))
                {
                    json = srx.ReadToEnd();
                }                
            }
            znaki = JsonConvert.DeserializeObject<List<ZnakJson>>(json);
        }
        private void porównanieDanychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<char> przewidywane = new List<char>();
            foreach (var znakWej in wspolrzedneObiektu)
            {
                Dictionary<char, List<int>> wyniki = new Dictionary<char, List<int>>();
                foreach (var znakBaza in znaki)
                {
                    int lengthx = znakBaza.ListaX.Count <= znakWej.ListaX.Count ? znakBaza.ListaX.Count
                        : znakWej.ListaX.Count;
                    int wynikx = 0;
                    int sumax = 0;
                    List<int> wartsciZczytane = new List<int>();
                    for (int i = 0; i < lengthx; i++)
                    {
                        wynikx = Math.Abs(znakBaza.ListaX[i] - znakWej.ListaX[i]);
                        sumax += wynikx;
                    }
                    int lengthy = znakBaza.ListaY.Count <= znakWej.ListaY.Count ? znakBaza.ListaY.Count 
                        : znakWej.ListaY.Count;
                    int wyniky = 0;
                    int sumay = 0;
                    for (int i = 0; i < lengthy; i++)
                    {
                        wyniky = Math.Abs(znakBaza.ListaY[i] - znakWej.ListaY[i]);
                        sumay += wyniky;
                    }
                    int suma = sumax + sumay;
                    if (wyniki.ContainsKey(znakBaza.Znak))
                    {
                        wyniki[znakBaza.Znak].Add(suma);

                    }
                    else
                    {
                        wyniki.Add(znakBaza.Znak, new List<int>() { suma });
                    }
                    System.Diagnostics.Debug.WriteLine("porownanie  " + suma);
                }
                var przewidywanyZnak = wyniki
                    .Select(t => new KeyValuePair<char, double>(t.Key, t.Value.Average()))
                    .OrderBy(t => t.Value).FirstOrDefault().Key;
                System.Diagnostics.Debug.WriteLine("rozpoznano " + przewidywanyZnak);
                przewidywane.Add(przewidywanyZnak); 
            }      
            string title = "Przewidywany ciąg znaków";
            string zmienna = new string(przewidywane.ToArray());
            MessageBox.Show(zmienna, title);
        }
    }
}

