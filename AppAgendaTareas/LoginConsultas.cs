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
        // Método público que valida si el usuario y contraseña existen en la base de datos.
        // Retorna un objeto de tipo 'Usuario' si encuentra coincidencia, o null si no.
        public Usuario ValidarLogin(string usuario, string contraseña)
        {

            // Bloque try-catch para manejar errores que puedan ocurrir al acceder a la base de datos.
            try
            {

                // Cadena de consulta SQL con parámetros para buscar al usuario con el nombre y contraseña indicados.
                string QUERY = "SELECT * FROM login WHERE usuario = @usuario AND contraseña = @contraseña";

                // Se crea un nuevo comando MySQL usando la consulta anterior y la conexión a la base de datos.
                MySqlCommand mCommand = new MySqlCommand(QUERY, mConexion.getConexion());

                // Se agregan los valores de los parámetros a la consulta, lo que ayuda a prevenir ataques de inyección SQL.
                mCommand.Parameters.AddWithValue("@usuario", usuario);
                mCommand.Parameters.AddWithValue("@contraseña", contraseña);


                // Ejecuta la consulta y obtiene un lector de resultados (data reader).
                var reader = mCommand.ExecuteReader();

                // Se declara un objeto 'user' que se usará para almacenar el resultado si se encuentra un usuario válido.
                Usuario user = null;
                // Si el lector encontró al menos una fila que coincide...
                if (reader.Read())
                {

                    // Se crea un nuevo objeto Usuario y se asignan sus propiedades con los datos obtenidos de la base.

                    user = new Usuario
                    {
                        id = reader.GetInt32("id"),
                        usuario = reader.GetString("usuario"),
                        contraseña = reader.GetString("contraseña"),
                        correo = reader.GetString("correo")
                    };

                }


            }
            }
        

        }
    }

