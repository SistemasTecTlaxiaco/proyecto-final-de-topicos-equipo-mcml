using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Importa la librería de MySQL para poder interactuar con una base de datos MySQL desde C#.

namespace AppAgendaTareas
{
    // Clase 'LoginConsultas' definida como 'internal' (accesible solo dentro del mismo proyecto).
    internal class LoginConsultas
    {
        // Objeto de la clase 'ConexionMySql' que se usará para abrir la conexión con la base de datos.

        private ConexionMySql mConexion;

        public LoginConsultas()
        {
            mConexion = new ConexionMySql();
            // En el constructor se inicializa la conexión llamando al constructor de la clase 'ConexionMySql'.
        }


    }
}

