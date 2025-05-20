using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AppAgendaTareas
{
    // Clase que hereda de 'Conexion' y se encarga de abrir la conexión a MySQL
    internal class ConexionMySql : Conexion
    {
        // Objeto de conexión de MySQL.
        private MySqlConnection conexion;

        // Cadena de conexión construida con los datos heredados de la clase base.
        private string cadenaConexion;

        // Constructor de la clase 'ConexionMySql'.
        public ConexionMySql()
        {
            // Se construye la cadena de conexión utilizando los datos protegidos de la clase base.
            cadenaConexion = "Database=" + database +
                          "; DataSource=" + server +
                          "; Port=" + port +
                          "; User Id=" + user +
                          "; Password=" + password;

        }
        // Método que devuelve una conexión abierta a la base de datos.
        public MySqlConnection getConexion()
        {
            try
            {
                // Si la conexión aún no ha sido creada, se instancia con la cadena de conexión.
                if (conexion == null)
                {
                    conexion = new MySqlConnection(cadenaConexion);
                }
                // Si la conexión existe pero no está abierta, se abre.
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
            }

    }
    }
}

