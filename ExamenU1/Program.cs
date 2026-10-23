using System;

namespace Project01
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            while (opcion != 6)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       MENÚ PRINCIPAL - EXAMEN U1       ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Ejercicio 1: Cotizador de envíos");
                Console.WriteLine("2. Ejercicio 2: Simulador de carga de combustible");
                Console.WriteLine("3. Ejercicio 3: Control de asistencia a un taller");
                Console.WriteLine("4. Ejercicio 4: Fila de atención de una clínica");
                Console.WriteLine("5. Ejercicio 5: Inventario de una papelería");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción (1-6): ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Ejercicio01.Ejecutar();
                            break;
                        case 2:
                            Ejercicio02.Ejecutar();
                            break;
                        case 3:
                            Ejercicio03.Ejecutar();
                            break;
                        case 4:
                            Ejercicio04.Ejecutar();
                            break;
                        case 5:
                            Ejercicio05.Ejecutar();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Ingrese un número.");
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}