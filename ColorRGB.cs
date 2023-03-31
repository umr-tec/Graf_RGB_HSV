using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GrafU1_RGB
{
    public partial class ColorRGB : UserControl, IDisposable
    {
        //Declarar los campos que serán usados en la app
        private Rectangle colorRectabgulo;
        Color inicioColor, finColor;
        const int RectanguloMargen = 4;        
        //Degradado de colores
        LinearGradientBrush linearGradientBrush = null;
        Color[] colors;

        public ColorRGB()
        {
            InitializeComponent();
        }

        //Propiedades
        public int Value 
        {
            get { return (int)numericUpDown1.Value; }// Tomar Leeer
            set { numericUpDown1.Value = value; }//Establecer Escribir
        }
        public Color InicioColor
        {
            get { return inicioColor; }
            set { inicioColor = value;
                //Actualizar el metodo de CambioDeColor
                CrearBrush();
            }
        }        
        public Color FinColor
        {
            get { return finColor; }
            set { finColor = value; CrearBrush(); }
            
        }
        public Color[] Colors {
            get { return colors; }
            set { colors = value; }
        }
        // metodo de CambioDeColor
        void CrearBrush() {
            if (linearGradientBrush != null)
            {
                linearGradientBrush.Dispose();
            }
            linearGradientBrush = new LinearGradientBrush(colorRectabgulo, inicioColor, finColor, 0.0f);
        }


    }
}
