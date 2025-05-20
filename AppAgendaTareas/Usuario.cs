using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgendaTareas
{
    internal class Usuario
    {// Se declara la clase 'Usuario' como 'internal', lo que significa que solo será accesible dentro del mismo ensamblado/proyecto

        public int id { get; set; }
        // Propiedad pública 'id' de tipo entero. Representa el identificador único del usuario en la base de datos.

        // Propiedad pública 'usuario' de tipo string. Guarda el nombre de usuario (username) que se utilizará para iniciar sesión o identificarse.
        public string usuario { get; set; }
      

        // Propiedad pública 'contraseña' de tipo string. Almacena la contraseña del usuario.
        public string contraseña { get; set; }
        public string correo { get; set; }
        // Propiedad pública 'correo' de tipo string. Guarda el correo electrónico del usuario, útil para contacto o recuperación de contraseña.


    }
}
