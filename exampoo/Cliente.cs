using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
        public class Compra
        {
            public string ProductoNombre { get; set; }
            public int Cantidad { get; set; }
            public double PrecioUnitario { get; set; }
            public double Total { get; set; }
        }

        public class Cliente : Persona
        {
            private List<Compra> comprasRealizadas;

            public Cliente(string nombre, string correo, string telefono)
                : base(nombre, correo, telefono)
            {
                comprasRealizadas = new List<Compra>();
            }

            public List<Compra> ComprasRealizadas
            {
                get { return comprasRealizadas; }
            }

            public bool RegistrarCompra(Producto producto, int cantidad)
            {
                if (producto.Stock >= cantidad)
                {
                    Compra compra = new Compra
                    {
                        ProductoNombre = producto.Nombre,
                        Cantidad = cantidad,
                        PrecioUnitario = producto.Precio,
                        Total = producto.Precio * cantidad
                    };

                    comprasRealizadas.Add(compra);
                    producto.Stock -= cantidad;
                    Console.WriteLine($"Compra registrada: {cantidad} unidades de {producto.Nombre}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: Stock insuficiente de {producto.Nombre}");
                    return false;
                }
            }

            public double TotalCompras()
            {
                double total = 0;
                foreach (var compra in comprasRealizadas)
                {
                    total += compra.Total;
                }
                return total;
            }

            public override string ToString()
            {
                return $"{base.ToString()}, Total de compras: ${TotalCompras()}";
            }
        }
    }


