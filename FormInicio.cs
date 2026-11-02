using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Necesario para el gráfico circular

namespace ProyectoDeskstop
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            this.BackColor = Color.FromArgb(248, 249, 252); // Fondo claro similar a Figma
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Título Principal
            Label lblTitulo = new Label { Text = "Buenos días, Alex", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(30, 40, 60), Location = new Point(30, 20), AutoSize = true };
            Label lblSubtitulo = new Label { Text = "Aquí tienes una visión general del trabajo de tu equipo.", Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(33, 55), AutoSize = true };
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblSubtitulo);

            // Panel de Tarjetas Superiores
            FlowLayoutPanel panelTarjetas = new FlowLayoutPanel { Location = new Point(30, 100), Size = new Size(900, 100), FlowDirection = FlowDirection.LeftToRight };
            panelTarjetas.Controls.Add(CrearTarjeta("Proyectos activos", "4"));
            panelTarjetas.Controls.Add(CrearTarjeta("Tareas pendientes", "2"));
            panelTarjetas.Controls.Add(CrearTarjeta("En progreso", "2"));
            panelTarjetas.Controls.Add(CrearTarjeta("Finalizadas", "1"));
            this.Controls.Add(panelTarjetas);

            // Gráfico Circular (Estado de Tareas)
            CrearGraficoDonut();
        }

        private Panel CrearTarjeta(string titulo, string valor)
        {
            Panel p = new Panel { Size = new Size(200, 80), BackColor = Color.White, Margin = new Padding(0, 0, 15, 0), Padding = new Padding(10) };
            Label lblTit = new Label { Text = titulo, Location = new Point(10, 15), ForeColor = Color.DimGray, Font = new Font("Segoe UI", 9), AutoSize = true };
            Label lblVal = new Label { Text = valor, Location = new Point(160, 25), Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.Black, AutoSize = true };
            p.Controls.Add(lblTit);
            p.Controls.Add(lblVal);
            return p;
        }

        private void CrearGraficoDonut()
        {
            Chart chartTareas = new Chart { Location = new Point(650, 220), Size = new Size(250, 200), BackColor = Color.Transparent };
            ChartArea area = new ChartArea { BackColor = Color.Transparent };
            chartTareas.ChartAreas.Add(area);
            Series serie = new Series { Name = "Tareas", ChartType = SeriesChartType.Doughnut };

            // Colores basados en Figma
            serie.Points.AddXY("Pendientes", 2);
            serie.Points[0].Color = Color.FromArgb(30, 50, 100);
            serie.Points.AddXY("En progreso", 2);
            serie.Points[1].Color = Color.FromArgb(60, 100, 200);
            serie.Points.AddXY("Finalizadas", 1);
            serie.Points[2].Color = Color.FromArgb(180, 200, 230);

            chartTareas.Series.Add(serie);
            this.Controls.Add(chartTareas);
        }
    }
}