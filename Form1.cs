using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafU1_RGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnviarRangoColores();
            
        }

        private void EnviarRangoColores() {
            Color rgbColor = GetRgbColor();

            colorRGB2.EnviarColor(Color.FromArgb(0, rgbColor.G, rgbColor.B),
                Color.FromArgb(255, rgbColor.G, rgbColor.B));
        }

        private Color GetRgbColor()
        {
            return Color.FromArgb(
                colorRGB2.Value);               
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
