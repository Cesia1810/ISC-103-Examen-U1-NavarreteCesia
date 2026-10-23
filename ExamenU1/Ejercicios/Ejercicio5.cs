using System;
using System.Collections.Generic;

namespace Project01
{
    public class Ejercicio05
    {
        public static void Ejecutar()
        {
            List<string> productos = new List<string>();
            List<int> existencias = new List<int>();
            List<decimal> precios = new List<decimal>();
            int opcion = 0;

            while (opcion != 6)
            {
                Console.Clear();
                Console.WriteLine(" EJERCICIO 5: INVENTARIO DE PAPELERÍA ");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Vender producto");
                Console.WriteLine("3. Abastecer producto");
                Console.WriteLine("4. Mostrar inventario");
                Console.WriteLine("5. Mostrar alertas");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Nombre del producto: ");
                            string nom = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(nom))
                            {
                                Console.Write("El nombre no puede estar vacío: ");
                                nom = Console.ReadLine() ?? "";
                            }
                            if (productos.Contains(nom))
                            {
                                Console.WriteLine("El producto ya existe.");
                            }
                            else
                            {
                                int ex = -1;
                                while (ex < 0)
                                {
                                    Console.Write("Existencia inicial (>= 0): ");
                                    int.TryParse(Console.ReadLine(), out ex);
                                }
                                decimal pr = -1;
                                while (pr <= 0)
                                {
                                    Console.Write("Precio unitario (> 0): ");
                                    decimal.TryParse(Console.ReadLine(), out pr);
                                }
                                productos.Add(nom);
                                existencias.Add(ex);
                                precios.Add(pr);
                                Console.WriteLine("¡Registrado con éxito!");
                            }
                            break;

                        case 2:
                            Console.Write("Producto a vender: ");
                            string pV = Console.ReadLine() ?? "";
                            if (productos.Contains(pV))
                            {
                                int iV = productos.IndexOf(pV);
                                Console.Write("Cantidad a vender: ");
                                int.TryParse(Console.ReadLine(), out int cantV);
                                if (cantV > 0 && existencias[iV] >= cantV)
                                {
                                    existencias[iV] -= cantV;
                                    decimal totalV = cantV * precios[iV];
                                    Console.WriteLine($"Venta exitosa. Total: {totalV:C2}");
                                }
                                else
                                {
                                    Console.WriteLine($"Stock insuficiente. Disponible: {existencias[iV]}");
                                }
                            }
                            else { Console.WriteLine("El producto no existe."); }
                            break;

                        case 3:
                            Console.Write("Producto a abastecer: ");
                            string pA = Console.ReadLine() ?? "";
                            if (productos.Contains(pA))
                            {
                                int iA = productos.IndexOf(pA);
                                Console.Write("Cantidad a agregar: ");
                                int.TryParse(Console.ReadLine(), out int cantA);
                                if (cantA > 0)
                                {
                                    existencias[iA] += cantA;
                                    Console.WriteLine($"Abastecido. Nueva existencia: {existencias[iA]}");
                                }
                            }
                            else { Console.WriteLine("El producto no existe."); }
                            break;

                        case 4:
                            decimal valorTotalInv = 0;
                            for (int i = 0; i < productos.Count; i++)
                            {
                                decimal vItem = existencias[i] * precios[i];
                                valorTotalInv += vItem;
                                Console.WriteLine($"{productos[i]} | Stock: {existencias[i]} | Precio: {precios[i]:C2} | Total: {vItem:C2}");
                            }
                            Console.WriteLine($"VALOR TOTAL INVENTARIO: {valorTotalInv:C2}");
                            break;

                        case 5:
                            Console.WriteLine("\n--- ALERTAS (Stock <= 5) ---");
                            for (int i = 0; i < productos.Count; i++)
                            {
                                if (existencias[i] <= 5) Console.WriteLine($"- {productos[i]} (Stock: {existencias[i]})");
                            }
                            decimal mayorVal = -1;
                            string mayorProd = "";
                            for (int i = 0; i < productos.Count; i++)
                            {
                                decimal vItem = existencias[i] * precios[i];
                                if (vItem > mayorVal) { mayorVal = vItem; mayorProd = productos[i]; }
                            }
                            Console.WriteLine($"Mayor valor en inventario: {mayorProd} ({mayorVal:C2})");
                            break;

                        case 6:
                            Console.WriteLine("Regresando...");
                            break;
                    }
                }
                if (opcion != 6) { Console.WriteLine("\nPresione una tecla para continuar..."); Console.ReadKey(); }
            }
        }
    }
}  