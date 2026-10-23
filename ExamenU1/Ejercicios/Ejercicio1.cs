namespace Project01
{
    public class Ejercicio01
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 1: COTIZADOR DE ENVÍOS");

            int zona = 0;
            while (zona < 1 || zona > 3)
            {
                Console.Write("Ingrese la zona de destino (1 = local, 2 = departamental, 3 = nacional): ");
                if (!int.TryParse(Console.ReadLine(), out zona) || zona < 1 || zona > 3)
                {
                    Console.WriteLine("Zona inválida. Debe ser 1, 2 o 3.");
                }
            }

            decimal peso = -1;
            while (peso <= 0)
            {
                Console.Write("Ingrese el peso del paquete en kg (> 0): ");
                if (!decimal.TryParse(Console.ReadLine(), out peso) || peso <= 0)
                {
                    Console.WriteLine("Peso inválido. Debe ser mayor que cero.");
                }
            }

            int servicio = 0;
            while (servicio < 1 || servicio > 3)
            {
                Console.Write("Ingrese el tipo de servicio (1 = estándar, 2 = express, 3 = mismo día): ");
                if (!int.TryParse(Console.ReadLine(), out servicio) || servicio < 1 || servicio > 3)
                {
                    Console.WriteLine("Servicio inválido. Debe ser 1, 2 o 3.");
                }
            }

            decimal valorDeclarado = -1;
            while (valorDeclarado < 0)
            {
                Console.Write("Ingrese el valor declarado del paquete (>= 0): ");
                if (!decimal.TryParse(Console.ReadLine(), out valorDeclarado) || valorDeclarado < 0)
                {
                    Console.WriteLine("Valor inválido. Debe ser mayor o igual a cero.");
                }
            }

            decimal tarifaBase = 0;
            switch (zona)
            {
                case 1: tarifaBase = 60.00m; break;
                case 2: tarifaBase = 100.00m; break;
                case 3: tarifaBase = 150.00m; break;
            }

            decimal recargoPeso = 0;
            if (peso <= 1) recargoPeso = 0.00m;
            else if (peso <= 5) recargoPeso = 40.00m;
            else if (peso <= 10) recargoPeso = 80.00m;
            else recargoPeso = 140.00m;

            decimal sumaBasePeso = tarifaBase + recargoPeso;

            decimal recargoServicio = 0;
            switch (servicio)
            {
                case 1: recargoServicio = sumaBasePeso * 0.00m; break;
                case 2: recargoServicio = sumaBasePeso * 0.25m; break;
                case 3: recargoServicio = sumaBasePeso * 0.50m; break;
            }

            decimal subtotalSinSeguro = sumaBasePeso + recargoServicio;

            decimal seguro = 0;
            if (valorDeclarado > 5000.00m)
            {
                seguro = valorDeclarado * 0.02m;
            }

            decimal subtotalConSeguro = subtotalSinSeguro + seguro;

            decimal descuento = 0;
            if (subtotalConSeguro > 700.00m)
            {
                descuento = subtotalConSeguro * 0.05m;
            }

            decimal totalPagar = subtotalConSeguro - descuento;
            string tipoSeguroTexto = (valorDeclarado > 5000.00m) ? "Envío asegurado" : "Envío sin seguro";

            Console.WriteLine("            RECIBO DE ENVÍO             ");
            Console.WriteLine($"Tarifa base: {tarifaBase:C2}");
            Console.WriteLine($"Recargo por peso: {recargoPeso:C2}");
            Console.WriteLine($"Recargo por servicio: {recargoServicio:C2}");
            Console.WriteLine($"Seguro ({tipoSeguroTexto}): {seguro:C2}");
            Console.WriteLine($"Subtotal con seguro: {subtotalConSeguro:C2}");
            Console.WriteLine($"Descuento aplicado: {descuento:C2}");
            Console.WriteLine($"TOTAL A PAGAR: {totalPagar:C2}");
        }
    }
}