using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tarea3POO2
{
    public class FrmLogin : Form
    {
        TextBox txtUsuario = new TextBox();
        TextBox txtClave = new TextBox();
        Label lblIntentos = new Label();
        int intentos = 0;
        Conexion conexion = new Conexion();

        public FrmLogin()
        {
            Text = "Tarea3POO2 - Iniciar sesión";
            Size = new Size(370, 290);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label titulo = new Label() { Text = "INICIO DE SESIÓN", Location = new Point(105, 25), AutoSize = true };
            Label usuario = new Label() { Text = "Usuario:", Location = new Point(35, 75), AutoSize = true };
            Label clave = new Label() { Text = "Contraseña:", Location = new Point(35, 115), AutoSize = true };
            txtUsuario.SetBounds(130, 72, 185, 25);
            txtClave.SetBounds(130, 112, 185, 25);
            txtClave.UseSystemPasswordChar = true;
            Button btnIngresar = new Button() { Text = "Ingresar", Location = new Point(125, 160), Width = 110 };
            lblIntentos.Text = "Intentos disponibles: 3";
            lblIntentos.SetBounds(110, 205, 210, 25);
            btnIngresar.Click += BtnIngresar_Click;
            AcceptButton = btnIngresar;
            Controls.AddRange(new Control[] { titulo, usuario, clave, txtUsuario, txtClave, btnIngresar, lblIntentos });
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.ValidarUsuario(txtUsuario.Text.Trim(), txtClave.Text))
                {
                    Hide();
                    using (FrmPrincipal principal = new FrmPrincipal())
                    {
                        principal.ShowDialog();
                    }
                    Close();
                }
                else
                {
                    intentos++;
                    if (intentos == 3)
                    {
                        MessageBox.Show("Superó los 3 intentos. El programa se cerrará.");
                        Close();
                        return;
                    }
                    lblIntentos.Text = "Intentos disponibles: " + (3 - intentos);
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }
    }
}
