using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgendaTareas
{
    internal class Conexion
    {
        // Dirección del servidor MySQL
        protected string server = "localhost";
        protected string port = "3307";
        // Nombre de la base de datos a la que se conectará.
        protected string database = "agendatarea";
        protected string user = "root";
        protected string password = "maritza";
    }
}
