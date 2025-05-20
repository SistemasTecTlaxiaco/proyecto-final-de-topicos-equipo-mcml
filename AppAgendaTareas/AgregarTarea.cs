using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAgendaTareas
{
    public partial class AgregarTarea : Form 
    {
        // Objeto para ejecutar operaciones con la BD
        private Tarea mTarea; // Objeto modelo de tarea que se usa temporalmente
        private List<Tarea> mTareas; // Lista para almacenar tareas obtenidas de la BD


        public AgregarTarea()
        {
            InitializeComponent();  // Inicializa los controles del formulario
            mTareaConsultas = new TareaConsultas(); // Crea instancia para acceder a la BD
            mTarea = new Tarea(); // Inicializa una tarea vacía
            mTareas = new List<Tarea>(); // Inicializa lista vacía

            CargarTareas(); // Llama al método para mostrar las tareas al iniciar


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatosTarea(); // Llama al método que limpia los campos del formulario

        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarTareas(textBox1.Text.Trim()); // Carga tareas filtradas por texto

        }

        private void dgvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que se haga clic en una fila válida
            {
                DataGridViewRow fila = dgvTareas.Rows[e.RowIndex]; // Obtiene la fila clickeada
                txtIdUsuario.Text = Convert.ToString(fila.Cells["ID"].Value); // Carga ID
                txtTitulo.Text = Convert.ToString(fila.Cells["Titulo"].Value); // Carga Título
                txtDescripcion.Text = Convert.ToString(fila.Cells["Descripcion"].Value); // Carga Descripción
                dtpFechaVencimiento.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value); // Carga Fecha
                cmbCategoria.SelectedItem = Convert.ToString(fila.Cells["Categoria"].Value); // Carga Categoría
                cmbPrioridad.SelectedItem = Convert.ToString(fila.Cells["Prioridad"].Value); // Carga Prioridad
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!DatosCorrectos()) // Verifica que los datos estén completos
                return;

            CargarDatosTarea(); // Carga los datos del formulario al objeto tarea

            if (mTareaConsultas.agregarTarea(mTarea)) // Intenta insertar la tarea
            {
                MessageBox.Show("Tarea agregada correctamente."); // Mensaje de éxito
                CargarTareas(); // Refresca la tabla
                LimpiarDatosTarea(); // Limpia el formulario
            }
            else
                MessageBox.Show("Error al agregar la tarea."); // Mensaje de error

        }






        private void LimpiarDatosTarea()
        {
            txtIdUsuario.Text = ""; // Borra ID
            txtTitulo.Text = ""; // Borra título
            txtDescripcion.Text = ""; // Borra descripción
            cmbCategoria.SelectedIndex = -1; // Deselecciona categoría
            cmbPrioridad.SelectedIndex = -1; // Deselecciona prioridad
            dtpFechaVencimiento.Value = DateTime.Now; // Fecha actual
        }

        private int ObtenerIdUsuario()
        {
            if (!txtIdUsuario.Text.Trim().Equals("")) // Si no está vacío
            {
                if (int.TryParse(txtIdUsuario.Text.Trim(), out int id)) // Si es número válido
                    return id;
                else
                    return -1; // No válido
            }
            else
                return -1; // Vacío
        }








        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación completa

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
        }


        private void AgregarTarea_Load(object sender, EventArgs e)
        {
            
        }

        private void txtIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
