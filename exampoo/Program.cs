using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>
        {
            new Producto("Laptop HP", 899.99, 10, "HP"),
            new Producto("Smartphone Samsung", 599.99, 15, "Samsung"),
            new Producto("Auriculares Bluetooth", 79.99, 20, "Sony")
        };

            // Ingresar más productos desde la consola
            Console.WriteLine("Ingrese el número de productos a registrar:");
            int cantidadProductos = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadProductos; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");
                Console.Write("Nombre: ");
                string nombreProducto = Console.ReadLine();
                Console.Write("Precio: ");
                double precioProducto = double.Parse(Console.ReadLine());
                Console.Write("Cantidad: ");
                int cantidadProducto = int.Parse(Console.ReadLine());
                Console.Write("Marca: ");
                string marcaProducto = Console.ReadLine();

                productos.Add(new Producto(nombreProducto, precioProducto, cantidadProducto, marcaProducto));
            }

            // Mostrar productos
            Console.WriteLine("\n--- Productos disponibles ---");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }

            // Crear cliente y realizar compras
            Console.WriteLine("\nIngrese la información del cliente:");
            Console.Write("Nombre: ");
            string nombreCliente = Console.ReadLine();
            Console.Write("Email: ");
            string emailCliente = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefonoCliente = Console.ReadLine();
            Cliente cliente = new Cliente(nombreCliente, emailCliente, telefonoCliente);

            // Realizar compras
            Console.WriteLine("\nIngrese el número de compras que desea realizar:");
            int cantidadCompras = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadCompras; i++)
            {
                Console.WriteLine($"\nCompra {i + 1}:");
                Console.Write("Producto a comprar (nombre exacto): ");
                string nombreCompra = Console.ReadLine();
                Producto productoCompra = productos.Find(p => p.Nombre.Equals(nombreCompra, StringComparison.OrdinalIgnoreCase));

                if (productoCompra != null)
                {
                    Console.Write("Cantidad: ");
                    int cantidadCompra = int.Parse(Console.ReadLine());
                    cliente.RegistrarCompra(productoCompra, cantidadCompra);
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }

            // Mostrar cliente y sus compras
            Console.WriteLine("\n--- Información del Cliente ---");
            Console.WriteLine(cliente);
            Console.WriteLine("Compras realizadas:");
            int iCompra = 1;
            foreach (var compra in cliente.ComprasRealizadas)
            {
                Console.WriteLine($"{iCompra}. {compra.ProductoNombre} - {compra.Cantidad} unidades - Total: ${compra.Total:F2}");
                iCompra++;
            }

            // Crear empleados
            List<Empleado> empleados = new List<Empleado>();
            Console.WriteLine("\nIngrese el número de empleados:");
            int cantidadEmpleados = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadEmpleados; i++)
            {
                Console.WriteLine($"\nEmpleado {i + 1}:");
                Console.Write("Nombre: ");
                string nombreEmpleado = Console.ReadLine();
                Console.Write("Email: ");
                string emailEmpleado = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefonoEmpleado = Console.ReadLine();
                Console.Write("Cargo: ");
                string cargoEmpleado = Console.ReadLine();
                Console.Write("Salario base: ");
                double salarioBase = double.Parse(Console.ReadLine());

                if (cargoEmpleado.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Bono de gerente: ");
                    double bonoGerente = double.Parse(Console.ReadLine());
                    empleados.Add(new Gerente(nombreEmpleado, emailEmpleado, telefonoEmpleado, salarioBase, bonoGerente));
                }
                else
                {
                    empleados.Add(new Empleado(nombreEmpleado, emailEmpleado, telefonoEmpleado, cargoEmpleado, salarioBase));
                }
            }

            // Mostrar empleados y sus salarios
            Console.WriteLine("\n--- Información de Empleados ---");
            foreach (var emp in empleados)
            {
                Console.WriteLine(emp);
            }

            // Usando polimorfismo para procesar una lista de empleados
            Console.WriteLine("\n--- Demostración de Polimorfismo ---");
            foreach (var emp in empleados)
            {
                Console.WriteLine($"{emp.Nombre} ({emp.Cargo}): Salario total ${emp.CalcularSalarioTotal():F2}");
            }

            // Mostrar productos actualizados después de las compras
            Console.WriteLine("\n--- Productos después de las compras ---");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }

            Console.ReadLine();
        }
    }
}

    


    

