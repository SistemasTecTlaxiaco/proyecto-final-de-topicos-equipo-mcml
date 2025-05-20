using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgendaTareas
{
    internal class Tarea
    {
        // Propiedad que representa el identificador único de la tarea.
        public int id { get; set; }

        // almacenar el título o nombre de la tarea.
        public string titulo { get; set; }

        //  contiene una descripción detallada de la tarea.
        public string descripcion { get; set; }

        //  indica la fecha de vencimiento o entrega de la tarea.
        public DateTime fecha_vencimiento { get; set; }

        // e representa la categoría de la tarea (por ejemplo: estudio, trabajo, personal, etc.).
        public string categoria { get; set; }

        // indica el nivel de prioridad de la tarea (por ejemplo: alta, media, baja).
        public string prioridad { get; set; }


    }
}

