namespace Project01
{
    public class Ejercicio03
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine(" EJERCICIO 3: CONTROL DEASISTENCIA A TALLER ");

            string[] participantes = { "Ana", "Palencia", "Dulce", "Maria", "Yamileth", "Jheferson", "Cesia", "Rovin", "Ernesto", "Jesus" };
            bool[] asistencias = { true, false, true, true, false, true, true, false, true, true };

            Console.WriteLine("\n1. Lista de participantes:");
            for (int i = 0; i < participantes.Length; i++)
            {
                string estado = asistencias[i] ? "Asistió" : "Faltó";
                Console.WriteLine($"- {participantes[i]}: {estado}");
            }

            int countAsistieron = 0, countFaltaron = 0;
            for (int i = 0; i < asistencias.Length; i++)
            {
                if (asistencias[i]) countAsistieron++;
                else countFaltaron++;
            }

            Console.WriteLine($"\nAsistieron: {countAsistieron} | Faltaron: {countFaltaron}");
            double porcentaje = ((double)countAsistieron / participantes.Length) * 100;
            Console.WriteLine($"Porcentaje de asistencia: {porcentaje:F2}%");

            Console.WriteLine("\n2. Nombres de quienes faltaron (foreach):");
            int faltantesCount = 0;
            foreach (bool a in asistencias) if (!a) faltantesCount++;
            
            string[] nombresFaltantes = new string[faltantesCount];
            int idx = 0;
            for (int i = 0; i < participantes.Length; i++)
            {
                if (!asistencias[i]) { nombresFaltantes[idx] = participantes[i]; idx++; }
            }
            foreach (string nombre in nombresFaltantes)
            {
                Console.WriteLine($"- {nombre}");
            }

            Console.Write("\nIngrese nombre a buscar: ");
            string buscado = Console.ReadLine() ?? "";
            while (string.IsNullOrWhiteSpace(buscado))
            {
                Console.Write("El nombre no puede estar vacío: ");
                buscado = Console.ReadLine() ?? "";
            }

            bool encontrado = false;
            int pos = -1;
            bool asistio = false;
            for (int i = 0; i < participantes.Length; i++)
            {
                if (participantes[i].Equals(buscado, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    pos = i + 1;
                    asistio = asistencias[i];
                    break;
                }
            }

            if (encontrado)
            {
                string est = asistio ? "Sí asistió" : "Faltó";
                Console.WriteLine($"Encontrado en posición {pos}. Estado: {est}");
            }
            else
            {
                Console.WriteLine("No se encontró el participante.");
            }

            Console.WriteLine("\n3. Nombres en orden inverso:");
            for (int i = participantes.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"- {participantes[i]}");
            }
        }
    }
}