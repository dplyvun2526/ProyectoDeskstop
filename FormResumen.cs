using ProyectoDeskstop;
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
            ConectarNavegacion();
        }

        private void ConectarNavegacion()
        {
            // Formularios disponibles
            if (this.buttonProyectos != null)
                this.buttonProyectos.Click += (s, e) => NavegarA(new FormProyectos());

            if (this.buttonResumen != null)
                this.buttonResumen.Click += (s, e) => NavegarA(new FormResumen());

            if (this.buttonAjustes != null)
                this.buttonAjustes.Click += (s, e) => NavegarA(new FormAjustes());

            // Pantallas pendientes de tus compañeros
            if (this.buttonInicio != null)
                this.buttonInicio.Click += (s, e) => MostrarPantallaEnDesarrollo("Inicio");

            if (this.buttonTareas != null)
                this.buttonTareas.Click += (s, e) => MostrarPantallaEnDesarrollo("Tareas");
        }

        private void NavegarA(Form siguienteForm)
        {
            if (this.GetType() == siguienteForm.GetType()) return;

            siguienteForm.StartPosition = FormStartPosition.Manual;
            siguienteForm.Location = this.Location;
            siguienteForm.Size = this.Size;

            this.Hide();
            siguienteForm.ShowDialog();
            this.Close();
        }

        private void MostrarPantallaEnDesarrollo(string nombrePantalla)
        {
            MessageBox.Show($"La pantalla de {nombrePantalla} se encuentra actualmente en desarrollo.",
                            "En proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RenderizarGraficoDona()
        {
            if (this.picDona != null)
            {
                this.picDona.BackColor = Color.White;

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

                this.picDona.Image = bmp;
            }
        }
    }
}