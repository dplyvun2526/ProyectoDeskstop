using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoDesktop
{
    public partial class FormAjustes : Form
    {
        public FormAjustes()
        {
            InitializeComponent();
            ConfigurarEventosMenuAjustes();
        }

        private void ConfigurarEventosMenuAjustes()
        {
            if (this.btnTabPerfil != null) btnTabPerfil.Click += (s, e) => CambiarPestañaPerfil();
            if (this.btnTabIdioma != null) btnTabIdioma.Click += (s, e) => CambiarPestañaIdioma();
            if (this.btnTabNotif != null) btnTabNotif.Click += (s, e) => CambiarPestañaNotificaciones();
            if (this.btnTabPref != null) btnTabPref.Click += (s, e) => CambiarPestañaPreferencias();
        }

        private void CambiarPestañaPerfil()
        {
            PintarBotonActivo(btnTabPerfil);
            panelContentArea.Controls.Clear();
            panelContentArea.Controls.Add(cardPerfil);
        }

        private void CambiarPestañaIdioma()
        {
            PintarBotonActivo(btnTabIdioma);
            panelContentArea.Controls.Clear();

            Panel card = new Panel { Size = new Size(680, 250), BackColor = Color.White, Location = new Point(0, 0) };
            Label lblT = new Label { Text = "Idioma", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(20, 15), AutoSize = true };
            Label lblS = new Label { Text = "Planea usa por defecto el idioma de tu dispositivo", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(20, 38), AutoSize = true };

            Panel optCat = GenerarCajaOpcion("Català", "Català", 190, false);
            Panel optEsp = GenerarCajaOpcion("Castellano", "Español", 190, true);
            Panel optEng = GenerarCajaOpcion("English", "English", 190, false);

            optCat.Location = new Point(20, 72);
            optEsp.Location = new Point(225, 72);
            optEng.Location = new Point(430, 72);

            Panel banner = new Panel { Size = new Size(600, 45), BackColor = Color.FromArgb(235, 243, 255), Location = new Point(20, 155) };
            Label lblB = new Label { Text = "✔  Castellano\n     El idioma de navegación se ha actualizado.", Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(45, 110, 253), Location = new Point(10, 5), AutoSize = true };
            banner.Controls.Add(lblB);

            card.Controls.AddRange(new Control[] { lblT, lblS, optCat, optEsp, optEng, banner });
            panelContentArea.Controls.Add(card);
        }

        private void CambiarPestañaNotificaciones()
        {
            PintarBotonActivo(btnTabNotif);
            panelContentArea.Controls.Clear();

            Panel card = new Panel { Size = new Size(680, 230), BackColor = Color.White, Location = new Point(0, 0) };
            Label lblT = new Label { Text = "Notificaciones", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(20, 15), AutoSize = true };
            Label lblS = new Label { Text = "Elige qué actualizaciones quieres recibir", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(20, 38), AutoSize = true };

            Panel row1 = GenerarFilaInterruptor("Tareas asignadas", "Cuando alguien te asigne una nueva tarea", true, 72);
            Panel row2 = GenerarFilaInterruptor("Fechas límite", "Recordatorios de tareas próximas a vencer", true, 122);
            Panel row3 = GenerarFilaInterruptor("Actualizaciones de proyecto", "Cambios importantes en tus proyectos", false, 172);

            card.Controls.AddRange(new Control[] { lblT, lblS, row1, row2, row3 });
            panelContentArea.Controls.Add(card);
        }

        private void CambiarPestañaPreferencias()
        {
            PintarBotonActivo(btnTabPref);
            panelContentArea.Controls.Clear();

            Panel card = new Panel { Size = new Size(680, 230), BackColor = Color.White, Location = new Point(0, 0) };
            Label lblT = new Label { Text = "Preferencias", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(20, 15), AutoSize = true };
            Label lblS = new Label { Text = "Personaliza el comportamiento de la aplicación", Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(20, 38), AutoSize = true };

            Panel row1 = GenerarFilaInterruptor("Vista compacta", "Reduce el espacio entre filas y tarjetas", false, 72);
            Panel row2 = GenerarFilaInterruptor("La semana empieza en lunes", "Se aplica a calendarios y fechas límite", true, 122);

            Label lblD = new Label { Text = "Densidad de la interfaz", Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(20, 172), AutoSize = true };
            Button btnCom = new Button { Text = "Cómoda", BackColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(80, 28), Location = new Point(480, 168) };
            Button btnCmp = new Button { Text = "Compacta", BackColor = Color.FromArgb(240, 242, 245), FlatStyle = FlatStyle.Flat, Size = new Size(80, 28), Location = new Point(565, 168) };

            card.Controls.AddRange(new Control[] { lblT, lblS, row1, row2, lblD, btnCom, btnCmp });
            panelContentArea.Controls.Add(card);
        }

        private void PintarBotonActivo(Button btnActivo)
        {
            Button[] botones = { btnTabPerfil, btnTabIdioma, btnTabNotif, btnTabPref };
            foreach (var b in botones)
            {
                if (b != null)
                {
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.DimGray;
                    b.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
            }
            if (btnActivo != null)
            {
                btnActivo.BackColor = Color.FromArgb(230, 240, 255);
                btnActivo.ForeColor = Color.FromArgb(45, 110, 253);
                btnActivo.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private Panel GenerarCajaOpcion(string titulo, string sub, int width, bool seleccionado)
        {
            Panel p = new Panel { Size = new Size(width, 62), BackColor = seleccionado ? Color.FromArgb(235, 243, 255) : Color.White };
            Label l1 = new Label { Text = titulo, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(10, 10), AutoSize = true };
            Label l2 = new Label { Text = sub, Font = new Font("Segoe UI", 8, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(10, 30), AutoSize = true };
            CheckBox radio = new CheckBox { Checked = seleccionado, Location = new Point(width - 28, 18), AutoSize = true };
            p.Controls.AddRange(new Control[] { l1, l2, radio });
            return p;
        }

        private Panel GenerarFilaInterruptor(string titulo, string sub, bool activo, int top)
        {
            Panel p = new Panel { Size = new Size(640, 38), Location = new Point(20, top) };
            Label l1 = new Label { Text = titulo, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(0, 2), AutoSize = true };
            Label l2 = new Label { Text = sub, Font = new Font("Segoe UI", 8f), ForeColor = Color.Gray, Location = new Point(0, 18), AutoSize = true };
            CheckBox sw = new CheckBox { Checked = activo, Text = activo ? "ON" : "OFF", Location = new Point(560, 6), AutoSize = true };
            p.Controls.AddRange(new Control[] { l1, l2, sw });
            return p;
        }
    }
}