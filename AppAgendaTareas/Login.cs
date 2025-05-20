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
            
            
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
