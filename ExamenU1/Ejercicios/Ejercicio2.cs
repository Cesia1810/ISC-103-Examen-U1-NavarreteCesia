namespace Project01
{
    public class Ejercicio02
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 2: SIMULADOR DE CARGA DE COMBUSTIBLE");

            int tipoCombustible = 0;
            while (tipoCombustible < 1 || tipoCombustible > 3)
            {
                Console.Write("Tipo de combustible (1 = regular, 2 = premium, 3 = diésel): ");
                if (!int.TryParse(Console.ReadLine(), out tipoCombustible) || tipoCombustible < 1 || tipoCombustible > 3)
                {
                    Console.WriteLine("Opción inválida.");
                }
            }

            decimal precioPorLitro = 0;
            string nombreCombustible = "";
            switch (tipoCombustible)
            {
                case 1: precioPorLitro = 28.50m; nombreCombustible = "Regular"; break;
                case 2: precioPorLitro = 32.00m; nombreCombustible = "Premium"; break;
                case 3: precioPorLitro = 26.75m; nombreCombustible = "Diésel"; break;
            }

            double litrosSolicitados = 0;
            while (litrosSolicitados <= 0 || litrosSolicitados >= 60)
            {
                Console.Write("Litros solicitados (> 0 y < 60): ");
                if (!double.TryParse(Console.ReadLine(), out litrosSolicitados) || litrosSolicitados <= 0 || litrosSolicitados >= 60)
                {
                    Console.WriteLine("Cantidad inválida.");
                }
            }

            double litrosCargados = 0;
            while (litrosCargados < litrosSolicitados)
            {
                double bloque = 5;
                if ((litrosCargados + bloque) > litrosSolicitados)
                {
                    bloque = litrosSolicitados - litrosCargados;
                }
                litrosCargados += bloque;
                Console.WriteLine($"Litros cargados hasta el momento: {litrosCargados:F2} / {litrosSolicitados:F2}");
            }

            decimal subtotal = (decimal)litrosCargados * precioPorLitro;
            decimal descuento = 0;

            if (subtotal >= 1500.00m) descuento = subtotal * 0.05m;
            else if (subtotal >= 1000.00m) descuento = subtotal * 0.02m;

            decimal totalPagar = subtotal - descuento;

            Console.WriteLine("         RESUMEN DE COMBUSTIBLE         ");
            Console.WriteLine($"Combustible: {nombreCombustible}");
            Console.WriteLine($"Total litros: {litrosCargados:F2} L");
            Console.WriteLine($"Subtotal: {subtotal:C2}");
            Console.WriteLine($"Descuento: {descuento:C2}");
            Console.WriteLine($"TOTAL A PAGAR: {totalPagar:C2}");
        }
    }
}