using Procesador_Transacciones.Negocio;
using System.Diagnostics;

#region Validar el ingreso del parametro del archivo CSV

if (args.Length == 0)
{
    Console.WriteLine("Error: Debe proporcionar la ruta del archivo CSV como parámetro.");
    Console.WriteLine("Uso: Procesador_Transacciones <ruta_archivo_csv>");
    return 1;
}
string csvPath = args[0];

// Validaciones de verificacion de la existencia y validez del archivo CSV
if (!File.Exists(csvPath) || !Path.IsPathRooted(csvPath))
{
    Console.WriteLine($"Error: El archivo CSV no existe en la ruta: {csvPath}");
    return 1;
}

if (Path.GetExtension(csvPath).ToLower() != ".csv")
{
    Console.WriteLine($"Error: El archivo proporcionado no es un archivo CSV: {csvPath}");
    return 1;
}

#endregion

Console.WriteLine($"Procesando archivo CSV: {csvPath}");
var stopwatch = Stopwatch.StartNew();

// ** Proceso con libreria (Menos optimo)
//var transacciones = ProcesamientoTransacciones.ProcesarArchivoCSVHelper(csvPath, out string error);

// ** Proceso normal, directo (Optimo)
var transacciones = ProcesamientoTransacciones.ProcesarArchivoCSVDefault(csvPath, out string error);

if (error != string.Empty)
{
    Console.WriteLine(error);
    return 1;
}

// 1. Balance final
var totalSumaCredito = transacciones.Where(c=>c.Tipo == "Crédito").Sum(t => t.Monto);
var totalSumaDebito = transacciones.Where(c=>c.Tipo == "Débito").Sum(t => t.Monto);
var balanceFinal = totalSumaCredito - totalSumaDebito;

// 2. Transaccion de Mayor monto
var transaccionMaxima = transacciones.MaxBy(c => c.Monto);

// 3. Conteo de transacciones (Credito - Debito)
var totalTransaccionesCredito = transacciones.Count(c => c.Tipo == "Crédito");
var totalTransaccionesDebito = transacciones.Count(c => c.Tipo == "Débito");



stopwatch.Stop();
Console.WriteLine(
    "_____________________________________________________________________________ \n" +
    $"Reporte de transacciones (Tiempo ejec: {stopwatch.ElapsedMilliseconds} ms)\n" +
    "_____________________________________________________________________________ \n" +
    $"Balance Final: {balanceFinal} \n" +
    $"Transaccion de Mayor Monto: ID {transaccionMaxima?.Id} - {transaccionMaxima?.Monto} \n" +
    $"Conteo de transacciones: Crédito({totalTransaccionesCredito}) - Débito({totalTransaccionesDebito}) \n" 
);

return 0;
