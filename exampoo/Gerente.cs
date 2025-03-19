using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
        public class Gerente : Empleado
        {
            private double bonoAnual;

            public Gerente(string nombre, string correo, string telefono, double salario, double bonoAnual)
                : base(nombre, correo, telefono, "Gerente", salario)
            {
                this.bonoAnual = bonoAnual;
            }

            public double BonoAnual
            {
                get { return bonoAnual; }
                set
                {
                    if (value >= 0)
                        bonoAnual = value;
                    else
                        Console.WriteLine("Error: El bono anual no puede ser negativo");
                }
            }

            public override double CalcularSalarioTotal()
            {
                return salario + bonoAnual;
            }

            public override string ToString()
            {
                return $"{base.ToString()}, Bono Anual: ${bonoAnual}";
            }
        }
    }


