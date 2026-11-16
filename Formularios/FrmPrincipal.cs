using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tarea3POO2
{
    public class FrmPrincipal : Form
    {
        FlowLayoutPanel panel = new FlowLayoutPanel();

        public FrmPrincipal()
        {
            Text = "Tarea3POO2 - Menú principal";
            Size = new Size(650, 470);
            StartPosition = FormStartPosition.CenterScreen;
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.Padding = new Padding(15);
            Controls.Add(panel);
            AgregarBoton("Autores", () => new FrmAutores());
            AgregarBoton("Editoriales", () => new FrmEditoriales());
            AgregarBoton("Libros", () => new FrmLibros());
            AgregarBoton("Autores por libro", () => new FrmAutoresLibro());
            AgregarBoton("Tiendas", () => new FrmTiendas());
            AgregarBoton("Ventas", () => new FrmVentas());
            AgregarBoton("Regalías", () => new FrmRegalias());
            AgregarBoton("Descuentos", () => new FrmDescuentos());
            AgregarBoton("Puestos", () => new FrmPuestos());
            AgregarBoton("Información editorial", () => new FrmInfoEditorial());
            AgregarBoton("Empleados", () => new FrmEmpleados());
        }

        private void AgregarBoton(string texto, Func<Form> abrir)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Size = new Size(185, 65);
            boton.Margin = new Padding(5);
            boton.Click += (s, e) =>
            {
                using (Form formulario = abrir())
                {
                    formulario.ShowDialog(this);
                }
            };
            panel.Controls.Add(boton);
        }
    }
}
