using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoDeskstop
{
    public partial class FormTareas : Form
    {
        public FormTareas()
        {
            InitializeComponent();
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Encabezado
            Label lblSeccion = new Label { Text = "ORGANIZACIÓN DEL TRABAJO", Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.FromArgb(60, 100, 200), Location = new Point(30, 20), AutoSize = true };
            Label lblTitulo = new Label { Text = "Tareas", Font = new Font("Segoe UI", 20, FontStyle.Bold), Location = new Point(26, 40), AutoSize = true };
            this.Controls.Add(lblSeccion);
            this.Controls.Add(lblTitulo);

            // Botón Crear Tarea
            Button btnCrear = new Button { Text = "+ Crear tarea", Location = new Point(700, 40), Size = new Size(120, 35), BackColor = Color.FromArgb(41, 98, 255), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            btnCrear.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnCrear);

            // Configuración del DataGridView (Tabla de tareas)
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            DataGridView dgv = new DataGridView();
            dgv.Location = new Point(30, 120);
            dgv.Size = new Size(800, 350);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowTemplate.Height = 50;

            // Estilos de cabecera
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Definir Columnas
            dgv.Columns.Add("Tarea", "TAREA");
            dgv.Columns.Add("Responsable", "RESPONSABLE");
            dgv.Columns.Add("Estado", "ESTADO");
            dgv.Columns.Add("Prioridad", "PRIORIDAD");
            dgv.Columns.Add("Horas", "HORAS");

            // Datos de prueba basados en tu Figma
            dgv.Rows.Add("Validar prototipo con dirección\nRediseño web corporativa", "LM", "En progreso", "Alta", "4 h / 6 h");
            dgv.Rows.Add("Preparar componentes de navegación\nApp de clientes", "DR", "Pendiente", "Media", "0 h / 8 h");
            dgv.Rows.Add("Revisar copys de campaña\nCampaña verano", "MS", "Bloqueada", "Alta", "1.5 h / 3 h");
            dgv.Rows.Add("Documentar flujo de solicitudes\nPortal interno RRHH", "HV", "En progreso", "Media", "2 h / 5 h");

            this.Controls.Add(dgv);
        }
    }
}