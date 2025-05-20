using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppAgendaTareas
{
    public partial class Login : Form
    {
        private LoginConsultas mLoginConsultas;
            

        public Login()
        {
            InitializeComponent();
            // Crea una nueva instancia de la clase LoginConsultas, que se encargará de validar al usuario en la base de datos.
            mLoginConsultas = new LoginConsultas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            //txtUsuario.BackColor = Color.Yellow;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                // Evento que se ejecuta cuando el usuario hace clic en el botón "Guardar" (Iniciar sesión).

                string usuario = txtUsuario.Text.Trim();
                // Obtiene el texto ingresado en el TextBox de usuario y elimina espacios al principio y al final.

                string contraseña = txtContrasena.Text.Trim();
                // Obtiene el texto ingresado en el TextBox de contraseña y elimina espacios al principio y al final.

                if (usuario == "" || contraseña == "")
                {
                    // Verifica si alguno de los campos está vacío.

                    MessageBox.Show("Ingrese usuario y contraseña.");
                    // Muestra un mensaje de advertencia si algún campo está vacío.

                    return;
                    // Termina la ejecución del evento para evitar continuar con la validación.
                }
            }
            Usuario user = mLoginConsultas.ValidarLogin(usuario, contraseña);
            // Llama al método ValidarLogin de la clase LoginConsultas para validar los datos ingresados con la base de datos.

            if (user != null)
            {
                // Si el método retorna un usuario (es decir, los datos son correctos)...

                MessageBox.Show("Bienvenido " + user.usuario);
                // Muestra un mensaje de bienvenida con el nombre del usuario.

                // Puedes pasar el ID del usuario al formulario de tareas si lo necesitas
                AgregarTarea frm = new AgregarTarea();
                // Crea una nueva instancia del formulario de tareas (AgregarTarea).

                frm.Show();
                // Muestra el formulario de tareas.

                this.Hide();
                // Oculta el formulario de login.
            }
            else
            {
                // Si no se encontró el usuario en la base de datos (datos incorrectos)...

                MessageBox.Show("Usuario o contraseña incorrectos.");
                // Muestra un mensaje de error.
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
