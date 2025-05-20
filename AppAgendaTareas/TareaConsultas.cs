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

            // Prepara el comando con la conexión.
            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());

            // Asocia los parámetros con los valores del objeto tarea.
            mCommand.Parameters.AddWithValue("@titulo", tarea.titulo);
            mCommand.Parameters.AddWithValue("@descripcion", tarea.descripcion);
            mCommand.Parameters.AddWithValue("@fecha", tarea.fecha_vencimiento);
            mCommand.Parameters.AddWithValue("@categoria", tarea.categoria);
            mCommand.Parameters.AddWithValue("@prioridad", tarea.prioridad);

            // Ejecuta el comando y devuelve true si se insertó al menos una fila.
            return mCommand.ExecuteNonQuery() > 0;

        }
        // Método para modificar una tarea existente.
        public bool modificarTarea(Tarea tarea)
        {
            // Cadena SQL para actualizar una tarea según su ID.
            string UPDATE = "UPDATE tarea SET titulo=@titulo, descripcion=@descripcion, fecha_vencimiento=@fecha, " +
                "categoria=@categoria, prioridad=@prioridad WHERE id=@id";

            // Prepara el comando SQL.
            MySqlCommand mCommand = new MySqlCommand(UPDATE, mConexion.getConexion());
        }

        }
    }

