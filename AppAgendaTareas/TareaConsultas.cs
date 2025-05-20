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
            // Asocia los parámetros con los valores del objeto tarea.
            mCommand.Parameters.AddWithValue("@titulo", tarea.titulo);
            mCommand.Parameters.AddWithValue("@descripcion", tarea.descripcion);
            mCommand.Parameters.AddWithValue("@fecha", tarea.fecha_vencimiento);
            mCommand.Parameters.AddWithValue("@categoria", tarea.categoria);
            mCommand.Parameters.AddWithValue("@prioridad", tarea.prioridad);
            mCommand.Parameters.AddWithValue("@id", tarea.id); // Identificador de la tarea a modificar.

            // Ejecuta el comando y devuelve true si se actualizó al menos una fila.
            return mCommand.ExecuteNonQuery() > 0;

        }
        // Método para eliminar una tarea por ID.
        public bool eliminarTarea(int id)
        {
            // Cadena SQL para eliminar una tarea por su ID.
            string DELETE = "DELETE FROM tarea WHERE id = @id";

            // Prepara el comando SQL.
            MySqlCommand mCommand = new MySqlCommand(DELETE, mConexion.getConexion());

            // Asocia el parámetro con el ID recibido.
            mCommand.Parameters.AddWithValue("@id", id);

            // Ejecuta el comando y devuelve true si se eliminó al menos una fila.
            return mCommand.ExecuteNonQuery() > 0;


        }
        // Método para consultar las tareas almacenadas, con opción de aplicar un filtro.
        public List<Tarea> consultarTareas(string filtro = "")
        {
            // Cadena base de consulta SQL.
            string CONSULTA = "SELECT * FROM tarea";
            // Si se recibe un filtro, se añade cláusula WHERE para buscar coincidencias.
            if (!string.IsNullOrEmpty(filtro))
            {
                CONSULTA += $" WHERE titulo LIKE '%{filtro}%' OR categoria LIKE '%{filtro}%' OR prioridad LIKE '%{filtro}%'";

            }
            // Lista donde se almacenarán las tareas consultadas.
            List<Tarea> tareas = new List<Tarea>();

            // Prepara el comando SQL.
            MySqlCommand mCommand = new MySqlCommand(CONSULTA, mConexion.getConexion());

            // Ejecuta la consulta y obtiene un lector de resultados.
            var reader = mCommand.ExecuteReader();
            // Lee cada fila del resultado y crea un objeto Tarea.
            while (reader.Read())
            {
                Tarea tarea = new Tarea
                {
                    id = reader.GetInt32("id"),
                    titulo = reader.GetString("titulo"),
                    descripcion = reader.GetString("descripcion"),
                    fecha_vencimiento = reader.GetDateTime("fecha_vencimiento"),
                    categoria = reader.GetString("categoria"),
                    prioridad = reader.GetString("prioridad")
                };


            }
        }
}

