# API Gestor de Clientes

Este repositorio contiene la implementación de una API en .NET para la gestión de la tabla `Cliente`, conectada a una base de datos SQL Server mediante ADO.NET.

## ⚙️ Requisitos Previos
* SQL Server Management Studio (SSMS)
* Visual Studio (o entorno compatible con .NET)
* Postman (para realizar las pruebas a los endpoints)

---

## 🚀 Instrucciones para configurar la conexión y ejecutar la API

### 1. Preparar la base de datos
1. Abre SQL Server Management Studio (SSMS).
2. Ejecuta el script SQL proporcionado en los entregables de esta actividad. 
3. Este script se encargará de crear la tabla `Cliente`, generar los cinco procedimientos almacenados necesarios (`INSERTAR`, `ACTUALIZAR`, `ELIMINAR` lógico, `CONSULTAR_TODOS`, `CONSULTAR_POR_ID`) e insertar los datos de prueba iniciales.

### 2. Configurar la cadena de conexión
1. Abre el proyecto de la API en Visual Studio.
2. Dirígete al archivo `appsettings.json` ubicado en la raíz del proyecto.
3. Localiza la sección de la cadena de conexión (usualmente nombrada `"CadenaSQL"`).
4. Reemplaza el valor de `Server=` con el nombre de tu servidor local de SQL Server y verifica que `Database=` apunte a la base de datos correcta.

Ejemplo:
```json
"ConnectionStrings": {
    "CadenaSQL": "Data Source=EMIR\\MSSQLSERVEREXP;Initial Catalog=PRACTICA_CLIENTE;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Ejecutar la API
1. Presiona `F5` o haz clic en el botón de **"Ejecutar"** en la parte superior de Visual Studio para compilar e iniciar el proyecto.
2. Se abrirá una ventana de consola o el navegador indicando el puerto local donde la API está en ejecución. 
3. Toma nota de la URL base (por ejemplo, `https://localhost:5299`).

### 4. Ejecutar pruebas en Postman
1. Abre la aplicación Postman.
2. Importa el archivo de la **Colección de Postman** exportada que se incluye en los entregables.
3. Si es necesario, actualiza la URL base de cada petición (POST, GET, PUT, DELETE) para que coincida con el puerto local asignado a tu API en el paso anterior.
4. Ejecuta las cinco operaciones para validar el funcionamiento completo del CRUD.
