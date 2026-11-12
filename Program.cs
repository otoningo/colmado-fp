using System;

/*
Proyecto: Colmado - sistema de consola
Materia: Fundamentos de Programación (TDS-002)
Fecha: 07/11/2026
Descripción: sistema sencillo de un colmado. Muestra los productos, deja agregar
productos a la compra, enseña la factura con ITBIS y cobra calculando la devuelta.
 */

namespace Colmado
{
    class Program
    {
        // ITBIS de República Dominicana
        const double ITBIS = 0.18;

        static void Main(string[] args)
        {
            int opcion;
            int cantidadArticulos = 0; // contador de artículos en la compra
            double subtotal = 0;       // acumulador de lo que se va comprando

            Console.WriteLine("Bienvenido al Colmado");

            // el menú se repite hasta que el usuario elija 0
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Elige una opción: ");

                switch (opcion)
                {
                    case 1:
                        MostrarProductos();
                        break;

                    case 2:
                        MostrarProductos();
                        int codigo = LeerEntero("Código del producto: ");
                        double precio = ObtenerPrecio(codigo);

                        // si el precio es 0 es porque el código no existe
                        if (precio == 0)
                        {
                            Console.WriteLine("Ese código no existe.");
                        }
                        else
                        {
                            int cantidad = LeerEntero("Cantidad: ");
                            if (cantidad <= 0)
                            {
                                Console.WriteLine("La cantidad tiene que ser mayor que 0.");
                            }
                            else
                            {
                                subtotal += precio * cantidad;
                                cantidadArticulos += cantidad;
                                Console.WriteLine($"Se agregó {cantidad} x {ObtenerNombre(codigo)}.");
                            }
                        }
                        break;

                    case 3:
                        MostrarFactura(cantidadArticulos, subtotal);
                        break;

                    case 4:
                        if (subtotal == 0)
                        {
                            Console.WriteLine("No hay nada en la compra todavía.");
                        }
                        else
                        {
                            double total = subtotal + CalcularItbis(subtotal);
                            Console.WriteLine($"Total a pagar: RD${total:N2}");

                            double pago = LeerDecimal("¿Con cuánto paga? RD$");
                            // si no alcanza se le vuelve a pedir
                            while (pago < total)
                            {
                                Console.WriteLine("Ese monto no alcanza.");
                                pago = LeerDecimal("¿Con cuánto paga? RD$");
                            }

                            Console.WriteLine($"Devuelta: RD${pago - total:N2}");
                            Console.WriteLine("Gracias por su compra.");

                            // se empieza una compra nueva
                            subtotal = 0;
                            cantidadArticulos = 0;
                        }
                        break;
                     case 5:
                        // borra todo lo que se había agregado a la compra
                        subtotal = 0;
                        cantidadArticulos = 0;
                        Console.WriteLine("Compra cancelada.");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 0);
        }

        // muestra las opciones del menú principal
        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("========== MENÚ ==========");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Agregar a la compra");
            Console.WriteLine("3. Ver factura");
            Console.WriteLine("4. Pagar");
            Console.WriteLine("5. Cancelar compra");
            Console.WriteLine("0. Salir");
        }

        // muestra la lista de productos con un for, del código 1 al 6
        static void MostrarProductos()
        {
            Console.WriteLine();
            Console.WriteLine("Cód.  Producto              Precio");
            Console.WriteLine("----------------------------------");
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"{i,-6}{ObtenerNombre(i),-20}{ObtenerPrecio(i),8:N2}");
            }
        }

        // recibe el código y devuelve el nombre del producto
        static string ObtenerNombre(int codigo)
        {
            switch (codigo)
            {
                case 1: return "Arroz (libra)";
                case 2: return "Habichuelas (lata)";
                case 3: return "Salami (libra)";
                case 4: return "Huevos (unidad)";
                case 5: return "Pan de agua";
                case 6: return "Refresco 2 litros";
                default: return "";
            }
        }

        // recibe el código y devuelve el precio; devuelve 0 si el código no existe
        static double ObtenerPrecio(int codigo)
        {
            switch (codigo)
            {
                case 1: return 35;
                case 2: return 75;
                case 3: return 150;
                case 4: return 10;
                case 5: return 15;
                case 6: return 120;
                default: return 0;
            }
        }

        // calcula el ITBIS de un monto
        static double CalcularItbis(double monto)
        {
            return monto * ITBIS;
        }

        // muestra la factura con la cantidad de artículos, el subtotal, el ITBIS y el total
        static void MostrarFactura(int articulos, double subtotal)
        {
            double itbis = CalcularItbis(subtotal);
            double total = subtotal + itbis;

            Console.WriteLine();
            Console.WriteLine("========= FACTURA =========");
            Console.WriteLine($"Artículos:      {articulos,10}");
            Console.WriteLine($"Subtotal:       {subtotal,10:N2}");
            Console.WriteLine($"ITBIS (18 %):   {itbis,10:N2}");
            Console.WriteLine($"Total:          {total,10:N2}");
        }

        // pide un número entero y lo repite hasta que sea válido (TryParse)
        static int LeerEntero(string mensaje)
        {
            int numero;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Tienes que escribir un número entero.");
                Console.Write(mensaje);
            }
            return numero;
        }

        // pide un número con decimales y lo repite hasta que sea válido
        static double LeerDecimal(string mensaje)
        {
            double numero;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out numero) || numero < 0)
            {
                Console.WriteLine("Tienes que escribir un monto válido.");
                Console.Write(mensaje);
            }
            return numero;
        }
    }
}
