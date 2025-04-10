using CsvHelper;
using Procesador_Transacciones.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesador_Transacciones.Negocio
{
    public static class ProcesamientoTransacciones
    {
        public static List<Transacciones> ProcesarArchivoCSVDefault(string rutaArchivo, out string error)
        {
            try
            {
                error = string.Empty;
                var listaTransacciones = new List<Transacciones>();
                var lineas = File.ReadAllLines(rutaArchivo);

                // Leer la cabecera para determinar el índice de las columnas
                var cabecera = lineas[0].Split(',');
                var idIndex = Array.FindIndex(cabecera, col => col.Trim().ToLower() == "id");
                var tipoIndex = Array.FindIndex(cabecera, col => col.Trim().ToLower() == "tipo");
                var montoIndex = Array.FindIndex(cabecera, col => col.Trim().ToLower() == "monto");

                // Validar que se encontraron todas las columnas necesarias
                if (idIndex == -1 || tipoIndex == -1 || montoIndex == -1)
                {
                    error = "El archivo CSV no contiene las columnas requeridas (ID, Tipo, Monto)";
                    return listaTransacciones;
                }

                // Procesar las líneas de datos
                foreach (var linea in lineas.Skip(1))
                {
                    var informacion = linea.Split(',');
                    var id = int.Parse(informacion[idIndex]);
                    var tipo = informacion[tipoIndex];
                    var monto = decimal.Parse(informacion[montoIndex]);

                    listaTransacciones.Add(new Transacciones(id, tipo, monto));
                }

                return listaTransacciones;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return new List<Transacciones>();
            }
            
        }

        public static List<Transacciones> ProcesarArchivoCSVHelper(string rutaArchivo, out string error)
        {
            try
            {
                error = string.Empty;
                using var strReader = new StreamReader(rutaArchivo);
                using var dataCsv = new CsvReader(strReader, CultureInfo.InvariantCulture);

                var listaTransacciones = dataCsv.GetRecords<Transacciones>().ToList();
                return listaTransacciones;

            }
            catch (Exception ex)
            {
                error = ex.Message; 
                return new List<Transacciones>();
            }

        }
    }
}
