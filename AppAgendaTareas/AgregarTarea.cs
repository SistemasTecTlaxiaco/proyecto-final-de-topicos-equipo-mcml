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

        private TareaConsultas mTareaConsultas; // Objeto para ejecutar operaciones con la BD
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
        private bool DatosCorrectos()
        {
            if (txtTitulo.Text.Trim().Equals("")) // Título vacío
            {
                MessageBox.Show("Ingrese el título de la tarea.");
                return false;
            }

            if (cmbCategoria.SelectedItem == null) // Categoría no seleccionada
            {
                MessageBox.Show("Seleccione una categoría.");
                return false;
            }

            if (cmbPrioridad.SelectedItem == null) // Prioridad no seleccionada
            {
                MessageBox.Show("Seleccione una prioridad.");
                return false;
            }

            return true; // Todo correcto
        }

        private void CargarDatosTarea()
        {
            mTarea.id = ObtenerIdUsuario(); // Obtiene el ID de la tarea
            mTarea.titulo = txtTitulo.Text.Trim(); // Título
            mTarea.descripcion = txtDescripcion.Text.Trim(); // Descripción
            mTarea.fecha_vencimiento = dtpFechaVencimiento.Value; // Fecha de vencimiento
            mTarea.categoria = cmbCategoria.SelectedItem.ToString(); // Categoría
            mTarea.prioridad = cmbPrioridad.SelectedItem.ToString(); // Prioridad
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

        private void CargarTareas(string filtro = "")
        {
            dgvTareas.Rows.Clear(); // Limpia las filas del grid
            dgvTareas.Refresh(); // Refresca visualmente
            mTareas.Clear(); // Limpia la lista interna
            mTareas = mTareaConsultas.consultarTareas(filtro); // Consulta a la BD

            foreach (var tarea in mTareas) // Llena cada fila con una tarea
            {
                dgvTareas.Rows.Add(
                    tarea.id,
                    tarea.titulo,
                    tarea.descripcion,
                    tarea.fecha_vencimiento.ToShortDateString(),
                    tarea.categoria,
                    tarea.prioridad
                );
            }
        }







        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!DatosCorrectos())
                return;

            CargarDatosTarea();

            if (mTareaConsultas.modificarTarea(mTarea))
            {
                MessageBox.Show("Tarea modificada correctamente.");
                CargarTareas();
                LimpiarDatosTarea();
            }
            else
                MessageBox.Show("Error al modificar la tarea.");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ObtenerIdUsuario(); // Obtiene el ID
            if (id == -1)
            {
                MessageBox.Show("ID de tarea no válido.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar la tarea?", "Eliminar tarea", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (mTareaConsultas.eliminarTarea(id))
                {
                    MessageBox.Show("Tarea eliminada.");
                    CargarTareas();
                    LimpiarDatosTarea();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la tarea.");
                }
            }

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
            this.CenterToScreen(); // Centra el formulario en pantalla

            // Cargar categorías en el ComboBox
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Trabajo");
            cmbCategoria.Items.Add("Escuela");
            cmbCategoria.Items.Add("Personal");
            cmbCategoria.Items.Add("Salud");
            cmbCategoria.Items.Add("Otro");

            // Cargar prioridades
            cmbPrioridad.Items.Clear();
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Media");
            cmbPrioridad.Items.Add("Baja");

            // No seleccionar por defecto
            cmbCategoria.SelectedIndex = -1;
            cmbPrioridad.SelectedIndex = -1;


        }

        private void txtIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
