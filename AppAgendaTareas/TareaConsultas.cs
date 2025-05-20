using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppAgendaTareas
{
    internal class TareaConsultas
    {
        private ConexionMySql mConexion; // Objeto para manejar la conexión a MySQL.
        private List<Tarea> mTareas; // Lista para almacenar tareas temporalmente (aunque no se usa en el código mostrado).



        public TareaConsultas()
        {
            mConexion = new ConexionMySql(); // Inicializa la conexión a la base de datos.
            mTareas = new List<Tarea>(); // Inicializa la lista de tareas.
        }
        // Método para agregar una nueva tarea a la base de datos.
        public bool agregarTarea(Tarea tarea)
        {
            // Cadena SQL para insertar una tarea.
            string INSERT = "INSERT INTO tarea (titulo, descripcion, fecha_vencimiento, categoria, prioridad) " +
                "VALUES (@titulo, @descripcion, @fecha, @categoria, @prioridad)";
        }

        }
    }
