using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ZnakJson
    {        public char Znak { get; set; }
        public List<int> ListaX { get; set; }
        public List<int> ListaY { get; set; }
        public ZnakJson(char znak, List<int> iloscX,List<int> iloscY)
        {
            Znak = znak;    
            ListaX= iloscX;
            ListaY= iloscY;
        }
    }
}
