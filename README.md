# Procesador de Transacciones Financieras

Este proyecto es una aplicación de consola en C# que procesa archivos CSV conteniendo transacciones financieras y genera un reporte con estadísticas importantes.

## Estructura del Proyecto

El proyecto está organizado en las siguientes partes principales:

### 1. Program.cs (Punto de Entrada)
- Valida los parámetros de entrada (ruta del archivo CSV)
- Realiza el procesamiento de las transacciones
- Calcula y muestra las estadísticas:
  - Balance final (Créditos - Débitos)
  - Transacción de mayor monto
  - Conteo de transacciones por tipo (Crédito/Débito)
- Incluye medición del tiempo de ejecución

### 2. Entidades/Transacciones.cs
Clase que representa una transacción financiera con los siguientes atributos:
- `Id`: Identificador único de la transacción
- `Tipo`: Tipo de transacción ("Crédito" o "Débito")
- `Monto`: Valor monetario de la transacción
La clase utiliza atributos de CsvHelper para mapear las columnas del CSV, como una prueba para validar la optimizacion del proceso sin uso de libreria.

### 3. Negocio/ProcesamientoTransacciones.cs
Clase estática que contiene la lógica de procesamiento del archivo CSV con dos implementaciones:

1. `ProcesarArchivoCSVDefault`: 
   - Implementación optimizada usando lecturas directas del archivo
   - Detecta automáticamente los índices de las columnas
   - Procesa línea por línea el archivo CSV
   - Manejo de errores robusto

2. `ProcesarArchivoCSVHelper`:
   - Implementación alternativa usando la librería CsvHelper
   - Más simple pero menos optimizada
   - Útil para casos donde se requiere mayor flexibilidad en el mapeo

## Uso de la Aplicación

```bash
Procesador_Transacciones <ruta_archivo_csv>
```

### Formato del Archivo CSV
El archivo CSV debe contener las siguientes columnas:
- id
- tipo
- monto

Ejemplo:
```csv
id,tipo,monto
1,Crédito,1000.00
2,Débito,500.00
```

### Salida
La aplicación genera un reporte que incluye:
- Tiempo de ejecución en milisegundos
- Balance final
- Detalles de la transacción de mayor monto
- Conteo total de transacciones por tipo

## Características Técnicas

- Desarrollado en .NET 8.0
- Uso opcional de CsvHelper para procesamiento de CSV
- Manejo de errores y validaciones:
  - Existencia del archivo
  - Formato del archivo (.csv)
  - Estructura de columnas requeridas
  - Parseo de datos
- Medición de rendimiento usando Stopwatch
