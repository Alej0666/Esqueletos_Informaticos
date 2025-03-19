using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
        public class Empleado : Persona
        {
            protected string cargo;
            protected double salario;

            public Empleado(string nombre, string correo, string telefono, string cargo, double salario)
                : base(nombre, correo, telefono)
            {
                this.cargo = cargo;
                this.salario = salario;
            }

            public string Cargo
            {
                get { return cargo; }
                set { cargo = value; }
            }

            public double Salario
            {
                get { return salario; }
                set
                {
                    if (value >= 0)
                        salario = value;
                    else
                        Console.WriteLine("Error: El salario no puede ser negativo");
                }
            }
            public virtual double CalcularSalarioTotal()
            {
                return salario;
            }
            public override string ToString()
            {
                return $"{base.ToString()}, Cargo: {cargo}, Salario: ${CalcularSalarioTotal()}";
            }
        }
    }

