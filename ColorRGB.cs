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
        //Variable para determinar si se esta moviendo el slider
        bool dibujando = false;

        public ColorRGB()
        {
            InitializeComponent();
            //Inicializar los colores del slider
            InicioColor = Color.Black;
            FinColor = Color.White;
            //Asociar el numericUpDownd al metodo
            numericUpDown1.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);
            this.DoubleBuffered = true;
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

        //Propiedad para determinar el valor maximo del mumericUpDown
        public int Maximo
        {
            get { return (int)numericUpDown1.Maximum; }
            set { numericUpDown1.Maximum = value; }
        }

        //Activar un EventHandler para escuchar los cambios del numericIpDown
        public event EventHandler<EventArgs> ValueChanged;

        protected void OnValueChanged() {
            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

        // metodo de CambioDeColor
        void CrearBrush() {
            if (linearGradientBrush != null)
            {
                linearGradientBrush.Dispose();
            }
            linearGradientBrush = new LinearGradientBrush(colorRectabgulo, InicioColor, FinColor, 0.0f);
        }

        //Handler del numericUpDown
        void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            Refresh();
            OnValueChanged();
        }

        //Cargar la combinacion y area de inicio
        void DibujarSlider(Graphics graphics) {
            //Guardar el eatdo de un graficp
            GraphicsState state = graphics.Save();
            Point[] puntosIniciales = new Point[] {
                new Point(0,-5),
                new Point(2,0),
                new Point(0,2),
                new Point(-2,0),
                new Point(0,-5)
            };

            Point[] puntosFinales = new Point[]
            {
                new Point(0, -10),
                new Point(5, 0),
                new Point(0, 5),
                new Point(-5,0),
                new Point (0, -10)
            };

            //Los elementos del Path
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(puntosFinales);
            graphicsPath.AddPolygon(puntosIniciales);
            graphics.TranslateTransform(colorRectabgulo.Left + (float)(colorRectabgulo.Width * numericUpDown1.Value) / Maximo, colorRectabgulo.Bottom);
            graphics.FillPath(Brushes.Gray, graphicsPath);
            graphics.Restore(state);
        }

        //enviar los colores de inicio del slider
        public void EnviarColor(Color inicioColor, Color finColor) {
            this.inicioColor = inicioColor;
            this.finColor = finColor;
            CrearBrush();
            Refresh();
        }

        private void ActualizaSlider(Point location) {
            double porcentaje = (double)(location.X + colorRectabgulo.Left) / colorRectabgulo.Width;
            if (porcentaje > 1.0)
                porcentaje = 1.0;
            else if (porcentaje < 0.0)
                porcentaje = 0.0;
            numericUpDown1.Value = (int)(porcentaje * Maximo);
        }

        //Metodo para cargar el tamaño de inicio del rectangulo
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!ClientRectangle.IsEmpty)
            {
                colorRectabgulo = new Rectangle(RectanguloMargen, RectanguloMargen, ClientRectangle.Width - numericUpDown1.Width - RectanguloMargen * 3, ClientSize.Height - RectanguloMargen * 2);
            }
            Refresh();
           // base.OnSizeChanged(e);
        }

        private void DibijarRectanguloColor(Graphics graphics) {
            if (Colors == null)
            {
                if (linearGradientBrush == null)
                {
                    CrearBrush();
                }
                graphics.FillRectangle(linearGradientBrush, colorRectabgulo);
            }
            else {
                //dibujar el slider de forma vertiucal
                double sliderWidt = (double)(colorRectabgulo.Width / Colors.Length);
                double left = colorRectabgulo.Left;
                for (int i = 0; i < Colors.Length; i++)
                {
                    using (Brush brush = new SolidBrush(Colors[i]))
                    {
                        graphics.FillRectangle(brush, (int)left, colorRectabgulo.Top, (int)((sliderWidt<1)?1:sliderWidt), colorRectabgulo.Height);
                    }
                    left += sliderWidt;
                }
            }
            graphics.DrawRectangle(Pens.Black, colorRectabgulo);
        }

    }  
}
