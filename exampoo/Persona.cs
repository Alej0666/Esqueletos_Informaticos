using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{ 
        public class Persona
        {
            protected string nombre;
            protected string correo;
            protected string telefono;

            public Persona(string nombre, string correo, string telefono)
            {
                this.nombre = nombre;
                this.correo = correo;
                this.telefono = telefono;
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public string Correo
            {
                get { return correo; }
                set { correo = value; }
            }

            public string Telefono
            {
                get { return telefono; }
                set { telefono = value; }
            }

            public override string ToString()
            {
                return $"Nombre: {nombre}, Correo: {correo}, Teléfono: {telefono}";
            }
        }
    }


