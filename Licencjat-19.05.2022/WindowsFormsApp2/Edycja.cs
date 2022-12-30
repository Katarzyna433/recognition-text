using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{    public struct Rgb
    {
        #region pola
        public byte b, g, r;
        #endregion pola
        public Rgb Jasnosc()
        {
            Rgb rob;
            byte srednia = (byte)((this.r + this.g + this.b) / 3);
            rob.r = srednia;
            rob.g = srednia;
            rob.b = srednia;
            return rob;
        }
        public Rgb Jasnosc_waz()
        {
            Rgb rob;
            byte sredniaWazona = (byte)(this.r * 0.299 + this.g * 0.587 + this.b * 0.114);
            rob.r = sredniaWazona;
            rob.g = sredniaWazona;
            rob.b = sredniaWazona;
            return rob;
        }
     
    }
    public struct Odcinek
    {
        public int Start;
        public int End;
    }
    static class Edycja
    {
        public static Bitmap GrayChange(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;

            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int strideWe = bmWeData.Stride;
            int strideWy = bmWyData.Stride;

            IntPtr scanWe = bmWeData.Scan0;
            IntPtr scanWy = bmWyData.Scan0;

            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                    byte* pWy = (byte*)(void*)scanWy + y * strideWy;

                    for (int x = 0; x < szerokosc; x++)
                    {

                        Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                        Rgb pikselWynikowy = pikselWejsciowy.Jasnosc_waz();
                        ((Rgb*)pWy)[x] = pikselWynikowy;

                    }
                }
            }
            bitmapaWy.UnlockBits(bmWyData);
            bitmapaWe.UnlockBits(bmWeData);

            return bitmapaWy;
        }
        public static Bitmap Progowanie(Bitmap bitmapaWe, int prog)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;

            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int strideWe = bmWeData.Stride;
            int strideWy = bmWeData.Stride;

            IntPtr scanWe = bmWeData.Scan0;
            IntPtr scanWy = bmWyData.Scan0;
            Rgb black = new Rgb() { r = 0, g = 0, b = 0 };
            Rgb white = new Rgb() { r = 255, g = 255, b = 255 };
            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                    byte* pWy = (byte*)(void*)scanWy + y * strideWy;

                    for (int x = 0; x < szerokosc; x++)
                    {

                        var pikselWejsciowy = ((Rgb*)pWe)[x];
                        Rgb pikselWynikowy;
                        if (pikselWejsciowy.Jasnosc().r < prog)
                            pikselWynikowy = black;
                        else
                            pikselWynikowy = white;                  
                        ((Rgb*)pWy)[x] = pikselWynikowy;
                    }
                }
            }
            bitmapaWy.UnlockBits(bmWyData);
            bitmapaWe.UnlockBits(bmWeData);

            return bitmapaWy;
        }   
        public static Bitmap Szkielet(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;

            Bitmap bitmapaWy = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);
            Bitmap bitmapaPom = new Bitmap(szerokosc, wysokosc, PixelFormat.Format24bppRgb);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmPomData = bitmapaPom.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int strideWe = bmWeData.Stride;
            int strideWy = bmWyData.Stride;
            int stridePom = bmPomData.Stride;

            IntPtr scanWe = bmWeData.Scan0;
            IntPtr scanWy = bmWyData.Scan0;
            IntPtr scanPom = bmPomData.Scan0;

            Rgb obiekt = new Rgb() { r = 0, g = 0, b = 0 };
            Rgb tlo = new Rgb() { r = 255, g = 255, b = 255 };

            unsafe
            {
                //kopiowanie pikseli
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                    byte* pPom = (byte*)(void*)scanPom + y * stridePom;

                    for (int x = 0; x < szerokosc; x++)
                    {
                        Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                        ((Rgb*)pPom)[x] = pikselWejsciowy;
                    }
                }

                while (true)
                {
                    bool czyPikselZostalUsuniety = false;

                    for (int y = 0; y < wysokosc - 1; y++)
                    {
                        byte* pPom = (byte*)(void*)scanPom + y * stridePom;
                        byte* pWy = (byte*)(void*)scanWy + y * strideWy;

                        for (int x = 0; x < szerokosc - 1; x++)
                        {
                            Rgb pikselWejsciowy = ((Rgb*)pPom)[x];
                            Rgb pikselWynikowy;

                            bool czyObiekt = pikselWejsciowy.r == obiekt.r &&
                                    pikselWejsciowy.g == obiekt.g &&
                                    pikselWejsciowy.b == obiekt.b;

                            if (czyObiekt)
                            {
                                Rgb lewy_gorny = ((Rgb*)((byte*)(void*)scanPom + (y - 1) * stridePom))[x - 1];
                                Rgb lewy_srodek = ((Rgb*)((byte*)(void*)scanPom + (y) * stridePom))[x - 1];
                                Rgb lewy_dol = ((Rgb*)((byte*)(void*)scanPom + (y + 1) * stridePom))[x - 1];

                                Rgb srodek_gorny = ((Rgb*)((byte*)(void*)scanPom + (y - 1) * stridePom))[x];
                                Rgb srodek_dol = ((Rgb*)((byte*)(void*)scanPom + (y + 1) * stridePom))[x];

                                Rgb prawy_gorny = ((Rgb*)((byte*)(void*)scanPom + (y - 1) * stridePom))[x + 1];
                                Rgb prawy_srodek = ((Rgb*)((byte*)(void*)scanPom + (y) * stridePom))[x + 1];
                                Rgb prawy_dol = ((Rgb*)((byte*)(void*)scanPom + (y + 1) * stridePom))[x + 1];

                                bool czyUsuwamy0 = srodek_gorny.r == tlo.r && srodek_gorny.g == tlo.g && srodek_gorny.b == tlo.b &&
                                                   lewy_dol.r == obiekt.r && lewy_dol.g == obiekt.g && lewy_dol.b == obiekt.b &&
                                                   srodek_dol.r == obiekt.r && srodek_dol.g == obiekt.g && srodek_dol.b == obiekt.b &&
                                                   prawy_dol.r == obiekt.r && prawy_dol.g == obiekt.g && prawy_dol.b == obiekt.b;

                                bool czyUsuwamy90 = prawy_srodek.r == tlo.r && prawy_srodek.g == tlo.g && prawy_srodek.b == tlo.b &&
                                                  lewy_gorny.r == obiekt.r && lewy_gorny.g == obiekt.g && lewy_gorny.b == obiekt.b &&
                                                  lewy_srodek.r == obiekt.r && lewy_srodek.g == obiekt.g && lewy_srodek.b == obiekt.b &&
                                                  lewy_dol.r == obiekt.r && lewy_dol.g == obiekt.g && lewy_dol.b == obiekt.b;

                                bool czyUsuwamy180 = srodek_dol.r == tlo.r && srodek_dol.g == tlo.g && srodek_dol.b == tlo.b &&
                                                    lewy_gorny.r == obiekt.r && lewy_gorny.g == obiekt.g && lewy_gorny.b == obiekt.b &&
                                                    srodek_gorny.r == obiekt.r && srodek_gorny.g == obiekt.g && srodek_gorny.b == obiekt.b &&
                                                    prawy_gorny.r == obiekt.r && prawy_gorny.g == obiekt.g && prawy_gorny.b == obiekt.b;

                                bool czyUsuwamy270 = lewy_srodek.r == tlo.r && lewy_srodek.g == tlo.g && lewy_srodek.b == tlo.b &&
                                                    prawy_gorny.r == obiekt.r && prawy_gorny.g == obiekt.g && prawy_gorny.b == obiekt.b &&
                                                    prawy_srodek.r == obiekt.r && prawy_srodek.g == obiekt.g && prawy_srodek.b == obiekt.b &&
                                                    prawy_dol.r == obiekt.r && prawy_dol.g == obiekt.g && prawy_dol.b == obiekt.b;

                                if (czyUsuwamy0 || czyUsuwamy90 || czyUsuwamy180 || czyUsuwamy270)
                                {
                                    czyPikselZostalUsuniety = true;
                                    pikselWynikowy = tlo;
                                }
                                else
                                {
                                    pikselWynikowy = obiekt;
                                }
                            }
                            else
                            {
                                pikselWynikowy = tlo;
                            }
                            ((Rgb*)pWy)[x] = pikselWynikowy;
                        }
                    }
                    if (czyPikselZostalUsuniety)
                    {
                        //kopiowanie pikseli
                        for (int y = 0; y < wysokosc; y++)
                        {
                            byte* pWy = (byte*)(void*)scanWy + y * strideWy;
                            byte* pPom = (byte*)(void*)scanPom + y * stridePom;

                            for (int x = 0; x < szerokosc; x++)
                            {
                                Rgb pikselWejsciowy = ((Rgb*)pWy)[x];
                                ((Rgb*)pPom)[x] = pikselWejsciowy;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            bitmapaPom.UnlockBits(bmPomData);
            bitmapaWy.UnlockBits(bmWyData);
            bitmapaWe.UnlockBits(bmWeData);

            return bitmapaWy;
        }
        public static List<int> ProjekcjaX(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int strideWe = bmWeData.Stride;
            IntPtr scanWe = bmWeData.Scan0;

            Rgb black = new Rgb() { r = 0, g = 0, b = 0 };
            Rgb white = new Rgb() { r = 255, g = 255, b = 255 };

            List<int> result = new List<int>();

            unsafe
            {
                for (int y = 0; y < wysokosc; y++)
                {
                    byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                    int licznik = 0;
                    for (int x = 0; x < szerokosc; x++)
                    {
                        Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                        if (pikselWejsciowy.r == black.r && pikselWejsciowy.g == black.g && 
                            pikselWejsciowy.b == black.b)
                            licznik++;
                    }
                    result.Add(licznik);                    
                }
            }
            bitmapaWe.UnlockBits(bmWeData);
            return result;
        }
        public static List<int> ProjekcjaY(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int strideWe = bmWeData.Stride;
            IntPtr scanWe = bmWeData.Scan0;

            Rgb black = new Rgb() { r = 0, g = 0, b = 0 };
            Rgb white = new Rgb() { r = 255, g = 255, b = 255 };

            List<int> result = new List<int>();

            unsafe
            {
                for (int x = 0; x < szerokosc; x++)                    
                {
                    int licznik = 0;
                    for (int y = 0; y < wysokosc; y++)
                    {
                        Rgb pikselWejsciowy = ((Rgb*)((byte*)(void*)scanWe + y * strideWe))[x];
                        if (pikselWejsciowy.r == black.r && pikselWejsciowy.g == black.g && 
                            pikselWejsciowy.b == black.b)
                            licznik++;
                    }
                    result.Add(licznik);
                }
            }
            bitmapaWe.UnlockBits(bmWeData);
            return result;
        }
        internal static List<Bitmap> WykryjLinie(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;
            var projekcjaY = ProjekcjaX(bitmapaWe);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int strideWe = bmWeData.Stride;
            IntPtr scanWe = bmWeData.Scan0;

            List<Odcinek> pasy = new List<Odcinek>();

            int start = -1;
            int stop = -1;

            for (int i = 0; i < projekcjaY.Count; i++)
            {
                if (projekcjaY[i] > 0)
                {
                    if (start >= 0) continue;
                    if (start < 0) start = i;
                }
                else
                {
                    if (start < 0) continue;
                    if (start >= 0)
                    {
                        var odcinek = new Odcinek();
                        odcinek.Start = start;
                        odcinek.End = i - 1;
                        pasy.Add(odcinek);
                        start = -1;
                    }
                }
            }

            List<Bitmap> result = new List<Bitmap>();

            foreach (var pas in pasy)
            {
                Bitmap bitmapaWy = new Bitmap(szerokosc, pas.End-pas.Start, PixelFormat.Format24bppRgb);
                BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, szerokosc, pas.End - pas.Start), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int strideWy = bmWyData.Stride;
                IntPtr scanWy = bmWyData.Scan0;

                unsafe
                {
                    for (int y = pas.Start; y < pas.End; y++)
                    {
                        byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                        byte* pWy = (byte*)(void*)scanWy + (y - pas.Start) * strideWy;

                        for (int x = 0; x < szerokosc; x++)
                        {
                            Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                            ((Rgb*)pWy)[x] = pikselWejsciowy;
                        }
                    }
                }
                bitmapaWy.UnlockBits(bmWyData);
                result.Add(bitmapaWy);
            }

            bitmapaWe.UnlockBits(bmWeData);
            return result;
        }
        internal static List<Bitmap> WykryjZnaki(Bitmap bitmapaWe)
        {
            int wysokosc = bitmapaWe.Height;
            int szerokosc = bitmapaWe.Width;
            var projekcjaX = ProjekcjaY(bitmapaWe);

            BitmapData bmWeData = bitmapaWe.LockBits(new Rectangle(0, 0, szerokosc, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int strideWe = bmWeData.Stride;
            IntPtr scanWe = bmWeData.Scan0;

            List<Odcinek> pasy = new List<Odcinek>();

            int start = -1;
            int stop = -1;
            int licznik = 0;
            for (int i = 0; i < projekcjaX.Count; i++)
            {
                if (projekcjaX[i] > 0)
                {
                    if (start >= 0) continue;
                    if (start < 0) start = i;
                }
                else
                {
                    if (start < 0) continue;
                    if (start >= 0)
                    {
                        var odcinek = new Odcinek();
                        odcinek.Start = start;
                        odcinek.End = i - 1;
                        pasy.Add(odcinek);
                        start = -1;
                    }
                }               
            }

            List<Bitmap> result = new List<Bitmap>();

            foreach (var pas in pasy)
            {
                if (pas.End - pas.Start < 2) continue;

                Bitmap bitmapaWy = new Bitmap(pas.End - pas.Start, wysokosc, PixelFormat.Format24bppRgb);
                BitmapData bmWyData = bitmapaWy.LockBits(new Rectangle(0, 0, pas.End-pas.Start, wysokosc), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int strideWy = bmWyData.Stride;
                IntPtr scanWy = bmWyData.Scan0;

                unsafe
                {
                    for (int y = 0; y < wysokosc; y++)
                    {
                        byte* pWe = (byte*)(void*)scanWe + y * strideWe;
                        byte* pWy = (byte*)(void*)scanWy + y * strideWy;

                        for (int x = pas.Start; x < pas.End; x++)
                        {
                            Rgb pikselWejsciowy = ((Rgb*)pWe)[x];
                            ((Rgb*)pWy)[x- pas.Start] = pikselWejsciowy;
                        }

                    }
                }
                bitmapaWy.UnlockBits(bmWyData);
                result.Add(bitmapaWy);
                licznik++;
            }
            //Console.WriteLine("licznik znaków: " + licznik);
            bitmapaWe.UnlockBits(bmWeData);
            return result;
        }
    }
}
