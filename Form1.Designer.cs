
namespace GrafU1_RGB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorRGB1 = new GrafU1_RGB.ColorRGB();
            this.button1 = new System.Windows.Forms.Button();
            this.colorRGB2 = new GrafU1_RGB.ColorRGB();
            this.SuspendLayout();
            // 
            // colorRGB1
            // 
            this.colorRGB1.Colors = null;
            this.colorRGB1.FinColor = System.Drawing.Color.White;
            this.colorRGB1.InicioColor = System.Drawing.Color.Black;
            this.colorRGB1.Location = new System.Drawing.Point(57, 45);
            this.colorRGB1.Maximo = 255;
            this.colorRGB1.Name = "colorRGB1";
            this.colorRGB1.Size = new System.Drawing.Size(435, 35);
            this.colorRGB1.TabIndex = 0;
            this.colorRGB1.Value = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hola";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorRGB2
            // 
            this.colorRGB2.Colors = null;
            this.colorRGB2.FinColor = System.Drawing.Color.White;
            this.colorRGB2.InicioColor = System.Drawing.Color.Black;
            this.colorRGB2.Location = new System.Drawing.Point(57, 86);
            this.colorRGB2.Maximo = 255;
            this.colorRGB2.Name = "colorRGB2";
            this.colorRGB2.Size = new System.Drawing.Size(435, 35);
            this.colorRGB2.TabIndex = 2;
            this.colorRGB2.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 362);
            this.Controls.Add(this.colorRGB2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorRGB1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ColorRGB colorRGB1;
        private System.Windows.Forms.Button button1;
        private ColorRGB colorRGB2;
    }
}

