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
           
        }

        private void dgvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
       
        


       


        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
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
