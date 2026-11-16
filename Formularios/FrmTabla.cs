using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tarea3POO2
{
    // Este formulario se utiliza para mostrar los datos de cada tabla.
    public class FrmTabla : Form
    {
        string nombreTabla;
        DataGridView dgvDatos = new DataGridView();
        Conexion conexion = new Conexion();

        public FrmTabla(string tabla, string titulo)
        {
            nombreTabla = tabla;
            Text = "Tarea3POO2 - " + titulo;
            Size = new Size(900, 510);
            StartPosition = FormStartPosition.CenterParent;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Tabla: " + tabla;
            lblTitulo.SetBounds(20, 15, 400, 25);

            Button btnActualizar = new Button();
            btnActualizar.Text = "Actualizar";
            btnActualizar.SetBounds(750, 12, 110, 30);
            btnActualizar.Click += (s, e) => CargarDatos();

            dgvDatos.SetBounds(20, 55, 840, 385);
            dgvDatos.ReadOnly = true;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            Controls.Add(lblTitulo);
            Controls.Add(btnActualizar);
            Controls.Add(dgvDatos);
            Load += (s, e) => CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // El nombre de la tabla viene del menú, no lo escribe el usuario.
                dgvDatos.DataSource = conexion.Consultar("SELECT * FROM dbo.[" + nombreTabla + "]");
                foreach (DataGridViewColumn columna in dgvDatos.Columns)
                {
                    if (columna.ValueType == typeof(byte[]))
                        columna.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message);
            }
        }
    }
}
