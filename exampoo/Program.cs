using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampoo
{
    class Program
    {
        static List<Producto> productos = new List<Producto>
        {
            new Producto("Laptop HP", 899.99, 10, "HP"),
            new Producto("Smartphone Samsung", 599.99, 15, "Samsung"),
            new Producto("Auriculares Bluetooth", 79.99, 20, "Sony")
        };

        static Cliente cliente = null;
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA DE GESTIÓN =====");
                Console.WriteLine("1. Gestionar Productos");
                Console.WriteLine("2. Gestionar Clientes");
                Console.WriteLine("3. Realizar Compras");
                Console.WriteLine("4. Gestionar Personal");
                Console.WriteLine("5. Demostración de Polimorfismo");
                Console.WriteLine("6. Ver Inventario Actual");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuProductos();
                        break;
                    case "2":
                        MenuClientes();
                        break;
                    case "3":
                        MenuCompras();
                        break;
                    case "4":
                        MenuPersonal();
                        break;
                    case "5":
                        MostrarPolimorfismo();
                        break;
                    case "6":
                        MostrarInventarioActual();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuProductos()
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.WriteLine("===== GESTIÓN DE PRODUCTOS =====");
                Console.WriteLine("1. Ver productos existentes");
                Console.WriteLine("2. Registrar nuevo producto");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarProductos();
                        break;
                    case "2":
                        RegistrarProducto();
                        break;
                    case "0":
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MostrarProductos()
        {
            Console.Clear();
            Console.WriteLine("===== PRODUCTOS DISPONIBLES =====");

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
            }
            else
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void RegistrarProducto()
        {
            Console.Clear();
            Console.WriteLine("===== REGISTRAR NUEVO PRODUCTO =====");

            try
            {
                Console.Write("Nombre: ");
                string nombreProducto = Console.ReadLine();

                double precioProducto;
                do
                {
                    Console.Write("Precio: ");
                    precioProducto = double.Parse(Console.ReadLine());
                    if (precioProducto <= 0)
                    {
                        Console.WriteLine("Error: El precio debe ser mayor que cero. Intente de nuevo.");
                    }
                } while (precioProducto <= 0);

                int cantidadProducto;
                do
                {
                    Console.Write("Cantidad: ");
                    cantidadProducto = int.Parse(Console.ReadLine());
                    if (cantidadProducto <= 0)
                    {
                        Console.WriteLine("Error: El stock debe ser mayor que cero. Intente de nuevo.");
                    }
                } while (cantidadProducto <= 0);

                Console.Write("Marca: ");
                string marcaProducto = Console.ReadLine();

                productos.Add(new Producto(nombreProducto, precioProducto, cantidadProducto, marcaProducto));
                Console.WriteLine("\nProducto registrado con éxito.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Formato inválido. Asegúrese de ingresar valores numéricos correctos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuClientes()
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.WriteLine("===== GESTIÓN DE CLIENTES =====");
                Console.WriteLine("1. Ver información del cliente actual");
                Console.WriteLine("2. Registrar nuevo cliente");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarCliente();
                        break;
                    case "2":
                        RegistrarCliente();
                        break;
                    case "0":
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MostrarCliente()
        {
            Console.Clear();
            Console.WriteLine("===== INFORMACIÓN DEL CLIENTE =====");

            if (cliente == null)
            {
                Console.WriteLine("No hay ningún cliente registrado.");
            }
            else
            {
                Console.WriteLine(cliente);

                Console.WriteLine("\nCompras realizadas:");
                if (cliente.ComprasRealizadas.Count == 0)
                {
                    Console.WriteLine("No ha realizado compras.");
                }
                else
                {
                    int iCompra = 1;
                    foreach (var compra in cliente.ComprasRealizadas)
                    {
                        Console.WriteLine($"{iCompra}. {compra.ProductoNombre} - {compra.Cantidad} unidades - Total: ${compra.Total:F2}");
                        iCompra++;
                    }
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void RegistrarCliente()
        {
            Console.Clear();
            Console.WriteLine("===== REGISTRAR NUEVO CLIENTE =====");

            Console.Write("Nombre: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Email: ");
            string emailCliente = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefonoCliente = Console.ReadLine();

            cliente = new Cliente(nombreCliente, emailCliente, telefonoCliente);
            Console.WriteLine("\nCliente registrado con éxito.");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuCompras()
        {
            Console.Clear();
            Console.WriteLine("===== REALIZAR COMPRAS =====");

            if (cliente == null)
            {
                Console.WriteLine("Error: Debe registrar un cliente antes de realizar compras.");
            }
            else if (productos.Count == 0)
            {
                Console.WriteLine("Error: No hay productos disponibles para comprar.");
            }
            else
            {
                Console.WriteLine("Productos disponibles:");
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }

                try
                {
                    Console.Write("\nProducto a comprar (nombre exacto): ");
                    string nombreCompra = Console.ReadLine();
                    Producto productoCompra = productos.Find(p => p.Nombre.Equals(nombreCompra, StringComparison.OrdinalIgnoreCase));

                    if (productoCompra != null)
                    {
                        int cantidadCompra;
                        do
                        {
                            Console.Write("Cantidad: ");
                            cantidadCompra = int.Parse(Console.ReadLine());
                            if (cantidadCompra <= 0)
                            {
                                Console.WriteLine("Error: La cantidad debe ser mayor que cero. Intente de nuevo.");
                            }
                            else if (cantidadCompra > productoCompra.Stock)
                            {
                                Console.WriteLine($"Error: Stock insuficiente. Solo hay {productoCompra.Stock} unidades disponibles.");
                            }
                        } while (cantidadCompra <= 0 || cantidadCompra > productoCompra.Stock);

                        bool resultado = cliente.RegistrarCompra(productoCompra, cantidadCompra);
                        if (resultado)
                        {
                            Console.WriteLine("\nCompra realizada con éxito.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Producto no encontrado.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Formato inválido. Asegúrese de ingresar valores numéricos correctos.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError inesperado: {ex.Message}");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MenuPersonal()
        {
            bool regresar = false;

            while (!regresar)
            {
                Console.Clear();
                Console.WriteLine("===== GESTIÓN DE PERSONAL =====");
                Console.WriteLine("1. Ver personal existente");
                Console.WriteLine("2. Registrar nuevo empleado");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarPersonal();
                        break;
                    case "2":
                        RegistrarEmpleado();
                        break;
                    case "0":
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MostrarPersonal()
        {
            Console.Clear();
            Console.WriteLine("===== INFORMACIÓN DEL PERSONAL =====");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (var emp in empleados)
                {
                    Console.WriteLine(emp);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void RegistrarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("===== REGISTRAR NUEVO EMPLEADO =====");

            try
            {
                Console.Write("Nombre: ");
                string nombreEmpleado = Console.ReadLine();

                Console.Write("Email: ");
                string emailEmpleado = Console.ReadLine();

                Console.Write("Teléfono: ");
                string telefonoEmpleado = Console.ReadLine();

                Console.Write("Cargo (escriba 'Gerente' para registrar un gerente): ");
                string cargoEmpleado = Console.ReadLine();

                double salarioBase;
                do
                {
                    Console.Write("Salario base: ");
                    salarioBase = double.Parse(Console.ReadLine());
                    if (salarioBase <= 0)
                    {
                        Console.WriteLine("Error: El salario debe ser mayor que cero. Intente de nuevo.");
                    }
                } while (salarioBase <= 0);

                if (cargoEmpleado.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
                {
                    double bonoGerente;
                    do
                    {
                        Console.Write("Bono de gerente: ");
                        bonoGerente = double.Parse(Console.ReadLine());
                        if (bonoGerente <= 0)
                        {
                            Console.WriteLine("Error: El bono debe ser mayor que cero. Intente de nuevo.");
                        }
                    } while (bonoGerente <= 0);

                    empleados.Add(new Gerente(nombreEmpleado, emailEmpleado, telefonoEmpleado, salarioBase, bonoGerente));
                    Console.WriteLine("\nGerente registrado con éxito.");
                }
                else
                {
                    empleados.Add(new Empleado(nombreEmpleado, emailEmpleado, telefonoEmpleado, cargoEmpleado, salarioBase));
                    Console.WriteLine("\nEmpleado registrado con éxito.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Formato inválido. Asegúrese de ingresar valores numéricos correctos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarPolimorfismo()
        {
            Console.Clear();
            Console.WriteLine("===== DEMOSTRACIÓN DE POLIMORFISMO =====");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para mostrar el polimorfismo.");
            }
            else
            {
                Console.WriteLine("Cálculo de salarios usando polimorfismo:");
                foreach (var emp in empleados)
                {
                    Console.WriteLine($"{emp.Nombre} ({emp.Cargo}): Salario total ${emp.CalcularSalarioTotal():F2}");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarInventarioActual()
        {
            Console.Clear();
            Console.WriteLine("===== INVENTARIO ACTUAL DESPUÉS DE COMPRAS =====");

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
            else
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto);
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
