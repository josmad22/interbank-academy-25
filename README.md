# Procesador de Transacciones Financieras

## Introducción
Este proyecto es una aplicación de consola en C# que procesa archivos CSV conteniendo transacciones financieras. La aplicación está diseñada para leer, procesar y analizar transacciones financieras, generando un reporte con estadísticas importantes como balance final, transacción de mayor monto y conteo de operaciones por tipo.

## Instrucciones de Ejecución
La aplicación está desarrollada en .NET 8.0. Para ejecutar el programa:

1. Asegúrese de tener .NET 8.0 SDK instalado
2. Ejecute la aplicación usando el siguiente comando:
```bash
Procesador_Transacciones <ruta_archivo_csv>
```

El archivo CSV debe contener las siguientes columnas:
- id
- tipo
- monto

Ejemplo del formato CSV:
```csv
id,tipo,monto
1,Crédito,1000.00
2,Débito,500.00
```

## Enfoque y Solución
La solución implementa dos enfoques distintos para el procesamiento de archivos CSV:

1. Implementación Optimizada (ProcesarArchivoCSVDefault):
   - Lectura directa del archivo para máximo rendimiento
   - Detección automática de índices de columnas
   - Procesamiento línea por línea
   - Manejo robusto de errores

2. Implementación Alternativa (ProcesarArchivoCSVHelper):
   - Utiliza la librería CsvHelper
   - Ofrece mayor flexibilidad en el mapeo
   - Ideal para escenarios que requieren procesamiento más complejo

Características técnicas implementadas:
- Validaciones exhaustivas (existencia del archivo, formato, estructura)
- Medición de rendimiento mediante Stopwatch
- Generación de reportes detallados incluyendo:
  - Tiempo de ejecución
  - Balance final
  - Detalles de transacción máxima
  - Estadísticas por tipo de transacción

## Estructura del Proyecto
El proyecto está organizado en los siguientes componentes principales:

1. **Program.cs (Punto de Entrada)**
   - Manejo de parámetros de entrada
   - Coordinación del procesamiento
   - Generación de reportes y estadísticas

2. **Entidades/Transacciones.cs**
   - Modelo de datos para transacciones financieras
   - Atributos: Id, Tipo, Monto
   - Mapeo de columnas CSV para la libreria de CSVHelper

3. **Negocio/ProcesamientoTransacciones.cs**
   - Lógica principal de procesamiento
   - Implementación de ambos métodos de lectura CSV
   - Manejo de errores y validaciones
