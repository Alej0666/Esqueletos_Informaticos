using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
        public class Producto
        {
            private string nombre;
            private double precio;
            private int stock;
            private string marca;

            public Producto(string nombre, double precio, int stock, string marca)
            {
                this.nombre = nombre;
                this.marca = marca;
                // Usar propiedades para validar valores
                Precio = precio;
                Stock = stock;
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public double Precio
            {
                get { return precio; }
                set
                {
                    if (value >= 0)
                        precio = value;
                    else
                        Console.WriteLine("Error: El precio no puede ser negativo");
                }
            }

            public int Stock
            {
                get { return stock; }
                set
                {
                    if (value >= 0)
                        stock = value;
                    else
                        Console.WriteLine("Error: El stock no puede ser negativo");
                }
            }

            public string Marca
            {
                get { return marca; }
                set { marca = value; }
            }

            public override string ToString()
            {
                return $"Producto: {nombre}, Marca: {marca}, Precio: ${precio}, Stock: {stock}";
            }
        }
    }


