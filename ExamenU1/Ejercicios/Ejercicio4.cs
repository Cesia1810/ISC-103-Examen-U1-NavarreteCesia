namespace Project01
{
    public class Ejercicio04
    {
        public static void Ejecutar()
        {
            List<string> urgentes = new List<string>();
            List<string> normales = new List<string>();
            int opcion = 0;

            while (opcion != 6)
            {
                Console.Clear();
                Console.WriteLine(" EJERCICIO 4: FILA DE ATENCIÓN EN UNA CLÍNICA");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Atender siguiente");
                Console.WriteLine("3. Mostrar fila");
                Console.WriteLine("4. Buscar paciente");
                Console.WriteLine("5. Mostrar cantidad");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Nombre del paciente: ");
                            string nombre = Console.ReadLine() ?? "";
                            while (string.IsNullOrWhiteSpace(nombre))
                            {
                                Console.Write("El nombre no puede estar vacío: ");
                                nombre = Console.ReadLine() ?? "";
                            }
                            if (urgentes.Contains(nombre) || normales.Contains(nombre))
                            {
                                Console.WriteLine("El paciente ya está registrado.");
                            }
                            else
                            {
                                int prio = 0;
                                while (prio != 1 && prio != 2)
                                {
                                    Console.Write("Prioridad (1 = urgente, 2 = normal): ");
                                    int.TryParse(Console.ReadLine(), out prio);
                                }
                                if (prio == 1) { urgentes.Add(nombre); Console.WriteLine("Registrado como Urgente."); }
                                else { normales.Add(nombre); Console.WriteLine("Registrado como Normal."); }
                            }
                            break;

                        case 2:
                            if (urgentes.Count > 0)
                            {
                                string a = urgentes[0];
                                urgentes.RemoveAt(0);
                                Console.WriteLine($"Atendiendo URGENTE: {a}");
                            }
                            else if (normales.Count > 0)
                            {
                                string a = normales[0];
                                normales.RemoveAt(0);
                                Console.WriteLine($"Atendiendo NORMAL: {a}");
                            }
                            else
                            {
                                Console.WriteLine("No hay pacientes en espera.");
                            }
                            break;

                        case 3:
                            Console.WriteLine("\n--- URGENTES ---");
                            for (int i = 0; i < urgentes.Count; i++) Console.WriteLine($"{i + 1}. {urgentes[i]}");
                            Console.WriteLine("\n--- NORMALES ---");
                            for (int i = 0; i < normales.Count; i++) Console.WriteLine($"{i + 1}. {normales[i]}");
                            Console.WriteLine($"Total espera: {urgentes.Count + normales.Count}");
                            break;

                        case 4:
                            Console.Write("Nombre a buscar: ");
                            string bus = Console.ReadLine() ?? "";
                            if (urgentes.Contains(bus))
                            {
                                int idx = urgentes.IndexOf(bus);
                                Console.WriteLine($"Fila Urgente, posición {idx + 1}. Delante: {idx}");
                            }
                            else if (normales.Contains(bus))
                            {
                                int idx = normales.IndexOf(bus);
                                int delante = urgentes.Count + idx;
                                Console.WriteLine($"Fila Normal, posición {idx + 1}. Delante: {delante}");
                            }
                            else
                            {
                                Console.WriteLine("Paciente no encontrado.");
                            }
                            break;

                        case 5:
                            Console.WriteLine($"Urgentes: {urgentes.Count} | Normales: {normales.Count} | Total: {urgentes.Count + normales.Count}");
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