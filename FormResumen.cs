using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoDesktop
{
    public partial class FormResumen : Form
    {
        public FormResumen()
        {
            InitializeComponent();
            RenderizarGraficoDona();
        }

        private void RenderizarGraficoDona()
        {
            if (this.picDona != null)
            {
                // Cambiar el fondo gris por blanco
                this.picDona.BackColor = Color.White;

                // Generar la imagen real de la dona
                Bitmap bmp = new Bitmap(150, 150);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.White);

                    Rectangle rect = new Rectangle(5, 5, 135, 135);

                    // Porciones del gráfico
                    g.FillPie(new SolidBrush(Color.FromArgb(13, 27, 62)), rect, -90, 120);     // Pendientes (2/6)
                    g.FillPie(new SolidBrush(Color.FromArgb(45, 110, 253)), rect, 30, 120);   // En progreso (2/6)
                    g.FillPie(new SolidBrush(Color.FromArgb(220, 53, 69)), rect, 150, 60);    // Bloqueadas (1/6)
                    g.FillPie(new SolidBrush(Color.FromArgb(100, 180, 250)), rect, 210, 60);  // Finalizadas (1/6)

                    // Hueco central
                    Rectangle hole = new Rectangle(32, 32, 72, 72);
                    g.FillEllipse(Brushes.White, hole);

                    // Texto central
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("6\nTareas", new Font("Segoe UI", 9.5f, FontStyle.Bold), Brushes.Black, hole, sf);
                }

                // Asignar imagen
                this.picDona.Image = bmp;
            }
        }
    }
}